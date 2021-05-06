// <copyright file="HighscoresWindow.xaml.cs" company="PlaceholderCompany">
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
      /// Interaction logic for HighscoresWindow.xaml.
      /// </summary>
      public partial class HighscoresWindow : Window
      {
            /// <summary>
            /// Initializes a new instance of the <see cref="HighscoresWindow"/> class.
            /// </summary>
            public HighscoresWindow()
            {
                  this.InitializeComponent();
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                  MainWindow mw = new MainWindow();
                  mw.Show();
                  this.Close();
            }
      }
}
