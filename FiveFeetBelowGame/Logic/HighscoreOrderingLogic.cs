// <copyright file="HighscoreOrderingLogic.cs" company="PlaceholderCompany">
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
    /// Orders highscores.
    /// </summary>
    public class HighscoreOrderingLogic
    {
        private IStorageRepository<Highscore> highscoreRepo;

        public HighscoreOrderingLogic(IStorageRepository<Highscore> hsRepo)
        {
            this.highscoreRepo = hsRepo;
        }

        public IEnumerable<Highscore> OrderedByDepth()
        {
            var ordered = from highscore in this.highscoreRepo.GetAll().ToList()
                          orderby highscore.DeepestPoint descending
                          select highscore;
            return ordered;
        }
    }
}
