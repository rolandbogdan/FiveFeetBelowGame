// <copyright file="IGameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
[assembly: System.CLSCompliant(false)]

namespace Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The interface for the game logic.
    /// </summary>
    /// <typeparam name="T"> A type of object the logic deals with. </typeparam>
    public interface IGameLogic<T>
        where T : class
    {
        /// <summary>
        /// Refreshes the screen to draw the map around the player.
        /// </summary>
        event EventHandler ScreenUpdate;

        /// <summary>
        /// Triggers when an object is hit by either a player or a monster.
        /// </summary>
        event EventHandler ObjectHit;

        /// <summary>
        /// Triggers when any object's health points change.
        /// </summary>
        event EventHandler HealthUpdate;

        /// <summary>
        /// Triggers when there is no ground under a player/monster.
        /// </summary>
        event EventHandler ObjectFalling;
    }
}
