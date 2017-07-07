using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GameWeb;

namespace GameWeb.Migrations
{
    [DbContext(typeof(EFCoreGameWebContext))]
    [Migration("20170704005222_date and time")]
    partial class dateandtime
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

                    b.Property<int>("timePlayed");

                    b.HasKey("id");

                    b.ToTable("ScoreBoards");
                });
        }
    }
}
