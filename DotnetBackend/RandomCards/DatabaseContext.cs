using System;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Configuration;
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

        public DbSet<GameRoom> GameRooms { get; set; }
        public DbSet<PlayerSession> PlayerSessions { get; set; }

        public DbSet<Request> Requests { get; set; }
    }
}
