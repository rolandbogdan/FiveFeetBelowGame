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
      using FiveFeetBelowGame.VM;

      /// <summary>
      /// GameControl class for the game.
      /// </summary>
      public class GameControl : FrameworkElement
      {
            // GameLogic logic;

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
                  throw new NotImplementedException();
            }
      }
}
