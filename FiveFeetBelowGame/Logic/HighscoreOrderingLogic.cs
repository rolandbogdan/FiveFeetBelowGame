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

        /// <summary>
        /// Initializes a new instance of the <see cref="HighscoreOrderingLogic"/> class.
        /// </summary>
        /// <param name="hsRepo">The repository.</param>
        public HighscoreOrderingLogic(IStorageRepository<Highscore> hsRepo)
        {
            this.highscoreRepo = hsRepo;
        }

        /// <summary>
        /// Orders the highscores by deepest poitn reached.
        /// </summary>
        /// <returns>The ordered list of highscores.</returns>
        public IEnumerable<Highscore> OrderedByDepth()
        {
            var ordered = from highscore in this.highscoreRepo.GetAll().ToList()
                          orderby highscore.DeepestPoint descending
                          select highscore;
            return ordered;
        }

        /// <summary>
        /// Orders the highscores by deepest poitn reached.
        /// </summary>
        /// <returns>The ordered list of highscores.</returns>
        public IEnumerable<Highscore> OrderedByMoney()
        {
            var ordered = from highscore in this.highscoreRepo.GetAll().ToList()
                          orderby highscore.DeepestPoint descending
                          select highscore;
            return ordered;
        }
    }
}
