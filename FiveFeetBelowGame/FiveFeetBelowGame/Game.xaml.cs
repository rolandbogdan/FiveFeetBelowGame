// <copyright file="Game.xaml.cs" company="PlaceholderCompany">
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
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for Game.xaml.
    /// </summary>
    public partial class Game : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        public Game()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        /// <param name="loadFilePath">The path to the loaded file.</param>
        public Game(string loadFilePath)
            : this()
        {
            this.LoadFile = loadFilePath;
            GlobalVariables.GamefilePath = this.LoadFile;
        }

        /// <summary>
        /// Gets or sets the path for file we load in.
        /// </summary>
        public string LoadFile { get; set; }
      }
}
