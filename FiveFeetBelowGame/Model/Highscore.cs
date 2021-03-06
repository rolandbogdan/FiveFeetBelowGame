// <copyright file="Highscore.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The highscores of the game.
    /// </summary>
    public class Highscore
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Highscore"/> class.
        /// </summary>
        /// <param name="playername"> The name of the player. </param>
        /// <param name="deepestpoint"> The deepest point the player has reached. </param>
        /// <param name="pickaxelvl"> The level of the player's pickaxe. </param>
        /// <param name="balance"> The level of the player's balance. </param>
        public Highscore(string playername, int deepestpoint, int pickaxelvl, int balance)
        {
            this.HsID = Guid.NewGuid().ToString();
            this.PlayerName = playername;
            this.DeepestPoint = deepestpoint;
            this.PickaxeLvl = pickaxelvl;
            this.Balance = balance;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Highscore"/> class.
        /// </summary>
        public Highscore()
        {
        }

        /// <summary>
        /// Gets or sets the id of the highscore save.
        /// </summary>
        [Key]
        public string HsID { get; set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets the deepest point the player has reached.
        /// </summary>
        public int DeepestPoint { get; set; }

        /// <summary>
        /// Gets or sets the level of the player's pickaxe.
        /// </summary>
        public int PickaxeLvl { get; set; }

        /// <summary>
        /// Gets or sets the highscore balance.
        /// </summary>
        public int Balance { get; set; }
    }
}
