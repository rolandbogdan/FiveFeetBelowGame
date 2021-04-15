// <copyright file="OneMonster.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;

    /// <summary>
    /// A monster element.
    /// </summary>
    public class OneMonster : IGameObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneMonster"/> class.
        /// </summary>
        /// <param name="cx">X coordinate. </param>
        /// <param name="cy">Y coordinate. </param>
        public OneMonster(double cx, double cy)
        {
            this.CX = cx;
            this.CY = cy;
            this.HealthPoints = 3;

            // this.Area = new Geometry();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneMonster"/> class.
        /// </summary>
        /// <param name="other">An object from which the properties will be copied.</param>
        public OneMonster(OneMonster other)
        {
            if (other != null)
            {
                this.CX = other.CX;
                this.CY = other.CY;
                this.HealthPoints = other.HealthPoints;

                // this.Area = other.Area;
            }
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
        /// Calculates the damage to be inflicted based on the pickaxe level.
        /// </summary>
        /// <returns>Returns the damage to be infliced.</returns>
        public int InflictDamage()
        {
            if (this.CY <= 150)
            {
                return 2;
            }
            else if (this.CY > 300)
            {
                return 6 + (2 * ((int)this.CY - 300) / 100); // Balance?
            }
            else
            {
                return 4;
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
