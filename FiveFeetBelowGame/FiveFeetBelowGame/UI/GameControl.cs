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
            /// Initializes a new instance of the <see cref="GameControl"/> class.
            /// </summary>
            public GameControl()
            {
                  this.Loaded += this.GameControl_Loaded;
            }

            private void GameControl_Loaded(object sender, RoutedEventArgs e)
            {
                  this.model = new GameModel(this.ActualWidth, this.ActualHeight);
                  this.logic = new GameLogic(this.model, "This is the map of the game");
                  this.renderer = new Renderer(this.model);

                  Window win = Window.GetWindow(this);
                  if (win != null)
                  {
                        win.KeyDown += this.Win_KeyDown;
                        this.MouseDown += this.GameControl_MouseDown;
                  }

                  this.InvalidateVisual();
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                  if (this.renderer != null)
                  {
                        drawingContext.DrawDrawing(this.renderer.BuildDrawing());
                  }
            }

            private void GameControl_MouseDown(object sender, MouseButtonEventArgs e)
            {
                  throw new NotImplementedException();
            }

            private void Win_KeyDown(object sender, KeyEventArgs e)
            {
                  throw new NotImplementedException();
            }
      }
}
