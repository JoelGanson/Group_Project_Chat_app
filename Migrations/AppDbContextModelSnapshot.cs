﻿// <auto-generated />
using Group_Project_Chat_app.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Group_Project_Chat_app.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Group_Project_Chat_app.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasMaxLength(24)
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.PrimitiveCollection<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Username = "Admin",
                            Password = "TeamProcrastination",
                            Role = "[\"User\",\"Admin\"]"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
