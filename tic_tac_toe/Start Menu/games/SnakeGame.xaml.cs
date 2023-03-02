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

namespace tic_tac_toe
{
    /// <summary>
    /// Interaction logic for SnakeGame.xaml
    /// </summary>
    public partial class SnakeGame : Window
    {
        public SnakeGame()
        {
            InitializeComponent();
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChoosingGame back = new ChoosingGame();
            back.Show();
        }
    }
}
