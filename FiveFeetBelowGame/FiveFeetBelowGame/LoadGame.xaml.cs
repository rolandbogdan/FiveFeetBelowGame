// <copyright file="LoadGame.xaml.cs" company="PlaceholderCompany">
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
    /// Interaction logic for LoadGame.xaml .
    /// </summary>
    public partial class LoadGame : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoadGame"/> class.
        /// </summary>
        public LoadGame()
        {
            this.InitializeComponent();
        }

        private void Load_File(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".json";
            dlg.Filter = "Json File (*.json)|*.json";
            dlg.FileName = "*.json";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                Game mw = new Game(dlg.FileName);
                mw.Show();
                this.Close();
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();

            mw.Show();
            this.Close();
        }
    }
}
