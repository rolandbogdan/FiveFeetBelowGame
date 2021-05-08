// <copyright file="GameControl.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Threading;
    using FiveFeetBelowGame.BL;
    using FiveFeetBelowGame.VM;

    /// <summary>
    /// GameControl class for the game.
    /// </summary>
    public class GameControl : FrameworkElement
    {
        /// <summary>
        /// An instance of the descendant class.
        /// </summary>
        private GameLogic logic;

        /// <summary>
        /// An instance of the descendant class.
        /// </summary>
        private Renderer renderer;

        /// <summary>
        /// An instance of the descendant class.
        /// </summary>
        private GameModel model;

        /// <summary>
        /// An instance of the descendant class.
        /// </summary>
        private DispatcherTimer tickTimer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameControl"/> class.
        /// </summary>
        public GameControl()
        {
            this.Loaded += this.GameControl_Loaded;
        }

        /// <inheritdoc/>
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (this.renderer != null)
            {
                drawingContext?.DrawDrawing(this.renderer.BuildDrawing());
            }
        }

        private void GameControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.model = new GameModel(this.ActualWidth, this.ActualHeight);

            if (string.IsNullOrEmpty(GlobalVariables.GamefilePath))
            {
                GlobalVariables.GameLoad = false;
                this.logic = new GameLogic(this.model, "testfile.json");
            }
            else
            {
                GlobalVariables.GameLoad = true;
                this.logic = new GameLogic(this.model, GlobalVariables.GamefilePath);
            }

            this.model = this.logic.Model;
            ;
            this.renderer = new Renderer(this.model);
            ;
            Window win = Window.GetWindow(this);
            if (win != null)
            {
                this.tickTimer = new DispatcherTimer();
                this.tickTimer.Interval = TimeSpan.FromMilliseconds(40); // fps?
                this.tickTimer.Tick += this.TickTimer_Tick;
                this.tickTimer.Start();

                win.KeyDown += this.Win_KeyDown;
                this.MouseDown += this.GameControl_MouseDown;
            }

            this.InvalidateVisual();
        }

        private void GameControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePos = e.GetPosition(this);
            Point tilePos = this.logic.GetTilePos(mousePos);

            int tpx = (int)tilePos.X;
            int tpy = (int)tilePos.Y;

            if (tpx < this.model.Blocks.GetLength(0) &&
                tpy < this.model.Blocks.GetLength(1) &&
                this.model.Blocks[tpx, tpy] != null &&
                this.model.Player != null &&
                this.logic.IsNeighboring(tpx, tpy))
            {
                this.model.Blocks[tpx, tpy].DamageTaken(
                this.model.Player.InflictDamage(),
                this.model.Player);
                if (this.model.Blocks[tpx, tpy].HealthPoints <= 0)
                {
                    if (this.model.Blocks[tpx, tpy] as OneBlock != null)
                    {
                        this.logic.PlayerGainedMoney((this.model.Blocks[tpx, tpy] as OneBlock).Value);
                    }
                    else if (this.model.Blocks[tpx, tpy] as OneMonster != null)
                    {
                        this.logic.PlayerGainedMoney((this.model.Blocks[tpx, tpy] as OneMonster).Value);
                    }

                    this.model.Blocks[tpx, tpy] = new OneBlock(tpx, tpy, BlockType.Air);
                }
            }
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            this.model.Blocks = this.logic.GetRenderedBlocks();
            this.logic.Gravity();
            this.logic.CheckIfHighscore();
            this.InvalidateVisual();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            bool isPaused = false;

            switch (e.Key)
            {
                case System.Windows.Input.Key.W:
                    if (!isPaused)
                    {
                        this.logic.Move(0, -1);
                    }

                    break;
                case System.Windows.Input.Key.S:
                    if (!isPaused)
                    {
                        this.logic.Move(0, 1);
                    }

                    break;
                case System.Windows.Input.Key.A:
                    if (!isPaused)
                    {
                        this.logic.Move(-1, 0);
                    }

                    break;
                case System.Windows.Input.Key.D:
                    if (!isPaused)
                    {
                        this.logic.Move(1, 0);
                    }

                    break;
                case Key.Escape:
                    if (MessageBox.Show("Are you sure?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        MainWindow mw = new MainWindow();
                        Window win = Window.GetWindow(this);

                        this.logic.SaveGame($"{DateTime.Now.ToString()}.json");

                        win.Close();
                        mw.Show();
                    }

                    break;
                default:
                    break;
            }

            this.InvalidateVisual();
        }
    }
}
