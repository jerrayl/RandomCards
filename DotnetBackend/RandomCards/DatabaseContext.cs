using Microsoft.EntityFrameworkCore;
using RandomCards.Entities;

namespace RandomCards
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) :
            base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured) options.UseSqlite("Data Source=RandomCards.db");
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Alias> Aliases { get; set; }
        public DbSet<Entities.Attribute> Attributes { get; set; }
        public DbSet<AttributeValue> AttributeValues { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardModifier> CardModifiers { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<ClassTag> ClassTag { get; set; }
        public DbSet<Deck> Deck { get; set; }
        public DbSet<GameRoom> GameRooms { get; set; }
        public DbSet<Modifier> Modifiers { get; set; }
        public DbSet<ModifierTag> ModifierTags { get; set; }
        public DbSet<PlayerCard> PlayerCards { get; set; }
        public DbSet<PlayerSession> PlayerSessions { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Tag> Tags { get; set; }
    }
}
