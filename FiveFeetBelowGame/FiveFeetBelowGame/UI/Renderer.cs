﻿// <copyright file="Renderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame.UI
{
      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Reflection;
      using System.Text;
      using System.Threading.Tasks;
      using System.Windows;
      using System.Windows.Media;
      using System.Windows.Media.Imaging;
      using FiveFeetBelowGame.VM;

      class Renderer
      {
            private GameModel model;

            private Drawing oldBackground;
            private Drawing oldMiddle;
            private Drawing oldRocks;
            private Drawing oldPlayer;
            private Point oldPlayerPosition;
            private Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();

            public Renderer(GameModel model)
            {
                  this.model = model;
            }

            public Brush PlayerBrush { get { return this.GetBrush("FiveFeetBelowGame.Images.player-idle-1.png", false); } }

            public Brush MonsterBrush { get { return this.GetBrush("FiveFeetBelowGame.Images.opossum-1.png", false); } }

            public Brush RockBrush { get { return Brushes.Brown; } }

            public Brush OreBrush { get { return this.GetBrush("FiveFeetBelowGame.Images.gem-1.png", false); } }

            public Brush Bgbrush { get { return this.GetBrush("FiveFeetBelowGame.Images.back.png", false); } }

            public Brush Middlebrush { get { return this.GetBrush("FiveFeetBelowGame.Images.middle.png", false); } }

            /// <summary>
            /// This method help us to start new game or reset our game.
            /// </summary>
            public void Reset()
            {
                  this.oldBackground = null;
                  this.oldMiddle = null;
                  this.oldRocks = null;
                  this.oldPlayer = null;
                  this.oldPlayerPosition = new Point(-1, -1);
                  this.brushes.Clear();
            }

            /// <summary>
            /// This method draws our items.
            /// </summary>
            /// <param name="fname">Image name from file.</param>
            /// <param name="isTiled">True if we have to use tiled brush.</param>
            /// <returns>Return a Brush.</returns>
            public Brush GetBrush(string fname, bool isTiled)
            {
                  // Maybe we can store Brush prop for each GameItem inherited class.
                  if (!this.brushes.ContainsKey(fname))
                  {
                        BitmapImage bmp = new BitmapImage();
                        bmp.BeginInit();
                        bmp.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);
                        bmp.EndInit();
                        ImageBrush ib = new ImageBrush(bmp);

                        if (isTiled)
                        {
                              ib.TileMode = TileMode.Tile;
                              ib.Viewport = new Rect(0, 0, this.model.TileSize, this.model.TileSize);
                              ib.ViewboxUnits = BrushMappingMode.Absolute;
                        }

                        this.brushes.Add(fname, ib);
                  }

                  return this.brushes[fname];
            }

            /// <summary>
            /// This method fill our drawing context.
            /// </summary>
            /// <returns>Returns a Drawing.</returns>
            public Drawing BuildDrawing()
            {
                  DrawingGroup dg = new DrawingGroup();
                  dg.Children.Add(this.GetBackground());
                  dg.Children.Add(this.GetMiddle());
                  dg.Children.Add(this.GetRocks());
                  dg.Children.Add(this.GetPlayer());

                  // dg.Children.Add(this.GetOres());
                  // dg.Children.Add(this.GetMonsters());
                  return dg;
            }

            // Maybe monsters should be an array.
            private Drawing GetMonsters()
            {
                  throw new NotImplementedException();
            }

            // Maybe ores should be an array.
            private Drawing GetOres()
            {
                  throw new NotImplementedException();
            }

            private Drawing GetPlayer()
            {
                  if (this.oldPlayer == null || this.oldPlayerPosition != this.model.Player)
                  {
                        Geometry g = new RectangleGeometry(new Rect(this.model.Player.X * this.model.TileSize, this.model.Player.Y * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                        this.oldPlayer = new GeometryDrawing(this.PlayerBrush, null, g);

                        this.oldPlayerPosition = this.model.Player;
                  }

                  return this.oldPlayer;
            }

            private Drawing GetRocks()
            {
                  if (this.oldRocks == null)
                  {
                        GeometryGroup g = new GeometryGroup();
                        for (int x = 0; x < this.model.Blocks.GetLength(1); x++)
                        {
                              for (int y = 0; y < this.model.Blocks.GetLength(0); y++)
                              {
                                    if (this.model.Blocks[y, x] != null &&
                                        (this.model.Blocks[y, x] as OnePlayer) == null &&
                                        (this.model.Blocks[y, x] as OneBlock).Type == BlockType.Rock)
                                    {
                                          Geometry box = new RectangleGeometry(new Rect( x * this.model.TileSize,  y * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                                          g.Children.Add(box);
                                    }
                              }
                        }

                        this.oldRocks = new GeometryDrawing(this.RockBrush, null, g);
                  }

                  return this.oldRocks;
            }

            private Drawing GetBackground()
            {
                  if (this.oldBackground == null)
                  {
                        Geometry g = new RectangleGeometry(new Rect(0, 0, this.model.GameWidth, this.model.GameHeight));
                        this.oldBackground = new GeometryDrawing(this.Bgbrush, null, g);
                  }

                  return this.oldBackground;
            }

            private Drawing GetMiddle()
            {
                  if (this.oldMiddle == null)
                  {
                        Geometry g = new RectangleGeometry(new Rect(0, 0, this.model.GameWidth, this.model.GameHeight));
                        this.oldMiddle = new GeometryDrawing(this.Middlebrush, null, g);
                  }

                  return this.oldMiddle;
            }
      }
}
