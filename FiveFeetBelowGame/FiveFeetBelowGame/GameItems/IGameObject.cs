// <copyright file="IOneBlock.cs" company="PlaceholderCompany">
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
    /// An interface for the objects in the game.
    /// </summary>
    public interface IGameObject
    {
        /// <summary>
        /// Gets or sets the area of the element.
        /// </summary>
        Geometry Area { get; set; }

        /// <summary>
        /// Gets or sets the central X coordinate of the element.
        /// </summary>
        public double CX { get; set; }

        /// <summary>
        /// Gets or sets the central Y coordinate of the element.
        /// </summary>
        public double CY { get; set; }

        /// <summary>
        /// Gets or sets the HP of the element.
        /// </summary>
        public int HealthPoints { get; set; }

        /// <summary>
        /// Decides if the element is colliding with another element or not.
        /// </summary>
        /// <param name="other"> The other element this one might collide with. </param>
        /// <returns> True if they collide. </returns>
        public bool IsCollision(IGameObject other);

        /// <summary>
        /// Subtracts damage from the health.
        /// </summary>
        /// <param name="dmg"> The damage the entity takes. </param>
        public void DamageTaken(int dmg);

        /// <summary>
        /// Kills the entity if hp is 0.
        /// </summary>
        void IsDestroyed();
    }
}
