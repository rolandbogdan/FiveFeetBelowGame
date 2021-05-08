﻿// <copyright file="GlobalVariables.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
    }
}
