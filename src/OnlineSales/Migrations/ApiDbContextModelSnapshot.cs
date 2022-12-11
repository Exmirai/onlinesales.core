﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OnlineSales.Data;

#nullable disable

namespace OnlineSales.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OnlineSales.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Approved")
                        .HasColumnType("integer")
                        .HasColumnName("approved");

                    b.Property<string>("AuthorEmail")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("author_email");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("author_name");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("created_by_ip");

                    b.Property<string>("CreatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("created_by_user_agent");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer")
                        .HasColumnName("parent_id");

                    b.Property<int>("PostId")
                        .HasColumnType("integer")
                        .HasColumnName("post_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_ip");

                    b.Property<string>("UpdatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_user_agent");

                    b.HasKey("Id")
                        .HasName("pk_comment");

                    b.HasIndex("ParentId")
                        .HasDatabaseName("ix_comment_parent_id");

                    b.HasIndex("PostId")
                        .HasDatabaseName("ix_comment_post_id");

                    b.ToTable("comment", (string)null);
                });

            modelBuilder.Entity("OnlineSales.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address1")
                        .HasColumnType("text")
                        .HasColumnName("address1");

                    b.Property<string>("Address2")
                        .HasColumnType("text")
                        .HasColumnName("address2");

                    b.Property<string>("CompanyName")
                        .HasColumnType("text")
                        .HasColumnName("company_name");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("created_by_ip");

                    b.Property<string>("CreatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("created_by_user_agent");

                    b.Property<string>("Culture")
                        .HasColumnType("text")
                        .HasColumnName("culture");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Location")
                        .HasColumnType("text")
                        .HasColumnName("location");

                    b.Property<string>("Phone")
                        .HasColumnType("text")
                        .HasColumnName("phone");

                    b.Property<string>("State")
                        .HasColumnType("text")
                        .HasColumnName("state");

                    b.Property<int?>("Timezone")
                        .HasColumnType("integer")
                        .HasColumnName("timezone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_ip");

                    b.Property<string>("UpdatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_user_agent");

                    b.Property<string>("Zip")
                        .HasColumnType("text")
                        .HasColumnName("zip");

                    b.HasKey("Id")
                        .HasName("pk_customer");

                    b.ToTable("customer", (string)null);
                });

            modelBuilder.Entity("OnlineSales.Entities.CustomerEmailSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("created_by_ip");

                    b.Property<string>("CreatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("created_by_user_agent");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    b.Property<int?>("EmailScheduleId")
                        .HasColumnType("integer")
                        .HasColumnName("email_schedule_id");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer")
                        .HasColumnName("schedule_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_ip");

                    b.Property<string>("UpdatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_user_agent");

                    b.HasKey("Id")
                        .HasName("pk_customer_email_schedule");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_customer_email_schedule_customer_id");

                    b.HasIndex("EmailScheduleId")
                        .HasDatabaseName("ix_customer_email_schedule_email_schedule_id");

                    b.ToTable("customer_email_schedule", (string)null);
                });

            modelBuilder.Entity("OnlineSales.Entities.EmailGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("created_by_ip");

                    b.Property<string>("CreatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("created_by_user_agent");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("language");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_ip");

                    b.Property<string>("UpdatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_user_agent");

                    b.HasKey("Id")
                        .HasName("pk_email_group");

                    b.ToTable("email_group", (string)null);
                });

            modelBuilder.Entity("OnlineSales.Entities.EmailLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("body");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("created_by_ip");

                    b.Property<string>("CreatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("created_by_user_agent");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    b.Property<string>("FromEmail")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("from_email");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("recipient");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("integer")
                        .HasColumnName("schedule_id");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("subject");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("integer")
                        .HasColumnName("template_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_ip");

                    b.Property<string>("UpdatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_user_agent");

                    b.HasKey("Id")
                        .HasName("pk_email_log");

                    b.ToTable("email_log", (string)null);
                });

            modelBuilder.Entity("OnlineSales.Entities.EmailSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("created_by_ip");

                    b.Property<string>("CreatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("created_by_user_agent");

                    b.Property<int?>("EmailGroupId")
                        .HasColumnType("integer")
                        .HasColumnName("email_group_id");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    b.Property<string>("Schedule")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("schedule");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_ip");

                    b.Property<string>("UpdatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_user_agent");

                    b.HasKey("Id")
                        .HasName("pk_email_schedule");

                    b.HasIndex("EmailGroupId")
                        .HasDatabaseName("ix_email_schedule_email_group_id");

                    b.ToTable("email_schedule", (string)null);
                });

            modelBuilder.Entity("OnlineSales.Entities.EmailTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BodyTemplate")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("body_template");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("created_by_ip");

                    b.Property<string>("CreatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("created_by_user_agent");

                    b.Property<string>("FromEmail")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("from_email");

                    b.Property<string>("FromName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("from_name");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer")
                        .HasColumnName("group_id");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("language");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("subject");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_ip");

                    b.Property<string>("UpdatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_user_agent");

                    b.HasKey("Id")
                        .HasName("pk_email_template");

                    b.HasIndex("GroupId")
                        .HasDatabaseName("ix_email_template_group_id");

                    b.ToTable("email_template", (string)null);
                });

            modelBuilder.Entity("OnlineSales.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("created_by_ip");

                    b.Property<string>("CreatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("created_by_user_agent");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("data");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("extension");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("mime_type");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("ScopeUid")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("scope_uid");

                    b.Property<long>("Size")
                        .HasColumnType("bigint")
                        .HasColumnName("size");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_ip");

                    b.Property<string>("UpdatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_user_agent");

                    b.HasKey("Id")
                        .HasName("pk_image");

                    b.ToTable("image", (string)null);
                });

            modelBuilder.Entity("OnlineSales.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AffiliateName")
                        .HasColumnType("text")
                        .HasColumnName("affiliate_name");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("created_by_ip");

                    b.Property<string>("CreatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("created_by_user_agent");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("currency");

                    b.Property<decimal>("CurrencyTotal")
                        .HasColumnType("numeric")
                        .HasColumnName("currency_total");

                    b.Property<string>("CustomerIP")
                        .HasColumnType("text")
                        .HasColumnName("customer_ip");

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer")
                        .HasColumnName("customer_id");

                    b.Property<string>("Data")
                        .HasColumnType("jsonb")
                        .HasColumnName("data");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("text")
                        .HasColumnName("order_number");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<string>("RefNo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ref_no");

                    b.Property<bool>("TestOrder")
                        .HasColumnType("boolean")
                        .HasColumnName("test_order");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric")
                        .HasColumnName("total");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_ip");

                    b.Property<string>("UpdatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_user_agent");

                    b.HasKey("Id")
                        .HasName("pk_order");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_order_customer_id");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("OnlineSales.Entities.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("created_by_ip");

                    b.Property<string>("CreatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("created_by_user_agent");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("currency");

                    b.Property<decimal>("CurrencyTotal")
                        .HasColumnType("numeric")
                        .HasColumnName("currency_total");

                    b.Property<string>("LicenseCode")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("license_code");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer")
                        .HasColumnName("order_id");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("product_name");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric")
                        .HasColumnName("total");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_ip");

                    b.Property<string>("UpdatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_user_agent");

                    b.HasKey("Id")
                        .HasName("pk_order_item");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_item_order_id");

                    b.ToTable("order_item", (string)null);
                });

            modelBuilder.Entity("OnlineSales.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("AllowComments")
                        .HasColumnType("boolean")
                        .HasColumnName("allow_comments");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("author");

                    b.Property<string>("Categories")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("categories");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<string>("CoverImageAlt")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cover_image_alt");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cover_image_url");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("created_by_ip");

                    b.Property<string>("CreatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("created_by_user_agent");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("language");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("slug");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("tags");

                    b.Property<string>("Template")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("template");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_ip");

                    b.Property<string>("UpdatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_user_agent");

                    b.HasKey("Id")
                        .HasName("pk_post");

                    b.ToTable("post", (string)null);
                });

            modelBuilder.Entity("OnlineSales.Entities.TaskExecutionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ActualExecutionTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("actual_execution_time");

                    b.Property<string>("Comment")
                        .HasColumnType("text")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("created_by_ip");

                    b.Property<string>("CreatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("created_by_user_agent");

                    b.Property<int>("RetryCount")
                        .HasColumnType("integer")
                        .HasColumnName("retry_count");

                    b.Property<DateTime>("ScheduledExecutionTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("scheduled_execution_time");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<string>("TaskName")
                        .HasColumnType("text")
                        .HasColumnName("task_name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UpdatedByIp")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_ip");

                    b.Property<string>("UpdatedByUserAgent")
                        .HasColumnType("text")
                        .HasColumnName("updated_by_user_agent");

                    b.HasKey("Id")
                        .HasName("pk_task_execution_log");

                    b.ToTable("task_execution_log", (string)null);
                });

            modelBuilder.Entity("OnlineSales.Entities.Comment", b =>
                {
                    b.HasOne("OnlineSales.Entities.Comment", "Parent")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .HasConstraintName("fk_comment_comment_parent_id");

                    b.HasOne("OnlineSales.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_comment_post_post_id");

                    b.Navigation("Parent");

                    b.Navigation("Post");
                });

            modelBuilder.Entity("OnlineSales.Entities.CustomerEmailSchedule", b =>
                {
                    b.HasOne("OnlineSales.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_customer_email_schedule_customer_customer_id");

                    b.HasOne("OnlineSales.Entities.EmailSchedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("EmailScheduleId")
                        .HasConstraintName("fk_customer_email_schedule_email_schedule_email_schedule_id");

                    b.Navigation("Customer");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("OnlineSales.Entities.EmailSchedule", b =>
                {
                    b.HasOne("OnlineSales.Entities.EmailGroup", "Group")
                        .WithMany()
                        .HasForeignKey("EmailGroupId")
                        .HasConstraintName("fk_email_schedule_email_group_email_group_id");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("OnlineSales.Entities.EmailTemplate", b =>
                {
                    b.HasOne("OnlineSales.Entities.EmailGroup", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_email_template_email_group_group_id");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("OnlineSales.Entities.Order", b =>
                {
                    b.HasOne("OnlineSales.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_customer_customer_id");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("OnlineSales.Entities.OrderItem", b =>
                {
                    b.HasOne("OnlineSales.Entities.Order", "Customer")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_item_order_order_id");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("OnlineSales.Entities.Post", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
