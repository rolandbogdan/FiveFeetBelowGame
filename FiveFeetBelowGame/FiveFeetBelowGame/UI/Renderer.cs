// <copyright file="Renderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame.UI
{
      using System;
      using System.Collections.Generic;
      using System.Globalization;
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
            private Drawing oldMonsters;
            private Drawing oldIrons;
            private Drawing oldDiamonds;
            private Drawing oldGolds;
            private Drawing oldGems;
            private Drawing oldRareGems;

            private Point oldPlayerPosition;
            private Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();

            public Renderer(GameModel model)
            {
                  this.model = model;
            }

            public Brush PlayerBrush { get { return this.GetBrush("FiveFeetBelowGame.Images.player-idle-1.png", false); } }

            // public Brush MonsterBrush { get { return this.GetBrush("FiveFeetBelowGame.Images.opossum-1.png", false); } }
            public Brush MonsterBrush { get { return Brushes.Blue; } }

            public Brush RockBrush { get { return this.GetBrush("FiveFeetBelowGame.Images.tile.png", true); } }

            public Brush AirBrush { get { return Brushes.Transparent; } }

            // public Brush OreBrush { get { return this.GetBrush("FiveFeetBelowGame.Images.gem-1.png", false); } }

            public Brush IronBrush { get { return Brushes.Gray; } }

            public Brush DiamondsBrush { get { return Brushes.Aqua; } }

            public Brush GoldBrush { get { return Brushes.Gold; } }

            public Brush GemBrush { get { return Brushes.Purple; } }

            public Brush RareGemBrush { get { return Brushes.BlanchedAlmond; } }

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
                  this.oldMonsters = null;
                  this.oldIrons = null;
                  this.oldDiamonds = null;
                  this.oldGolds = null;
                  this.oldGems = null;
                  this.oldRareGems = null;

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
                  this.Reset(); // optimize?
                  DrawingGroup dg = new DrawingGroup();
                  dg.Children.Add(this.GetBackground());
                  dg.Children.Add(this.GetMiddle());
                  dg.Children.Add(this.GetRocks());
                  dg.Children.Add(this.GetPlayer());
                  dg.Children.Add(this.GetMonsters());

                  dg.Children.Add(this.GetIrons());
                  dg.Children.Add(this.GetDiamonds());
                  dg.Children.Add(this.GetGolds());
                  dg.Children.Add(this.GetGems());
                  dg.Children.Add(this.GetRareGems());

                  dg.Children.Add(this.GetText());

                  // dg.Children.Add(this.GetOres());
                  return dg;
            }

            // Maybe monsters should be an array.
            private Drawing GetMonsters()
            {
                  if (this.oldMonsters == null)
                  {
                        GeometryGroup g = new GeometryGroup();
                        for (int x = 0; x < this.model.Blocks.GetLength(1); x++)
                        {
                              for (int y = 0; y < this.model.Blocks.GetLength(0); y++)
                              {
                                    if (this.model.Blocks[y, x] != null &&
                                        (this.model.Blocks[y, x] as OneMonster) != null)
                                    {
                                          Geometry box = new RectangleGeometry(new Rect(y * this.model.TileSize, x * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                                          g.Children.Add(box);
                                    }
                              }
                        }

                        this.oldMonsters = new GeometryDrawing(this.MonsterBrush, null, g);
                  }

                  return this.oldMonsters;
            }

            // Maybe ores should be an array.
            private Drawing GetIrons()
            {
                  if (this.oldIrons == null)
                  {
                        GeometryGroup i = new GeometryGroup();

                        for (int x = 0; x < this.model.Blocks.GetLength(1); x++)
                        {
                              for (int y = 0; y < this.model.Blocks.GetLength(0); y++)
                              {
                                    if (this.model.Blocks[y, x] != null &&
                                        (this.model.Blocks[y, x] as OneBlock) != null &&
                                        (this.model.Blocks[y, x] as OneBlock).Type == BlockType.Iron)
                                    {
                                          Geometry box = new RectangleGeometry(new Rect(y * this.model.TileSize, x * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                                          i.Children.Add(box);
                                    }
                              }
                        }

                        this.oldIrons = new GeometryDrawing(this.IronBrush, null, i);
                  }

                  return this.oldIrons;
            }

            private Drawing GetDiamonds()
            {
                  if (this.oldDiamonds == null)
                  {
                        GeometryGroup d = new GeometryGroup();

                        for (int x = 0; x < this.model.Blocks.GetLength(1); x++)
                        {
                              for (int y = 0; y < this.model.Blocks.GetLength(0); y++)
                              {
                                    if (this.model.Blocks[y, x] != null &&
                                        (this.model.Blocks[y, x] as OneBlock) != null &&
                                        (this.model.Blocks[y, x] as OneBlock).Type == BlockType.Diamond)
                                    {
                                          Geometry box = new RectangleGeometry(new Rect(y * this.model.TileSize, x * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                                          d.Children.Add(box);
                                    }
                              }
                        }

                        this.oldDiamonds = new GeometryDrawing(this.DiamondsBrush, null, d);
                  }

                  return this.oldDiamonds;
            }

            private Drawing GetGolds()
            {
                  if (this.oldGolds == null)
                  {
                        GeometryGroup g = new GeometryGroup();

                        for (int x = 0; x < this.model.Blocks.GetLength(1); x++)
                        {
                              for (int y = 0; y < this.model.Blocks.GetLength(0); y++)
                              {
                                    if (this.model.Blocks[y, x] != null &&
                                        (this.model.Blocks[y, x] as OneBlock) != null &&
                                        (this.model.Blocks[y, x] as OneBlock).Type == BlockType.Gold)
                                    {
                                          Geometry box = new RectangleGeometry(new Rect(y * this.model.TileSize, x * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                                          g.Children.Add(box);
                                    }
                              }
                        }

                        this.oldGolds = new GeometryDrawing(this.GoldBrush, null, g);
                  }

                  return this.oldGolds;
            }

            private Drawing GetGems()
            {
                  if (this.oldGems == null)
                  {
                        GeometryGroup g = new GeometryGroup();

                        for (int x = 0; x < this.model.Blocks.GetLength(1); x++)
                        {
                              for (int y = 0; y < this.model.Blocks.GetLength(0); y++)
                              {
                                    if (this.model.Blocks[y, x] != null &&
                                        (this.model.Blocks[y, x] as OneBlock) != null &&
                                        (this.model.Blocks[y, x] as OneBlock).Type == BlockType.Gem)
                                    {
                                          Geometry box = new RectangleGeometry(new Rect(y * this.model.TileSize, x * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                                          g.Children.Add(box);
                                    }
                              }
                        }

                        this.oldGems = new GeometryDrawing(this.GemBrush, null, g);
                  }

                  return this.oldGems;
            }

            private Drawing GetRareGems()
            {
                  if (this.oldRareGems == null)
                  {
                        GeometryGroup g = new GeometryGroup();

                        for (int x = 0; x < this.model.Blocks.GetLength(1); x++)
                        {
                              for (int y = 0; y < this.model.Blocks.GetLength(0); y++)
                              {
                                    if (this.model.Blocks[y, x] != null &&
                                        (this.model.Blocks[y, x] as OneBlock) != null &&
                                        (this.model.Blocks[y, x] as OneBlock).Type == BlockType.Gem)
                                    {
                                          Geometry box = new RectangleGeometry(new Rect(y * this.model.TileSize, x * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                                          g.Children.Add(box);
                                    }
                              }
                        }

                        this.oldRareGems = new GeometryDrawing(this.RareGemBrush, null, g);
                  }

                  return this.oldRareGems;
            }

            private Drawing GetText()
            {
                  FormattedText formattedText = new FormattedText(
                  this.model.PlayerBalance.ToString(),
                  CultureInfo.CurrentCulture,
                  FlowDirection.LeftToRight,
                  new Typeface("Arial"),
                  16,
                  Brushes.Black);

                  GeometryDrawing text = new GeometryDrawing(
                      null,
                      new Pen(Brushes.Black, 2),
                      formattedText.BuildGeometry(new Point(5, 5)));

                  return text;

            }

            private Drawing GetPlayer()
            {
                  if (this.oldPlayer == null || this.oldPlayerPosition != this.model.PlayerPos)
                  {
                        Geometry g = new RectangleGeometry(new Rect(this.model.PlayerPos.X * this.model.TileSize, this.model.PlayerPos.Y * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                        this.oldPlayer = new GeometryDrawing(this.PlayerBrush, null, g);

                        this.oldPlayerPosition = this.model.PlayerPos;
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
                                        (this.model.Blocks[y, x] as OneBlock) != null &&
                                        (this.model.Blocks[y, x] as OneBlock).Type == BlockType.Rock)
                                    {
                                          Geometry box = new RectangleGeometry(new Rect(y * this.model.TileSize, x * this.model.TileSize, this.model.TileSize, this.model.TileSize));
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
