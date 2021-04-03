// <copyright file="IGameModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
[assembly: System.CLSCompliant(false)]

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The interface for the game's model.
    /// </summary>
    public interface IGameModel // <T> ???
    {
        /// <summary>
        /// Gets or sets the ID of the entity.
        /// </summary>
        string ID { get; set; }

        /// <summary>
        /// Gets or sets the X coordinate of the entity.
        /// </summary>
        int DX { get; set; }

        /// <summary>
        /// Gets or sets the Y coordinate of the entity.
        /// </summary>
        int DY { get; set; }

        /// <summary>
        /// Gets or sets the HP coordinate of the entity.
        /// </summary>
        int HealthPoints { get; set; } // Healthpoint class instead?
    }
}
