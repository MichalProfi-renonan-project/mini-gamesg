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
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Maximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }

        }

        private void Button_Minimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void Button_hadik_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SnakeGame snkGame = new SnakeGame();
            snkGame.Show();
        }

        private void Button_Pong_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            PongGame pong = new PongGame();
            pong.Show();
        }
    }
}
