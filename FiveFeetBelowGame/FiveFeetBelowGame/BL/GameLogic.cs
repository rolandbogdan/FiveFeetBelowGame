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
        /// Determines the blocks that are rendered.
        /// </summary>
        /// <param name="x">X coordinate of the player.</param>
        /// <param name="y">Y coordinate of the player.</param>
        /// <returns>An array with the blocks.</returns>
        public IGameObject[,] GetRenderedBlocks()
        {
            int y = this.model.PlayerDepth;
            int d = (int)(this.model.GameHeight / this.model.TileSize) + 1;
            int n = y - (y % d);
            int k = 0;
            IGameObject[,] outp = new IGameObject[25, d];

            int s = n / d;
            if (this.model.PlayerDepth == d - 1)
            {
                s++;
            }

            if (this.model.PlayerPos.X == 0 && this.model.SectionNumber != 0)
            {
                s--;
            }

            if (s != this.model.SectionNumber)
            {
                if (s < this.model.SectionNumber)
                {
                    this.model.SectionNumber--;
                    this.UpdatePlayerPosOnly(this.model.PlayerPos.X, d);
                }
                else
                {
                    this.model.SectionNumber++;
                    this.UpdatePlayerPosOnly(this.model.PlayerPos.X, 1);
                }

                for (int i = 0; i < outp.GetLength(0); i++)
                {
                    // this.model.Blocks[i, this.model.PlayerDepth - 1] = new OneBlock(i, this.model.PlayerDepth, BlockType.Air);
                    this.model.Blocks[i, this.model.PlayerDepth] = new OneBlock(i, this.model.PlayerDepth, BlockType.Air);
                }

                y = this.model.PlayerDepth;
                n = y - (y % d);
            }

            for (int i = n; i < n + d; i++)
            {
                for (int j = 0; j < outp.GetLength(0); j++)
                {
                    outp[j, k] = this.model.Blocks[j, i];
                }

                if (k < d - 1)
                {
                    k++;
                }
            }

            if (this.model.Blocks.GetLength(1) - 100 < this.model.PlayerDepth)
            {
                // generate new section.
            }

            return outp;
        }

        /// <summary>
        /// Moves the player charecter.
        /// </summary>
        /// <param name="horizontal"> Horizontal speed. </param>
        /// <param name="vertical"> Vertical speed.</param>
        public void Move(double horizontal, double vertical)
        {
            double px = this.model.PlayerPos.X;
            double py = this.model.PlayerPos.Y;
            double dx = 0;
            double dy = 0;

            if (horizontal != 0)
            {
                // (this.model.Blocks[px, py] as OnePlayer).DX += horizontal;
                dx += horizontal;
            }

            if (vertical != 0)
            {
                // (this.model.Blocks[px, py] as OnePlayer).DY += vertical;
                dy += vertical;
            }

            double newX = px + dx;
            double newY = py + dy;
            this.UpdatePlayer(newX, newY);
        }

        /// <summary>
        /// Gets the coordinates of where we clicked.
        /// </summary>
        /// <param name="mousePos">The point where the mouse is.</param>
        /// <returns>The point where we clicked as an object. </returns>
        public Point GetTilePos(Point mousePos) // Pixel position => Tile position
        {
            return new Point(mousePos.X / this.model.TileSize, mousePos.Y / this.model.TileSize);
        }

        /// <summary>
        /// Gravity to be implemented.
        /// </summary>
        public void Gravity()
        {
            int px = (int)this.model.PlayerPos.X;
            int py = (int)this.model.PlayerPos.Y;

            // Something so player cant fly?
            if (py >= 0 && py < this.model.RenderedBlocks.GetLength(1) - 1)
            {
                if ((this.model.RenderedBlocks[px, py + 1] as OneBlock) != null &&
                !(this.model.RenderedBlocks[px, py + 1] as OneBlock).IsSolid)
                {
                    this.Move(0, 0.5);
                }
            }
        }

        /// <summary>
        /// Increases the player's balance.
        /// </summary>
        /// <param name="amount">By this amount.</param>
        public void PlayerGainedMoney(int amount)
        {
            this.model.PlayerBalance += amount;
        }

        /// <summary>
        /// Decreases the players health.
        /// </summary>
        /// <param name="amount">By this amount.</param>
        public void PlayerLostHealth(int amount)
        {
            this.model.PlayerHealth -= amount;
            if (this.model.PlayerHealth <= 0)
            {
                this.model.Blocks[(int)this.model.Player.CX, (int)this.model.Player.CY] = new OneBlock(this.model.Player.CX, this.model.Player.CY, BlockType.Air);
                this.model.Player.CX = 10;
                this.model.Player.CY = 10;
                this.model.PlayerBalance = 0;
                this.model.Blocks[10, 10] = this.model.Player;
                this.model.PlayerHealth = this.model.PlayerMaxHealth;
            }
        }

        /// <summary>
        /// Increases the players pickaxe's level by one.
        /// </summary>
        public void IncreasePickaxeLevel()
        {
            this.model.PlayerPickaxe++;
        }

        /// <summary>
        /// Increases the players health.
        /// </summary>
        /// <param name="amount">By this amount.</param>
        public void HealPlayer(int amount)
        {
            if (this.model.PlayerHealth + amount > this.model.PlayerMaxHealth)
            {
                this.model.PlayerHealth = this.model.PlayerMaxHealth;
            }
            else
            {
                this.model.PlayerHealth += amount;
            }
        }

        /// <summary>
        /// Determines if a certain block is neighboring the player or not.
        /// </summary>
        /// <param name="bx">The block's x coordinate.</param>
        /// <param name="by">The block's y coordinate. </param>
        /// <returns>True if its a neighboring block.</returns>
        public bool IsNeighboring(double bx, double by)
        {
            double xdiff = this.model.PlayerPos.X - bx;
            double ydiff = this.model.PlayerPos.Y - by;
            if (Math.Abs(xdiff) <= 1 && Math.Abs(ydiff) <= 1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Initmodel method for initialize our model.
        /// </summary>
        /// <param name="fname">String type parameter.</param>
        private void InitModel(string fname)
        {
            JsonHandler js = new JsonHandler("testfile.json");
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);

            // StreamReader sr = new StreamReader(stream);
            JsonHandler jh = new JsonHandler();

            // this.model.Blocks = jh.LoadMap("..\\..\\..\\Levels\\testingmap.json");
            this.model.Blocks = jh.LoadMap("testfile.json");

            this.model.TileSize = this.model.GameWidth / 25;

            IGameObject[,] arr = new IGameObject[this.model.Blocks.GetLength(1), this.model.Blocks.GetLength(0)];
            for (int i = 0; i < this.model.Blocks.GetLength(0); i++)
            {
                for (int j = 0; j < this.model.Blocks.GetLength(1); j++)
                {
                    arr[j, i] = this.model.Blocks[i, j];
                }
            }

            this.model.Blocks = arr;
            this.model.Blocks[10, 10] = new OneBlock(10, 10, BlockType.Air);
            this.model.Player = new OnePlayer(10, 10);
            this.model.PlayerPos = new Point(10, 10);
            this.model.RenderedBlocks = this.GetRenderedBlocks();
        }

        /// <summary>
        /// Updates the player in the blocks array, and the player's point in the model.
        /// </summary>
        /// <param name="newX"> New x coordinate of the player. </param>
        /// <param name="newY"> new y coordinate of the player. </param>
        private void UpdatePlayer(double newX, double newY)
        {
            // OPTIMIZE!!
            double oldX = this.model.PlayerPos.X;
            double oldY = this.model.PlayerPos.Y;

            if (newX >= 0 && newX < this.model.RenderedBlocks.GetLength(0) &&
                newY >= 0 && newY < this.model.RenderedBlocks.GetLength(1) &&
                (this.model.RenderedBlocks[(int)newX, (int)newY] as OneBlock) != null &&
                !(this.model.RenderedBlocks[(int)newX, (int)newY] as OneBlock).IsSolid)
            {
                this.model.Player.CX = newX;
                this.model.Player.CY = newX;
                this.model.PlayerPos = new Point(newX, newY);
            }
        }

        private void UpdatePlayerPosOnly(double newX, double newY)
        {
            this.model.PlayerPos = new Point(newX, newY);
        }
    }
}