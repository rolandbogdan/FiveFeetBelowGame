// <copyright file="HighscoreRepo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Model;

    /// <summary>
    /// The repository class for the highscores.
    /// </summary>
    public class HighscoreRepo : IStorageRepository<Highscore>
    {
        private HighscoreContext ctx = new HighscoreContext();

        /// <inheritdoc/>
        public void Save()
        {
            this.ctx.SaveChanges();
        }

        /// <inheritdoc/>
        public void Insert(Highscore toInsert)
        {
            this.ctx.Add(toInsert);
            this.Save();
        }

        /// <inheritdoc/>
        public void Delete(Highscore toDelete)
        {
            this.ctx.Highscores.Remove(toDelete);
            this.Save();
        }

        /// <inheritdoc/>
        public Highscore GetOne(string id)
        {
            return this.ctx.Highscores.FirstOrDefault(x => x.HsID == id);
        }

        /// <inheritdoc/>
        public IQueryable<Highscore> GetAll()
        {
            return this.ctx.Highscores.AsQueryable();
        }
    }
}
