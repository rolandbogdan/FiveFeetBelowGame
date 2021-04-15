// <copyright file="OnePlayer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// OnePlayer represent our player class.
    /// </summary>
    public class OnePlayer : IGameObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnePlayer"/> class.
        /// </summary>
        /// <param name="cx">X coordinate. </param>
        /// <param name="cy">Y coordinate. </param>
        public OnePlayer(double cx, double cy)
        {
            this.CX = cx;
            this.CY = cy;
            this.HealthPoints = 3;
            this.PickaxeLvl = 1;
            this.Balance = 0;
            this.DeepestPointReached = (int)Math.Round(this.CY);

            // this.Area = new Geometry();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnePlayer"/> class.
        /// </summary>
        /// <param name="other">An object from which the properties will be copied.</param>
        public OnePlayer(OnePlayer other)
        {
            if (other != null)
            {
                this.CX = other.CX;
                this.CY = other.CY;
                this.HealthPoints = other.HealthPoints;
                this.PickaxeLvl = other.PickaxeLvl;
                this.Balance = other.Balance;
                this.DeepestPointReached = other.DeepestPointReached;

                // this.Area = other.Area;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OnePlayer"/> class.
        /// </summary>
        public OnePlayer()
        {

        }

        /// <inheritdoc/>
        public Geometry Area { get; set; }

        /// <inheritdoc/>
        public double CX { get; set; }

        /// <inheritdoc/>
        public double CY { get; set; }

        /// <inheritdoc/>
        public int HealthPoints { get; set; }

        /// <summary>
        /// Gets or sets the lvl of the player's pickaxe.
        /// </summary>
        public int PickaxeLvl { get; set; }

        /// <summary>
        /// Gets or sets the lvl of the player's pickaxe.
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// Gets or sets the lvl of the player's pickaxe.
        /// </summary>
        public int DeepestPointReached { get; set; }

        /// <summary>
        /// Calculates the damage to be inflicted based on the pickaxe level.
        /// </summary>
        /// <returns>Returns the damage to be infliced.</returns>
        public int InflictDamage()
        {
            switch (this.PickaxeLvl)
            {
                case 1: return 1;
                case 2: return 2;
                case 3: return 3;
                case 4: return 5;
                case 5: return 7;
                default: return 7 + (this.PickaxeLvl - 4); // Balance? Non linear myb?
            }
        }

        /// <inheritdoc/>
        public void DamageTaken(int dmg)
        {
            this.HealthPoints -= dmg;
            if (this.HealthPoints <= 0)
            {
                this.IsDestroyed();
            }
        }

        /// <inheritdoc/>
        public bool IsCollision(IGameObject other)
        {
            if (other != null)
            {
                return Geometry.Combine(
                    this.Area,
                    other.Area,
                    GeometryCombineMode.Intersect,
                    null).GetArea() > 0;
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public void IsDestroyed()
        {
            this.Area = null;

            // drop item, or add balance to player
        }
    }
}
