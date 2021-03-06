// <copyright file="OneBlock.cs" company="PlaceholderCompany">
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
    /// An ore block element.
    /// </summary>
    public class OneBlock : IGameObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OneBlock"/> class.
        /// </summary>
        /// <param name="x">X coordinate of the block.</param>
        /// <param name="y">Y coordinate of the block.</param>
        /// <param name="type">The type of the block.</param>
        public OneBlock(double x, double y, BlockType type)
        {
            this.CX = x;
            this.CY = y;
            this.Type = type;
            this.PropertySetter();

            // this.Area = new Geometry();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneBlock"/> class.
        /// </summary>
        public OneBlock()
        {
        }

        /// <summary>
        /// Gets or sets the type of the block.
        /// </summary>
        public BlockType Type { get; set; }

        /// <summary>
        /// Gets or sets the hardness of the block.
        /// </summary>
        public int Hardness { get; set; }

        /// <inheritdoc/>
        public Geometry Area { get; set; }

        /// <inheritdoc/>
        public double CX { get; set; }

        /// <inheritdoc/>
        public double CY { get; set; }

        /// <inheritdoc/>
        public int HealthPoints { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the block is breakable or not.
        /// </summary>
        public bool Breakable { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the block is solid or not.
        /// </summary>
        public bool IsSolid { get; set; }

        /// <summary>
        /// Gets or sets the value the player gets of the specific block.
        /// </summary>
        public int Value { get; set; }

        /// <inheritdoc/>
        public void DamageTaken(int dmg, IGameObject source)
        {
            if (this.Breakable)
            {
                this.HealthPoints -= dmg;
                if (this.HealthPoints <= 0)
                {
                    this.IsDestroyed(source);
                }
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
            // this.Type = BlockType.Air;
            // drop item, or add balance to player
        }

        /// <summary>
        /// Sets the properties of the object based on the type.
        /// </summary>
        private void PropertySetter()
        {
            Random r = new Random();
            switch (this.Type)
            {
                case BlockType.Rock:
                    this.Hardness = 1;
                    this.HealthPoints = 3;
                    this.Value = 0;
                    this.IsSolid = true;
                    this.Breakable = true;
                    break;
                case BlockType.Iron:
                    this.Hardness = 1;
                    this.HealthPoints = 3;
                    this.Value = 5;
                    this.IsSolid = true;
                    this.Breakable = true;
                    break;
                case BlockType.Gold:
                    this.Hardness = 2;
                    this.HealthPoints = 6;
                    this.Value = 10;
                    this.IsSolid = true;
                    this.Breakable = true;
                    break;
                case BlockType.Diamond:
                    this.Hardness = 3;
                    this.HealthPoints = 9;
                    this.Value = 25;
                    this.IsSolid = true;
                    this.Breakable = true;
                    break;
                case BlockType.Gem:
                    this.Hardness = 4;
                    this.HealthPoints = 21;
                    this.Value = r.Next(25, 75);
                    this.IsSolid = true;
                    this.Breakable = true;
                    break;
                case BlockType.RareGem:
                    this.Hardness = 5;
                    this.HealthPoints = 30;
                    this.Value = r.Next(100, 150);
                    this.IsSolid = true;
                    this.Breakable = true;
                    break;
                case BlockType.Wall:
                    this.HealthPoints = 100000;
                    this.Value = 0;
                    this.IsSolid = true;
                    this.Breakable = false;
                    break;
                case BlockType.Air:
                    this.Value = 0;
                    this.IsSolid = false;
                    this.Breakable = false;
                    break;
                default:
                    break;
            }
        }
    }
}
