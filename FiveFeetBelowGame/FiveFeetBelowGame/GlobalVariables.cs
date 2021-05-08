// <copyright file="GlobalVariables.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Repository;

    /// <summary>
    /// Contains global variables for the game.
    /// </summary>
    public static class GlobalVariables
    {
        /// <summary>
        /// Gets or sets the game file path.
        /// </summary>
        public static string GamefilePath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether we are loading a game or not.
        /// </summary>
        public static bool GameLoad { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether we can autosave or not.
        /// </summary>
        public static bool CanAutosave { get; set; }

        /// <summary>
        /// Gets or sets the name of the save.
        /// </summary>
        public static string SaveName { get; set; }

        /// <summary>
        /// Gets or sets the highscore repository.
        /// </summary>
        public static HighscoreRepo HsRepo { get; set; }

    }
}
