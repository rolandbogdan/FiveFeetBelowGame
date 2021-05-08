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
    using Model;
    using Repository;

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
            JsonHandler jh = new JsonHandler();
            HighscoreRepo hRepo = jh.GetHighscores();

            this.HRepoList = hRepo.GetAll().OrderByDescending(x => x.DeepestPoint).ToList();

            this.InitializeComponent();

            if (this.HRepoList.Count == 0)
            {
                MessageBox.Show("No highscores yeti!");
            }
            else
            {
                this.listBox.Items.Add("Save name\t Money\t\t Deepest point");
                foreach (var item in this.HRepoList)
                {
                    this.listBox.Items.Add($"{item.PlayerName}\t\t {item.Balance}\t\t {item.DeepestPoint}");
                }
            }
        }

        /// <summary>
        /// Gets the highscore repository.
        /// </summary>
        public List<Highscore> HRepoList { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
