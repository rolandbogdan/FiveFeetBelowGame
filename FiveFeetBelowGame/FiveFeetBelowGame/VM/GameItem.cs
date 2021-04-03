// <copyright file="GameItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame.VM
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;
    using Model;

    /// <summary>
    /// Base of the game elements.
    /// </summary>
    public abstract class GameItem : IGameModel
    {
        /// <summary>
        /// The area of the element.
        /// </summary>
        protected Geometry area;

        /// <summary>
        /// Gets or sets the ID of the element.
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        /// Gets or sets the central X coordinate of the element.
        /// </summary>
        public double CX { get; set; }

        /// <summary>
        /// Gets or sets the central Y coordinate of the element.
        /// </summary>
        public double CY { get; set; }

        /// <summary>
        /// Gets or sets the X directional speed of the element.
        /// </summary>
        public int DX { get; set; }

        /// <summary>
        /// Gets or sets the Y directional speed of the element.
        /// </summary>
        public int DY { get; set; }

        /// <summary>
        /// Gets or sets the HP of the element.
        /// </summary>
        public int HealthPoints { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is dead or not.
        /// </summary>
        public bool IsDead { get; set; }

        /// <summary>
        /// Gets or sets the damage this entity can deal.
        /// </summary>
        public int Damage { get; set; }

        /// <summary>
        /// Decides if the element is colliding with another element or not.
        /// </summary>
        /// <param name="other"> The other element this one might collide with. </param>
        /// <returns> True if they collide. </returns>
        public bool IsCollision(GameItem other)
        {
            if (other != null)
            {
                return Geometry.Combine(this.area, other.area, GeometryCombineMode.Intersect, null).GetArea() > 0;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Subtracts damage from the health.
        /// </summary>
        /// <param name="dmg"> The damage the entity takes. </param>
        public void DamageInflicted(int dmg)
        {
            this.HealthPoints -= dmg;
            if (this.HealthPoints <= 0)
            {
                this.IsDestroyed();
            }
        }

        /// <summary>
        /// Kills the entity if hp is 0.
        /// </summary>
        protected virtual void IsDestroyed()
        {
            this.IsDead = true;
        }
    }
}
