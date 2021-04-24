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
        public void Move(double horizontal, double vertical)
        {
            double px = this.model.Blocks[(int)this.model.Player.X, (int)this.model.Player.Y].CX;
            double py = this.model.Blocks[(int)this.model.Player.X, (int)this.model.Player.Y].CY;
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
            // Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);
            // StreamReader sr = new StreamReader(stream);
            JsonHandler jh = new JsonHandler();

                  // this.model.Blocks = jh.LoadMap("..\\..\\..\\Levels\\testingmap.json");
                  this.model.Blocks = jh.LoadMap("testfile.json");

                  // this.model.TileSize = this.model.GameWidth / 25;
                  this.model.TileSize = model.GameWidth/25;

            IGameObject[,] arr = new IGameObject[this.model.Blocks.GetLength(1), this.model.Blocks.GetLength(0)];
            for (int i = 0; i < this.model.Blocks.GetLength(0); i++)
            {
                for (int j = 0; j < this.model.Blocks.GetLength(1); j++)
                {
                    arr[j, i] = this.model.Blocks[i, j];
                }
            }

            this.model.Blocks = arr;

            foreach (var item in this.model.Blocks)
            {
                if ((item as OnePlayer) != null)
                {
                    this.model.Player = new Point(item.CX, item.CY);
                }
            }
        }

        /// <summary>
        /// Updates the player in the blocks array, and the player's point in the model.
        /// </summary>
        /// <param name="newX"> New x coordinate of the player. </param>
        /// <param name="newY"> new y coordinate of the player. </param>
        private void UpdatePlayer(double newX, double newY)
        {
            double oldX = this.model.Player.X;
            double oldY = this.model.Player.Y;
            if (newX >= 0 && newX < this.model.Blocks.GetLength(0) &&
                newY >= 0 && newY < this.model.Blocks.GetLength(1) &&
                this.model.Blocks[(int)newX, (int)newY] as OneBlock != null &&
                !(this.model.Blocks[(int)newX, (int)newY] as OneBlock).IsSolid)
            {
                this.model.Blocks[(int)newX, (int)newY] =
                    new OnePlayer(
                        this.model.Blocks[(int)oldX, (int)oldY] as OnePlayer)
                        { CX = newX, CY = newY };
                this.model.Blocks[(int)oldX, (int)oldY] = new OneBlock(oldX, oldY, BlockType.Air);
                this.model.Player = new Point(newX, newY);
            }
        }
    }
}