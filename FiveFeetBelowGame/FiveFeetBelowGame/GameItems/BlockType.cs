// <copyright file="BlockType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FiveFeetBelowGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The ore types.
    /// </summary>
    public enum BlockType
    {
        /// <summary>
        /// Most common thing underground.
        /// </summary>
        Rock,

        /// <summary>
        /// First ore.
        /// </summary>
        Iron,

        /// <summary>
        /// Second ore.
        /// </summary>
        Gold,

        /// <summary>
        /// Third ore.
        /// </summary>
        Diamond,

        /// <summary>
        /// Forth ore.
        /// </summary>
        Gem,

        /// <summary>
        /// Final ore.
        /// </summary>
        RareGem,

        /// <summary>
        /// Undestructible borders of the map.
        /// </summary>
        Wall,

        /// <summary>
        /// Empty blocks.
        /// </summary>
        Air,
    }
}
