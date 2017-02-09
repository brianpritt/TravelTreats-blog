using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TravelTreats.Models;

namespace TravelTreats.Migrations
{
    [DbContext(typeof(TravelTreatsDbContext))]
    [Migration("20170208235320_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelTreats.Models.Encounter", b =>
                {
                    b.Property<int>("EncounterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExperienceId");

                    b.Property<int>("PersonId");

                    b.HasKey("EncounterId");

                    b.HasIndex("ExperienceId");

                    b.HasIndex("PersonId");

                    b.ToTable("Encounters");
                });

            modelBuilder.Entity("TravelTreats.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("LocationId");

                    b.Property<int>("MealTypeId");

                    b.HasKey("ExperienceId");

                    b.HasIndex("LocationId")
                        .IsUnique();

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("TravelTreats.Models.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LocationName");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("TravelTreats.Models.MealType", b =>
                {
                    b.Property<int>("MealTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MealTypeName");

                    b.HasKey("MealTypeId");

                    b.ToTable("MealTypes");
                });

            modelBuilder.Entity("TravelTreats.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PersonName");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("TravelTreats.Models.Encounter", b =>
                {
                    b.HasOne("TravelTreats.Models.Experience", "Experience")
                        .WithMany("Encounters")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelTreats.Models.Person", "Person")
                        .WithMany("Encounters")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelTreats.Models.Experience", b =>
                {
                    b.HasOne("TravelTreats.Models.Location")
                        .WithOne("Experience")
                        .HasForeignKey("TravelTreats.Models.Experience", "LocationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
