// <copyright file="HighscoreContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
[assembly: System.CLSCompliant(false)]

namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Model;

    /// <summary>
    /// The context class for the highscores.
    /// </summary>
    public class HighscoreContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HighscoreContext"/> class.
        /// </summary>
        /// <param name="opt">The db context options. </param>
        public HighscoreContext(DbContextOptions<HighscoreContext> opt)
            : base(opt)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HighscoreContext"/> class.
        /// </summary>
        public HighscoreContext()
        {
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets the dbset of highscores.
        /// </summary>
        public DbSet<Highscore> Highscores { get; set; }

        /// <summary>
        /// Configures the database.
        /// </summary>
        /// <param name="optionsBuilder">Requires a dbcontext option builder by default.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder is null)
            {
                throw new ArgumentNullException(nameof(optionsBuilder));
            }

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseLazyLoadingProxies().
                    UseSqlServer(@"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\HighscoreDB.mdf;integrated security=True;MultipleActiveResultSets=True");
            }
        }

        /// <summary>
        /// Configures the database.
        /// </summary>
        /// <param name="modelBuilder">Requires a dbcontext model builder by default.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
