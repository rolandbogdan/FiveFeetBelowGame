// <copyright file="GameLogic.cs" company="PlaceholderCompany">
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
                this.model.Player.DX += horizontal; // talán így kéne majd
            }

            if (vertical != 0)
            {
                this.model.Player.DY += vertical; // talán így kéne majd
            }

            this.model.Player.CX += this.model.Player.DX;
            this.model.Player.CY += this.model.Player.DY;

            /*
            int newX = (int)(this.model.Player.X + dx);
            int newY = (int)(this.model.Player.Y + dy);
            if (newX >= 0 && newY >= 0 && newX < this.model.Blocks.GetLength(0)
                && this.model.Blocks[newX, newY].GetType().ToString() == "OneAir")
            {
                this.model.Player = new Point(newX, newY);
            }
            */
            if (!this.SolidBlockUnderPlayer())
            {
                this.Gravity();
            }
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
        private void Gravity()
        {
            this.model.Player.DY += 5; // balance?
        }

        /// <summary>
        /// Initmodel method for initialize our model.
        /// </summary>
        /// <param name="fname">String type parameter.</param>
        private void InitModel(string fname)
        {
            // Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);
            // StreamReader sr = new StreamReader(stream);
            StreamReader sr = new StreamReader("..\\..\\..\\Levels\\map.lvl");
            List<string> lines = new List<string>();
            while (!sr.EndOfStream)
            {
                lines.Add(sr.ReadLine());
            }

            sr.Close();

            int height = lines.Count;
            int width = lines[0].Length;
            this.model.Blocks = new GameItem[height, width];
            this.model.TileSize = (double)(this.model.GameWidth / 25);
            int x = 0;
            foreach (string item in lines)
            {
                int z = item.Length;
                for (int y = 0; y < z; y++)
                {
                    if (item[y] == 'P')
                    {
                        this.model.Player = new OnePlayer(new Point(x, y));
                    }

                    this.model.Blocks[x, y] = this.TextToItemConverter(item[y], x, y);
                }

                x++;
            }
        }

        /// <summary>
        /// Converts from the letters in the txt file to game items.
        /// </summary>
        /// <returns>Returns a type of gameitem. </returns>
        private GameItem TextToItemConverter(char c, int x, int y)
        {
            // need sg for walls
            if (c == 'r' || c == 'B')
            {
                return new OneRock(x, y);
            }
            else if (c != ' ')
            {
                return new OneOre(x, y, this.OreTypeSelecter(c)); // TODO what ore
            }
            else
            {
                return new OneAir();
            }
        }

        private OreType OreTypeSelecter(char c)
        {
            switch (c)
            {
                case 'i': return OreType.Iron;
                case 'g': return OreType.Gold;
                case 'd': return OreType.Diamond;
                case '+': return OreType.Gem;
                case '*': return OreType.RareGem;
                default: return OreType.Rock;
            }
        }

        private bool SolidBlockUnderPlayer()
        {
            int x = (int)Math.Round(this.model.Player.CX);
            int y = (int)Math.Round(this.model.Player.CY);
            if (this.model.Blocks[x, y - 1].IsSolid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}