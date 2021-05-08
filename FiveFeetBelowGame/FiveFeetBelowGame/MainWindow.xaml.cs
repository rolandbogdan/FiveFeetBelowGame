// <copyright file="MainWindow.xaml.cs" company="PlaceholderCompany">
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void New_Game(object sender, RoutedEventArgs e)
        {
            GlobalVariables.GameLoad = false;
            Game game = new Game();
            game.Show();
            this.Close();
        }

        private void Highscores(object sender, RoutedEventArgs e)
        {
            HighscoresWindow hsWindow = new HighscoresWindow();

            hsWindow.Show();
            this.Close();
        }

        private void Quit_Game(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Load_Game(object sender, RoutedEventArgs e)
        {
            LoadGame lg = new LoadGame();

            lg.Show();
            this.Close();
        }

        private void NameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GlobalVariables.SaveName = this.nameBox.Text;
        }
    }
}
