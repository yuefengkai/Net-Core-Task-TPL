﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TASK.Service.Data;

namespace TASK.Service.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TASK.Service.Data.Person", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("T_Persions");
                });
#pragma warning restore 612, 618
        }
    }
}