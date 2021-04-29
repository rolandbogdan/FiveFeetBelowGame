﻿// <copyright file="GameControl.cs" company="PlaceholderCompany">
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
            this.logic = new GameLogic(this.model, "FiveFeetBelowGame.Levels.map.lvl");
            this.renderer = new Renderer(this.model);

            Window win = Window.GetWindow(this);
            if (win != null)
            {
                this.tickTimer = new DispatcherTimer();
                this.tickTimer.Interval = TimeSpan.FromMilliseconds(20); // fps?
                this.tickTimer.Tick += this.TickTimer_Tick;
                this.tickTimer.Start();

                win.KeyDown += this.Win_KeyDown;
                this.MouseDown += this.GameControl_MouseDown;
            }

            this.InvalidateVisual();
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            this.logic.OneTick();
            this.InvalidateVisual();
        }

        private void GameControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point mousePos = e.GetPosition(this);
            Point tilePos = this.logic.GetTilePos(mousePos);

            /* this.model.Blocks[(int)tilePos.X, (int)tilePos.Y] =
                new OneBlock(tilePos.X, tilePos.Y, BlockType.Air); */
            int px = (int)this.model.Player.X;
            int py = (int)this.model.Player.Y;
            if (this.model.Blocks[(int)tilePos.X, (int)tilePos.Y] != null &&
                (this.model.Blocks[px, py] as OnePlayer) != null)
            {
                // Only neighbouring blocks!
                this.model.Blocks[(int)tilePos.X, (int)tilePos.Y].DamageTaken(
                (this.model.Blocks[px, py] as OnePlayer).InflictDamage());
                if (this.model.Blocks[(int)tilePos.X, (int)tilePos.Y].HealthPoints <= 0)
                {
                    this.model.Blocks[(int)tilePos.X, (int)tilePos.Y] = new OneBlock((int)tilePos.X, (int)tilePos.Y, BlockType.Air);
                }
            }

            // this.logic.Gravity();
            this.InvalidateVisual();
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case System.Windows.Input.Key.W:
                    this.logic.Move(0, -1);
                    break;
                case System.Windows.Input.Key.S:
                    this.logic.Move(0, 1);
                    break;
                case System.Windows.Input.Key.A:
                    this.logic.Move(-1, 0);
                    break;
                case System.Windows.Input.Key.D:
                    this.logic.Move(1, 0);
                    break;
                default:
                    break;
            }

            this.InvalidateVisual();
        }
    }
}
