﻿// <copyright file="BaseController.cs" company="WavePoint Co. Ltd.">
// Licensed under the MIT license. See LICENSE file in the samples root for full license information.
// </copyright>

using System.Collections;
using System.Reflection;
using System.Web;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Nest;
using OnlineSales.Configuration;
using OnlineSales.Data;
using OnlineSales.DataAnnotations;
using OnlineSales.Entities;
using OnlineSales.Infrastructure;

namespace OnlineSales.Controllers
{
    public class BaseController<T, TC, TU, TD> : ControllerBase
        where T : BaseEntityWithId, new()
        where TC : class
        where TU : class
        where TD : class
    {
        protected readonly DbSet<T> dbSet;
        protected readonly PgDbContext dbContext;
        protected readonly IMapper mapper;
        private readonly IOptions<ApiSettingsConfig> apiSettingsConfig;
        private readonly ElasticClient elasticClient;

        public BaseController(PgDbContext dbContext, IMapper mapper, IOptions<ApiSettingsConfig> apiSettingsConfig, EsDbContext esDbContext)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.apiSettingsConfig = apiSettingsConfig;

            dbSet = dbContext.Set<T>();
            elasticClient = esDbContext.ElasticClient;
        }

        // GET api/{entity}s/5
        [HttpGet("{id}")]
        // [EnableQuery]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<TD>> GetOne(int id)
        {
            var result = await FindOrThrowNotFound(id);

            var resultConverted = mapper.Map<TD>(result);

            return Ok(resultConverted);
        }

        // POST api/{entity}s
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<TD>> Post([FromBody] TC value)
        {
            var newValue = mapper.Map<T>(value);
            var result = await dbSet.AddAsync(newValue);
            await dbContext.SaveChangesAsync();

            var resultsToClient = mapper.Map<TD>(newValue);

            return CreatedAtAction(nameof(GetOne), new { id = result.Entity.Id }, resultsToClient);
        }

        // PUT api/{entity}s/5
        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<TD>> Patch(int id, [FromBody] TU value)
        {
            var existingEntity = await FindOrThrowNotFound(id);

            mapper.Map(value, existingEntity);
            await dbContext.SaveChangesAsync();

            var resultsToClient = mapper.Map<TD>(existingEntity);

            return Ok(resultsToClient);
        }

        // DELETE api/{entity}s/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult> Delete(int id)
        {
            var existingEntity = await FindOrThrowNotFound(id);

            dbContext.Remove(existingEntity);

            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<List<TD>>> Get([FromQuery] string? query)
        {
            var limit = apiSettingsConfig.Value.MaxListSize;

            var qp = BuildQueryProvider(limit);

            var result = await qp.GetResult();
            Response.Headers.Add(ResponseHeaderNames.TotalCount, result.TotalCount.ToString());
            Response.Headers.Add(ResponseHeaderNames.AccessControlExposeHeader, ResponseHeaderNames.TotalCount);
            var res = mapper.Map<List<TD>>(result.Records);
            RemoveSecondLevelObjects(res);
            return Ok(res);
        }

        [HttpGet("export")]
        [Produces("text/csv", "text/json")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public virtual async Task<ActionResult<List<TD>>> Export([FromQuery] string? query)
        {
            var qp = BuildQueryProvider(int.MaxValue);

            var result = await qp.GetResult();
            Response.Headers.Add(ResponseHeaderNames.TotalCount, result.TotalCount.ToString());
            Response.Headers.Add(ResponseHeaderNames.AccessControlExposeHeader, ResponseHeaderNames.TotalCount);
            var res = mapper.Map<List<TD>>(result.Records);
            RemoveSecondLevelObjects(res);
            return Ok(res);
        }

        protected async Task<T> FindOrThrowNotFound(int id)
        {
            var existingEntity = await (from p in dbSet
                                        where p.Id == id
                                        select p).FirstOrDefaultAsync();

            if (existingEntity == null)
            {
                throw new EntityNotFoundException(typeof(T).Name, id.ToString());
            }

            return existingEntity;
        }
                
        private static void RemoveSecondLevelObjects(IList<TD> data)
        {
            var refs = SecondLevelDTOs.Data;

            foreach (var item in data)
            {
                foreach (var r in refs)
                {
                    var propertyObject = r.Key.GetValue(item);
                    if (propertyObject != null)
                    {
                        if (r.Key.PropertyType.GetInterface("IEnumerable") != null && r.Key.PropertyType.IsGenericType)
                        {
                            var e = propertyObject as IEnumerable;
                            foreach (var obj in e!)
                            {
                                foreach (var p in r.Value)
                                {
                                    p.SetValue(obj, null);
                                }
                            }
                        }
                        else
                        {
                            foreach (var p in r.Value)
                            {
                                p.SetValue(propertyObject, null);
                            }
                        }
                    }
                }
            }
        }

        private IQueryProvider<T> BuildQueryProvider(int maxLimitSize)
        {
            var queryCommands = QueryParser.Parse(Request.QueryString.HasValue ? HttpUtility.UrlDecode(Request.QueryString.ToString()) : string.Empty);

            var queryData = new QueryData<T>(queryCommands, maxLimitSize, dbContext);

            if (typeof(T).GetCustomAttributes(typeof(SupportsElasticAttribute), true).Any() && queryData.SearchData.Count > 0)
            {
                var indexPrefix = this.dbContext.Configuration.GetSection("Elastic:IndexPrefix").Get<string>();
                return new MixedQueryProvider<T>(queryData, this.dbSet!.AsQueryable<T>(), this.elasticClient, indexPrefix!);
            }
            else
            {
                return new DBQueryProvider<T>(this.dbSet!.AsQueryable<T>(), queryData);
            }
        }

        private sealed class SecondLevelDTOs 
        {
            public static readonly Dictionary<PropertyInfo, List<PropertyInfo>> Data = InitReferences();

            private static Dictionary<PropertyInfo, List<PropertyInfo>> InitReferences()
            {
                bool IsNullableProperty(PropertyInfo pi)
                {
                    var context = new NullabilityInfoContext();
                    var info = context.Create(pi);
                    return info.WriteState == NullabilityState.Nullable;
                }

                bool IsDto(Type type)
                {
                    return type.IsClass && type.Namespace != null && type.Namespace!.StartsWith("OnlineSales.DTOs");
                }

                bool IsNeedToSave(PropertyInfo pi)
                {
                    return IsNullableProperty(pi) &&
                        (IsDto(pi.PropertyType) || (pi.PropertyType.GetInterface("IEnumerable") != null && pi.PropertyType.IsGenericType && IsDto(pi.PropertyType.GetGenericArguments()[0])));
                }

                Type GetType(PropertyInfo pi)
                {
                    if (pi.PropertyType.GetInterface("IEnumerable") != null && pi.PropertyType.IsGenericType)
                    {
                        return pi.PropertyType.GetGenericArguments()[0];
                    }
                    else
                    {
                        return pi.PropertyType;
                    }
                }

                var res = new Dictionary<PropertyInfo, List<PropertyInfo>>();
                var properties = typeof(TD).GetProperties();
                foreach (var property in properties)
                {
                    var pType = GetType(property);
                    var nestedProperties = pType.GetProperties();
                    foreach (var nestedProperty in nestedProperties.Where(np => IsNeedToSave(np)))
                    {
                        List<PropertyInfo> temp;
                        if (res.TryGetValue(property, out temp!))
                        {
                            temp.Add(nestedProperty);
                        }
                        else
                        {
                            temp = new List<PropertyInfo>() { nestedProperty };
                            res.Add(property, temp);
                        }
                    }
                }

                return res;
            }
        }
    }
}