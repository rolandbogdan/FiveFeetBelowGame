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
    }
}
