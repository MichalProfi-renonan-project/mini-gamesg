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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class ChoosingGame : Window
    {
        public ChoosingGame()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

        }
        private void OnNavigateBackRequested(object sender, EventArgs e)
        {
            // Navigujte späť na Window
            this.Content = new ChoosingGame();
        }

        private void Button_tictactoe_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();
            Tictactoe tictactoe = new Tictactoe();
            tictactoe.Show();

        }

        private void Button_movesquare_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MovinS0v1n sov = new MovinS0v1n();
            sov.Show();
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow back = new MainWindow();
            back.Show();
        }
    }
}
