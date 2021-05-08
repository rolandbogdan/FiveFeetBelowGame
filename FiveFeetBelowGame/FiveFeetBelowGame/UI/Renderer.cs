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

    /// <summary>
    /// This class is responsible for rendering the game.
    /// </summary>
    public class Renderer
    {
        private GameModel model;
        private Drawing oldBackground;
        private Drawing oldMiddle;
        private Drawing oldRocks;
        private Drawing oldPlayer;
        private List<Drawing> oldMonsters;
        private List<Drawing> oldOres;
        private Point oldPlayerPosition;
        private Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Renderer"/> class.
        /// </summary>
        /// <param name="model">The gamemodel. </param>
        public Renderer(GameModel model)
        {
            this.model = model;
            this.Reset();
        }

        /// <summary>
        /// Gets the brush for the player.
        /// </summary>
        public Brush PlayerBrush
        {
            get
            {
                return this.GetBrush("FiveFeetBelowGame.Images.player-idle-1.png", false);
            }
        }

        /// <summary>
        /// Gets the brush for the monsters.
        /// </summary>
        public Brush MonsterBrush
        {
            get
            {
                return this.GetBrush("FiveFeetBelowGame.Images.opossum-1.png", false);
            }
        }

        /// <summary>
        /// Gets the brush for the rocks.
        /// </summary>
        public Brush RockBrush
        {
            get
            {
                return this.GetBrush("FiveFeetBelowGame.Images.tile.png", true);
            }
        }

        /// <summary>
        /// Gets the brush for the air blocks.
        /// </summary>
        public Brush AirBrush
        {
            get
            {
                return Brushes.Transparent;
            }
        }

        /// <summary>
        /// Gets the brush for iron ores.
        /// </summary>
        public Brush IronBrush
        {
            get
            {
                return Brushes.Gray;
            }
        }

        /// <summary>
        /// Gets the brush for gold ores.
        /// </summary>
        public Brush GoldBrush
        {
            get
            {
                return Brushes.Gold;
            }
        }

        /// <summary>
        /// Gets the brush for diamonds.
        /// </summary>
        public Brush DiaBrush
        {
            get
            {
                return Brushes.Aqua;
            }
        }

        /// <summary>
        /// Gets the brush for gems.
        /// </summary>
        public Brush GemBrush
        {
            get
            {
                return Brushes.Purple;
            }
        }

        /// <summary>
        /// Gets the brush for rare gems.
        /// </summary>
        public Brush RareGemBrush
        {
            get
            {
                return Brushes.BlanchedAlmond;
            }
        }

        /// <summary>
        /// Gets the brush for the background.
        /// </summary>
        public Brush Bgbrush
        {
            get
            {
                return this.GetBrush("FiveFeetBelowGame.Images.back.png", false);
            }
        }

        /// <summary>
        /// Gets the brush for the middle.
        /// </summary>
        public Brush Middlebrush
        {
            get
            {
                return this.GetBrush("FiveFeetBelowGame.Images.middle.png", false);
            }
        }

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
            this.oldOres = null;
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

            foreach (Drawing item in this.GetMonsters())
            {
                dg.Children.Add(item);
            }

            foreach (Drawing item in this.GetOres())
            {
                dg.Children.Add(item);
            }

            dg.Children.Add(this.GetText());

            return dg;
        }

        private List<Drawing> GetMonsters()
        {
            if (this.oldMonsters == null)
            {
                this.oldMonsters = new List<Drawing>();
                for (int x = 0; x < this.model.Blocks.GetLength(1); x++)
                {
                    for (int y = 0; y < this.model.Blocks.GetLength(0); y++)
                    {
                        if (this.model.Blocks[y, x] != null &&
                            (this.model.Blocks[y, x] as OneMonster) != null)
                        {
                            Geometry box = new RectangleGeometry(new Rect(y * this.model.TileSize, x * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                            this.oldMonsters.Add(new GeometryDrawing(this.MonsterBrush, null, box));
                        }
                    }
                }
            }

            return this.oldMonsters;
        }

        private List<Drawing> GetOres()
        {
            if (this.oldOres == null)
            {
                this.oldOres = new List<Drawing>();
                for (int x = 0; x < this.model.Blocks.GetLength(1); x++)
                {
                    for (int y = 0; y < this.model.Blocks.GetLength(0); y++)
                    {
                        Brush b = Brushes.Transparent;
                        if (this.model.Blocks[y, x] != null && (this.model.Blocks[y, x] as OneBlock) != null)
                        {
                            switch ((this.model.Blocks[y, x] as OneBlock).Type)
                            {
                                case BlockType.Iron:
                                    b = this.IronBrush;
                                    break;
                                case BlockType.Gold:
                                    b = this.GoldBrush;
                                    break;
                                case BlockType.Diamond:
                                    b = this.DiaBrush;
                                    break;
                                case BlockType.Gem:
                                    b = this.GemBrush;
                                    break;
                                case BlockType.RareGem:
                                    b = this.RareGemBrush;
                                    break;
                                case BlockType.Wall:
                                    b = Brushes.Brown;
                                    break;
                                default:
                                    break;
                            }
                        }

                        Geometry box = new RectangleGeometry(new Rect(y * this.model.TileSize, x * this.model.TileSize, this.model.TileSize, this.model.TileSize));
                        this.oldOres.Add(new GeometryDrawing(b, null, box));
                    }
                }
            }

            return this.oldOres;
        }

        private Drawing GetText()
        {
            string disp = $"Pickaxe lvl: {this.model.PlayerPickaxe}\t$: {this.model.PlayerBalance}\tDeepest point: {(this.model.Hs.DeepestPoint * 5) - 50} ft.\nHealth: {this.model.PlayerHealth}";
            FormattedText formattedText = new FormattedText(
            disp,
            CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            new Typeface("Arial"),
            28,
            Brushes.Black);

            GeometryDrawing text = new GeometryDrawing(
                Brushes.Black,
                new Pen(Brushes.Black, 1),
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
