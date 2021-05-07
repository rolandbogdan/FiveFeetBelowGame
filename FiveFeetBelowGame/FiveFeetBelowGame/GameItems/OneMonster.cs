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
            Random r = new Random();
            this.HealthPoints = r.Next(15);
            this.Value = r.Next(50);
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
                this.Value = other.Value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneMonster"/> class.
        /// </summary>
        public OneMonster()
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
        /// Gets or sets the value of killing this monster.
        /// </summary>
        public int Value { get; set; }

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
        public void DamageTaken(int dmg, IGameObject source)
        {
            this.HealthPoints -= dmg;
            if (this.HealthPoints <= 0)
            {
                this.IsDestroyed(source);
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
        public void IsDestroyed(IGameObject source)
        {
            // drop item, or add balance to player
        }
    }
}
