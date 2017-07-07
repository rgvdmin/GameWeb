using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GameWeb;

namespace GameWeb.Migrations
{
    [DbContext(typeof(EFCoreGameWebContext))]
    [Migration("20170703233130_AddednewAge")]
    partial class AddednewAge
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("GameWeb.Models.ScoreBoard", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("age");

                    b.Property<string>("name");

                    b.HasKey("id");

                    b.ToTable("ScoreBoards");
                });
        }
    }
}
