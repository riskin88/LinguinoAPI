﻿// <auto-generated />
using System;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DAL.Entities.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("LanguageFrom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbnailURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("DAL.Entities.Lesson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AuthorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCustom")
                        .HasColumnType("bit");

                    b.Property<int?>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrderOnMap")
                        .HasColumnType("bigint");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("CourseId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("DAL.Entities.LessonItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LessonItem");
                });

            modelBuilder.Entity("DAL.Entities.Relations.LessonItemLesson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("LessonId")
                        .HasColumnType("bigint");

                    b.Property<long>("LessonItemId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("LessonItemId");

                    b.ToTable("LessonItemLesson");
                });

            modelBuilder.Entity("DAL.Entities.Relations.TopicLesson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("LessonId")
                        .HasColumnType("bigint");

                    b.Property<long>("TopicId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("TopicId");

                    b.ToTable("TopicLesson");
                });

            modelBuilder.Entity("DAL.Entities.Relations.UserCourse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsSelected")
                        .HasColumnType("bit");

                    b.Property<long>("PositionOnMap")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCourse");
                });

            modelBuilder.Entity("DAL.Entities.Relations.UserLesson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsFavorite")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<long>("ItemsDone")
                        .HasColumnType("bigint");

                    b.Property<long>("ItemsTotal")
                        .HasColumnType("bigint");

                    b.Property<long>("LessonId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLesson");
                });

            modelBuilder.Entity("DAL.Entities.Relations.UserTopic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<long>("LessonsActive")
                        .HasColumnType("bigint");

                    b.Property<long>("TopicId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("UserTopic");
                });

            modelBuilder.Entity("DAL.Entities.Topic", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("Category")
                        .HasColumnType("int");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<long>("LessonsTotal")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThumbnailURL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool?>("AccountInitialized")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<long?>("Balance")
                        .HasColumnType("bigint");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("Streak")
                        .HasColumnType("bigint");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "3cf4378a-3fca-45d5-8782-db69e9bd5259",
                            Name = "USER",
                            NormalizedName = "USER"
                        },
                        new
                        {
                            Id = "d05744d9-00ed-4cb8-8224-eb1e4abf31ba",
                            Name = "PREMIUM_USER",
                            NormalizedName = "PREMIUM_USER"
                        },
                        new
                        {
                            Id = "7521910b-749d-4fbd-bf8e-dfddb9aa4fd6",
                            Name = "ADMIN",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DAL.Entities.Lesson", b =>
                {
                    b.HasOne("DAL.Entities.User", "Author")
                        .WithMany("LessonsCreated")
                        .HasForeignKey("AuthorId");

                    b.HasOne("DAL.Entities.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId");

                    b.Navigation("Author");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("DAL.Entities.Relations.LessonItemLesson", b =>
                {
                    b.HasOne("DAL.Entities.Lesson", "Lesson")
                        .WithMany("LessonItemLessons")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.LessonItem", "LessonItem")
                        .WithMany("LessonItemLessons")
                        .HasForeignKey("LessonItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("LessonItem");
                });

            modelBuilder.Entity("DAL.Entities.Relations.TopicLesson", b =>
                {
                    b.HasOne("DAL.Entities.Lesson", "Lesson")
                        .WithMany("TopicLessons")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.Topic", "Topic")
                        .WithMany("TopicLessons")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("DAL.Entities.Relations.UserCourse", b =>
                {
                    b.HasOne("DAL.Entities.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("UserCourses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Relations.UserLesson", b =>
                {
                    b.HasOne("DAL.Entities.Lesson", "Lesson")
                        .WithMany("UserLessons")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("UserLessons")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Relations.UserTopic", b =>
                {
                    b.HasOne("DAL.Entities.Topic", "Topic")
                        .WithMany("UserTopics")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", "User")
                        .WithMany("UserTopics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DAL.Entities.Topic", b =>
                {
                    b.HasOne("DAL.Entities.Course", "Course")
                        .WithMany("Topics")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("DAL.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DAL.Entities.Course", b =>
                {
                    b.Navigation("Lessons");

                    b.Navigation("Topics");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("DAL.Entities.Lesson", b =>
                {
                    b.Navigation("LessonItemLessons");

                    b.Navigation("TopicLessons");

                    b.Navigation("UserLessons");
                });

            modelBuilder.Entity("DAL.Entities.LessonItem", b =>
                {
                    b.Navigation("LessonItemLessons");
                });

            modelBuilder.Entity("DAL.Entities.Topic", b =>
                {
                    b.Navigation("TopicLessons");

                    b.Navigation("UserTopics");
                });

            modelBuilder.Entity("DAL.Entities.User", b =>
                {
                    b.Navigation("LessonsCreated");

                    b.Navigation("UserCourses");

                    b.Navigation("UserLessons");

                    b.Navigation("UserTopics");
                });
#pragma warning restore 612, 618
        }
    }
}
