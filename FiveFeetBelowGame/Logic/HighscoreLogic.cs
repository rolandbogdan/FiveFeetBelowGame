// <copyright file="HighscoreLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Logic
{
      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Text;
      using System.Threading.Tasks;
      using Model;
      using Repository;

      /// <summary>
      /// This class is represent the logc of the highscore.
      /// </summary>
      public class HighscoreLogic
      {
            private IStorageRepository<Highscore> highscoreRepo;

            /// <summary>
            /// Initializes a new instance of the <see cref="HighscoreLogic"/> class.
            /// </summary>
            /// <param name="highscoreRepo">IStorageRepository Highscore type parameter.</param>
            public HighscoreLogic(IStorageRepository<Highscore> highscoreRepo)
            {
                  this.highscoreRepo = highscoreRepo;
            }

            /// <summary>
            /// Save method to save a highscore.
            /// </summary>
            public void Save()
            {
                  this.highscoreRepo.Save();
            }

            /// <summary>
            /// Insert method to add a new highscore.
            /// </summary>
            /// <param name="hs">Highscore type parameter what we want to save.</param>
            public void Insert(Highscore hs)
            {
                  this.highscoreRepo.Insert(hs);
            }

            /// <summary>
            /// Delete method to delete a highscore.
            /// </summary>
            /// <param name="hs">Highscore type parameter what we want to delete.</param>
            public void Delete(Highscore hs)
            {
                  this.highscoreRepo.Delete(hs);
            }

            /// <summary>
            /// GetOneHighscore method to find one highscore by id.
            /// </summary>
            /// <param name="id">String type parameter what we want to find.</param>
            /// <returns>Return a highscore.</returns>
            public Highscore GetOneHighscore(string id)
            {
                  return this.highscoreRepo.GetOne(id);
            }

            /// <summary>
            /// GetAllHighscore to list all of the highscores.
            /// </summary>
            /// <returns>Returns an IQueryable Highscore type.</returns>
            public IQueryable<Highscore> GetAllHighscore()
            {
                  return this.highscoreRepo.GetAll();
            }
      }
}
