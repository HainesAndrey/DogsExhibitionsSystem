using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DogsExhibitionsSystem.Models;

namespace DogsExhibitionsSystem.Helpers
{
    public static class DbModelBuilder
    {
        public static void Build(this ModelBuilder builder)
        {
            builder.CreateTable_DogBreed();
            builder.CreateTable_DogHandler();
            builder.CreateTable_DogPedigree();
            builder.CreateTable_Dog();
            builder.CreateTable_Club();
            builder.CreateTable_Medal();
            builder.CreateTable_Expert();
            builder.CreateTable_Ring();
            builder.CreateTable_RingDogExpert();
        }

        private static void CreateTable_DogBreed(this ModelBuilder builder)
        {
            builder.SharedTypeEntity<Dictionary<string, object>>("dogBreed_ring", builder =>
            {
                builder.Property<uint>("id_dogBreed");
                builder.Property<uint>("id_ring");
            });
            builder.Entity<DogBreed>(br =>
            {
                br.HasIndex(x => x.Name).IsUnique();
                br.HasMany(x => x.Dogs).WithOne(x => x.Breed).HasForeignKey(x => x.BreedId);
                br.HasMany(x => x.Experts).WithOne(x => x.DogBreed).HasForeignKey(x => x.DogBreedId);
                br.HasMany(x => x.Rings).WithMany(x => x.DogBreeds)
                    .UsingEntity<Dictionary<string, object>>("dogBreed_ring",
                        r => r.HasOne<Ring>().WithMany().HasForeignKey("id_dogBreed"),
                        b => b.HasOne<DogBreed>().WithMany().HasForeignKey("id_ring"),
                        t => t.ToTable("dogBreed_ring"));
            });
        }

        private static void CreateTable_DogHandler(this ModelBuilder builder)
        {
            builder.Entity<DogHandler>(dh =>
            {
                dh.HasIndex(x => x.PasportNumber).IsUnique();
            });
        }

        private static void CreateTable_DogPedigree(this ModelBuilder builder)
        {
            builder.Entity<DogPedigree>(dp =>
            {
                dp.HasIndex(x => x.DocumentNumber).IsUnique();
            });
        }

        private static void CreateTable_Dog(this ModelBuilder builder)
        {
            builder.Entity<Dog>(d =>
            {
                d.HasIndex(nameof(Dog.BreedId), nameof(Dog.Name), nameof(Dog.HandlerId)).IsUnique();
                d.HasOne(x => x.Breed).WithMany(x => x.Dogs).HasForeignKey(x => x.BreedId);
                d.HasOne(x => x.Handler).WithOne(x => x.Dog).HasForeignKey<Dog>(x => x.HandlerId);
                d.HasOne(x => x.Pedigree).WithOne(x => x.Dog).HasForeignKey<Dog>(x => x.PedigreeId);
                d.HasMany(x => x.Medals).WithOne(x => x.Dog);
            });
        }

        private static void CreateTable_Club(this ModelBuilder builder)
        {
            builder.Entity<Club>(cl =>
            {
                cl.HasIndex(x => x.Name).IsUnique();
                cl.HasMany(x => x.Dogs).WithOne(x => x.Club);
                cl.HasMany(x => x.Experts).WithOne(x => x.Club);
            });
        }

        private static void CreateTable_Medal(this ModelBuilder builder)
        {
            builder.Entity<Medal>(m =>
            {
                m.HasOne(x => x.Dog).WithMany(x => x.Medals).HasForeignKey(x => x.DogId);
            });
        }

        private static void CreateTable_Expert(this ModelBuilder builder)
        {
            builder.Entity<Expert>(ex =>
            {
                ex.HasIndex(nameof(Expert.Surname), nameof(Expert.FirstName), nameof(Expert.ClubId)).IsUnique();
            });
        }

        private static void CreateTable_Ring(this ModelBuilder builder)
        {
            builder.Entity<Ring>(r =>
            {
                r.HasIndex(x => x.Number).IsUnique();
            });
        }

        private static void CreateTable_RingDogExpert(this ModelBuilder builder)
        {
            builder.Entity<RingDogExpert>(rde =>
            {
                rde.HasIndex(nameof(RingDogExpert.RingId), nameof(RingDogExpert.DogId), nameof(RingDogExpert.ExpertId));
                rde.HasOne(x => x.Ring).WithMany(x => x.Rdes).HasForeignKey(x => x.RingId);
                rde.HasOne(x => x.Dog).WithMany(x => x.Rdes).HasForeignKey(x => x.DogId);
                rde.HasOne(x => x.Expert).WithMany(x => x.Rdes).HasForeignKey(x => x.ExpertId);
                rde.ToTable("ring_dog_expert");
            });
        }
    }
}
