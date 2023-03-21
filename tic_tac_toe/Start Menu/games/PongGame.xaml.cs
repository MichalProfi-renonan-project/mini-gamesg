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
using System.Windows.Threading;

namespace tic_tac_toe
{
    /// <summary>
    /// Interaction logic for PongGame.xaml
    /// </summary>
    public partial class PongGame : Window
    {
        private DispatcherTimer GameTimer = new DispatcherTimer();
        private float SpeedY = 6;
        private bool UpKeyPressed, DownKeyPressed, UpKeyPressed1, DownKeyPressed1;
        private int BallSpeedx = 7;
        private int BallSpeedy = 9;
        int score = 0;
        int score1 = 0;
        public PongGame()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            Pongscreen.Focus();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                UpKeyPressed = true;
            }
            if (e.Key == Key.O)
            {
                UpKeyPressed1 = true;
            }
            if (e.Key == Key.S)
            {
                DownKeyPressed = true;
            }
            if (e.Key == Key.L)
            {
                DownKeyPressed1 = true;
            }

        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                UpKeyPressed = false;
            }
            if (e.Key == Key.O)
            {
                UpKeyPressed1 = false;
            }
            if (e.Key == Key.S)
            {
                DownKeyPressed = false;
            }
            if (e.Key == Key.L)
            {
                DownKeyPressed1 = false;
            }
        }

        private void GameTick(object sender, EventArgs e)
        {
            

            if (UpKeyPressed == true && Canvas.GetTop(Player1) > 0)
            {
                Canvas.SetTop(Player1, Canvas.GetTop(Player1) - SpeedY);
            }
            if (DownKeyPressed == true && Canvas.GetTop(Player1) + (Player1.Height - 20) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(Player1, Canvas.GetTop(Player1) + SpeedY);
            }
            if (UpKeyPressed1 == true && Canvas.GetTop(Player2) > 0)
            {
                Canvas.SetTop(Player2, Canvas.GetTop(Player2) - SpeedY);
            }
            if (DownKeyPressed1 == true && Canvas.GetTop(Player2) + (Player2.Height - 20) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(Player2, Canvas.GetTop(Player2) + SpeedY);
            }

            Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) - BallSpeedx);
            if (Canvas.GetLeft(Ball) < 0)
            {
                BallSpeedx = -BallSpeedx;
                BallSpeedy = -BallSpeedy;
                MessageBox.Show("Player 2 wins!");
                ResetGame();
                
                score++;
                lblPongPlayer2.Content = "Player 2: " + score;
            }

            Canvas.SetRight(Ball, Canvas.GetRight(Ball) - BallSpeedx);
            if (Canvas.GetLeft(Ball) + (Ball.Width * 2) > Application.Current.MainWindow.Width)
            {
                BallSpeedx = -BallSpeedx;
                BallSpeedy = -BallSpeedy;
                MessageBox.Show("Player 1 wins!");
                ResetGame();
                score1++;
                lblPongPlayer1.Content = "Player 1: " + score1;
            }
            Canvas.SetTop(Ball, Canvas.GetTop(Ball) - BallSpeedy);
            if (Canvas.GetTop(Ball) < 0 || Canvas.GetTop(Ball) + (Ball.Height * 2) > Application.Current.MainWindow.Height)
            {
                BallSpeedy = -BallSpeedy;
            }

            var x = Canvas.GetLeft(Ball);
            var y = Canvas.GetTop(Ball);
            
            if (x + Ball.Width >= Pongscreen.ActualWidth - (Canvas.GetRight(Player2) + Player2.Width)
                && y + Player2.Width >= Canvas.GetTop(Player2)
                && y + Ball.Height <= Canvas.GetTop(Player2) + Player2.Height)
            {
                BallSpeedx = -BallSpeedx;
            }
            

            foreach (var Player1 in Pongscreen.Children.OfType<Rectangle>())
            {
                if ((string)Player1.Tag == "Hrac1")
                {
                    Player1.Stroke = Brushes.Black;

                    Rect ballHitBox = new Rect(Canvas.GetLeft(Ball), Canvas.GetTop(Ball), Ball.Width, Ball.Height);
                    Rect PlayerHitBox = new Rect(Canvas.GetLeft(Player1), Canvas.GetTop(Player1), Player1.Width, Player1.Height);

                    if (ballHitBox.IntersectsWith(PlayerHitBox))
                    {
                        BallSpeedx = -BallSpeedx;
                    }

                }
            }

        }
        void ResetGame()
        {
            

            Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) - BallSpeedx);
            if (Canvas.GetLeft(Ball) < 0 || Canvas.GetLeft(Ball) + (Ball.Width * 2) > Application.Current.MainWindow.Width)
            {
                BallSpeedx = -BallSpeedx;
                BallSpeedy = -BallSpeedy;
            }
            Canvas.SetRight(Ball, Canvas.GetRight(Ball) - BallSpeedx);
            if (Canvas.GetRight(Ball) < 0 || Canvas.GetRight(Ball) + (Ball.Width * 2) > Application.Current.MainWindow.Width)
            {
                BallSpeedx = -BallSpeedx;
                BallSpeedy = -BallSpeedy;
            }
            Canvas.SetTop(Ball, Canvas.GetTop(Ball) - BallSpeedy);
            if (Canvas.GetTop(Ball) < 0 || Canvas.GetTop(Ball) + (Ball.Height * 2) > Application.Current.MainWindow.Height)
            {
                BallSpeedy = -BallSpeedy;
            }

        }

    
        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
           ChoosingGame back = new ChoosingGame();
           back.Show();
           GameTimer.Stop();
            GameTimer = null;
           score = 0;
           lblPongPlayer2.Content = "Player 2: " + score; 
           score1 = 0;
           lblPongPlayer1.Content = "Player 1: " + score1;
        }
        
    }
}
