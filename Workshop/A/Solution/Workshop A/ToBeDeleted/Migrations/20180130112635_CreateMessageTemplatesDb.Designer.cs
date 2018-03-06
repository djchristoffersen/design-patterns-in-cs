﻿// <auto-generated />
using Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ToBeDeleted.Migrations
{
    [DbContext(typeof(MessageTemplatesContext))]
    [Migration("20180130112635_CreateMessageTemplatesDb")]
    partial class CreateMessageTemplatesDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wincubate.WorkshopA.Data.MessageTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Culture");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.ToTable("MessageTemplates");
                });
#pragma warning restore 612, 618
        }
    }
}
