﻿// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame.BL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using FiveFeetBelowGame.VM;

    /// <summary>
    /// GameLogic class for the logic of our game.
    /// </summary>
    public class GameLogic
    {
        /// <summary>
        /// GameModel type model, an instance of the descendant class.
        /// </summary>
        private GameModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// </summary>
        /// <param name="model">GameModel type parameter.</param>
        /// <param name="fname">String type parameter.</param>
        public GameLogic(GameModel model, string fname)
        {
            this.model = model;
            this.InitModel(fname);
        }

        /// <summary>
        /// Moves the player charecter.
        /// </summary>
        /// <param name="horizontal"> Horizontal speed. </param>
        /// <param name="vertical"> Vertical speed.</param>
        public void Move(int horizontal, int vertical)
        {
            if (horizontal != 0)
            {
                // model.Player.DX += horizontal; // talán így kéne majd
            }

            if (vertical != 0)
            {
                // model.Player.Dy += vertical; // talán így kéne majd
            }

            /*
            int newX = (int)(this.model.Player.X + dx);
            int newY = (int)(this.model.Player.Y + dy);
            if (newX >= 0 && newY >= 0 && newX < this.model.Blocks.GetLength(0)
                && this.model.Blocks[newX, newY].GetType().ToString() == "OneAir")
            {
                this.model.Player = new Point(newX, newY);
            }
            */
        }

        /// <summary>
        /// Gets the coordinates of where we clicked.
        /// </summary>
        /// <param name="mousePos">The point where the mouse is.</param>
        /// <returns>The point where we clicked as an object. </returns>
        public Point GetTilePos(Point mousePos) // Pixel position => Tile position
        {
            return new Point((int)(mousePos.X / this.model.TileSize), (int)(mousePos.Y / this.model.TileSize));
        }

        /// <summary>
        /// Gravity to be implemented.
        /// </summary>
        public void Gravity()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initmodel method for initialize our model.
        /// </summary>
        /// <param name="fname">String type parameter.</param>
        private void InitModel(string fname)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);
            StreamReader sr = new StreamReader(stream);
            List<string> lines = new List<string>();
            while (!sr.EndOfStream)
            {
                lines.Add(sr.ReadLine());
            }

            sr.Close();

            int width = lines[0].Length;
            int height = lines.Count;
            this.model.Blocks = new GameItem[width, height];
            this.model.TileSize = Math.Min(this.model.GameWidth / width, this.model.GameHeight / height);
            /*
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    char current = lines[y][x];
                    this.model.Blocks[x, y] = this.TextToItemConverter(current);
                    if (current == 'S')
                    {
                        this.model.Player = new Point(x, y);
                    }
                }
            } */
            int x = 0;
            foreach (string item in lines)
            {
                int z = item.Length;
                for (int y = 0; y < z; y++)
                {
                    this.model.Blocks[x, y] = this.TextToItemConverter(item[y]);
                    if (item[y] == 'S')
                    {
                        this.model.Player = new Point(x, y);
                    }
                }

                x++;
            }
        }

        /// <summary>
        /// Converts from the letters in the txt file to game items.
        /// </summary>
        /// <returns>Returns a type of gameitem. </returns>
        private GameItem TextToItemConverter(char c)
        {
            // need sg for walls
            if (c == 'r' || c == 'B')
            {
                return new OneRock();
            }
            else if (c != ' ')
            {
                return new OneOre(); // what ore
            }
            else
            {
                return null;
            }
        }
    }
}