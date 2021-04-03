// <copyright file="LevelGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame.BL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// This class generates the .lvl file for the game, for the renderer to draw later.
    /// This generates the first 1000 blocks, and the procedural generator class will generate the rest.
    /// </summary>
    public class LevelGenerator
    {
        private Random r = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="LevelGenerator"/> class.
        /// </summary>
        /// <param name="saveName">Filename.</param>
        public LevelGenerator(string saveName)
        {
            if (!saveName.EndsWith(".txt") || !saveName.EndsWith(".lvl"))
            {
                saveName += ".txt";
            }

            StreamWriter sw = new StreamWriter(saveName);
            ProceduralGenerator pg = new ProceduralGenerator();

            for (int i = 0; i < 1000; i++)
            {
                sw.WriteLine(pg.RowGenerator());
            }
        }

    }
}
