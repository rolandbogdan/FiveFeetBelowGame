// <copyright file="ProceduralGenerator.cs" company="PlaceholderCompany">
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
    /// Generates the map dynamically during the game.
    /// </summary>
    public class ProceduralGenerator
    {
        /// <summary>
        /// Generates the next 50 depth.
        /// </summary>
        /// <param name="level"> The path of the lvl file. </param>
        /// <param name="lastGeneratedRow"> The depth of the last generated row. </param>
        /// <param name="playerDepth"> The depth of the player. </param>
        public void GenerateNextSection(string level, int lastGeneratedRow, int playerDepth)
        {
            if (playerDepth + 50 > lastGeneratedRow)
            {
                StreamWriter sw = new StreamWriter(level, true);
                for (int i = 0; i < 50; i++)
                {
                    sw.WriteLine(this.RowGenerator());
                }
            }
        }

        /// <summary>
        /// Generates one row on the map.
        /// </summary>
        /// <returns>returns the certain row.</returns>
        public string RowGenerator()
        {
            Random r = new Random();
            int a = r.Next(100);
            string outp = "";
            for (int i = 0; i < 25; i++)
            {
                if (a < 90)
                {
                    outp += "r"; // rock
                }
                else if (a >= 90 && a <= 95)
                {
                    outp += "*"; // ore
                }
                else
                {
                    outp += " ";
                }
            }

            return outp;
        }
    }
}
