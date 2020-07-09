using CodePepperInterview.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CodePepperInterview.DAL.EF.Contexts
{
    public class UrfSampleContext : DbContext
    {
        public UrfSampleContext(DbContextOptions<UrfSampleContext> options) : base(options)
        {
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterFriend> CharacterFriends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, Name = "Luke Skywalker" },
                new Character { Id = 2, Name = "Darth Vader" },
                new Character { Id = 3, Name = "Han Solo" },
                new Character { Id = 4, Name = "Leia Organa", Planet = "Alderaan" },
                new Character { Id = 5, Name = "Wilhuff Tarkin", Planet = "Alderaan--" },
                new Character { Id = 6, Name = "C-3PO" },
                new Character { Id = 7, Name = "R2-D2" }
            );

            modelBuilder.Entity<CharacterFriend>().HasData(
                new CharacterFriend { RelatingCharacterId = 1, RelatedCharacterId = 2 },
                new CharacterFriend { RelatingCharacterId = 2, RelatedCharacterId = 1 },
                new CharacterFriend { RelatingCharacterId = 1, RelatedCharacterId = 3 },
                new CharacterFriend { RelatingCharacterId = 3, RelatedCharacterId = 1 }
            );

            modelBuilder.Entity<CharacterFriend>(entity =>
            {
                entity.HasKey(e => new { e.RelatingCharacterId, e.RelatedCharacterId });

                entity.HasOne(d => d.RelatedCharacter)
                    .WithMany(p => p.CharacterFriendRelatedCharacter)
                    .HasForeignKey(d => d.RelatedCharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterFriend_Characters");

                entity.HasOne(d => d.RelatingCharacter)
                    .WithMany(p => p.CharacterFriendRelatingCharacter)
                    .HasForeignKey(d => d.RelatingCharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterFriend_CharacterFriend");
            });
        }
    }
}