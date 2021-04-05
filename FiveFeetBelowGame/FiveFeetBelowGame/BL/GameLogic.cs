// <copyright file="GameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame.BL
{
      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Text;
      using System.Threading.Tasks;
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
            /// <param name="model">GameModel type parameter</param>
            /// <param name="fname">String type parameter.</param>
            public GameLogic(GameModel model, string fname)
            {
                  this.model = model;
                  this.InitModel(fname);
            }

            /// <summary>
            /// Initmodel method for initialize our model.
            /// </summary>
            /// <param name="fname">String type parameter.</param>
            private void InitModel(string fname)
            {
            }
      }
}
