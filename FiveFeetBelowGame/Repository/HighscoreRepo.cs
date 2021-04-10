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
    using Model;

    /// <summary>
    /// The repository class for the highscores.
    /// </summary>
    public class HighscoreRepo : IStorageRepository<Highscore>
    {
        // private
        public void Delete(Highscore toDelete)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Highscore> GetAll()
        {
            throw new NotImplementedException();
        }

        public Highscore GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Highscore toInsert)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
