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
using System.Windows.Threading;

namespace tic_tac_toe
{
    /// <summary>
    /// Interaction logic for Survival.xaml
    /// </summary>
    public partial class Survival : Window
    {
        List<Rectangle> Enemies;
        
        private DispatcherTimer GameTimer = new DispatcherTimer();
        private DispatcherTimer ballSpawnTimer = new DispatcherTimer();
        private Random random = new Random();
        private bool UpKeyPressed, DownKeyPressed, LeftKeyPressed, RightKeyPressed;
        private float SpeedX = 8, SpeedY = 8;
        private int BallSpeedx = 8;
        private int BallSpeedy = 9;
        private int BallkSpeedx = 10;
        private int BallkSpeedy = 7;
        private int increment = 0;

        void ResetGame()
        {
            increment = 0;
            if (TimerLabel != null)
            {
                TimerLabel.Content = 0;
            }
        }

        public Survival()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            RunningField.Focus();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();
            ballSpawnTimer.Interval = TimeSpan.FromSeconds(5);
            ballSpawnTimer.Tick += BallSpawnTimer_Tick;
            ballSpawnTimer.Start();
        }

        private void BallSpawnTimer_Tick(object sender, EventArgs e)
        {
            // Create a new instance of the Ball rectangle
            Rectangle newBall = new Rectangle();
            newBall.Width = 40;
            newBall.Height = 40;
            newBall.Fill = Brushes.White;
            Canvas.SetLeft(newBall, random.Next(0, (int)RunningField.ActualWidth - (int)newBall.Width));
            Canvas.SetTop(newBall, random.Next(0, (int)RunningField.ActualHeight - (int)newBall.Height));
            newBall.Tag = "Enemy";
            RunningField.Children.Add(newBall);

            // Create a new instance of the BallKolega rectangle
            Rectangle newBallKolega = new Rectangle();
            newBallKolega.Width = 40;
            newBallKolega.Height = 40;
            newBallKolega.Fill = Brushes.White;
            Canvas.SetLeft(newBallKolega, random.Next(0, (int)RunningField.ActualWidth - (int)newBallKolega.Width));
            Canvas.SetTop(newBallKolega, random.Next(0, (int)RunningField.ActualHeight - (int)newBallKolega.Height));
            newBallKolega.Tag = "Enemy";
            RunningField.Children.Add(newBallKolega);

            
        }
        private void KeyBoardDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                UpKeyPressed = true;
            }
            if (e.Key == Key.A)
            {
                LeftKeyPressed = true;
            }
            if (e.Key == Key.S)
            {
                DownKeyPressed = true;
            }
            if (e.Key == Key.D)
            {
                RightKeyPressed = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = TimeSpan.FromSeconds(1);
            dt.Tick += dt_Tick;
            dt.Start();
        }

        private void dt_Tick(object sender, EventArgs e)
        {
            increment++;
            TimerLabel.Content = increment.ToString();
        }

        private void KeyBoardUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                UpKeyPressed = false;
            }
            if (e.Key == Key.A)
            {
                LeftKeyPressed = false;
            }
            if (e.Key == Key.S)
            {
                DownKeyPressed = false;
            }
            if (e.Key == Key.D)
            {
                RightKeyPressed = false;
            }
        }

        private void GameTick(object sender, EventArgs e)
        {
            if (LeftKeyPressed == true && Canvas.GetLeft(Survivor) > 0)
            {
                Canvas.SetLeft(Survivor, Canvas.GetLeft(Survivor) - SpeedX);
            }
            if (RightKeyPressed == true && Canvas.GetLeft(Survivor) + (Survivor.Width + 10) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(Survivor, Canvas.GetLeft(Survivor) + SpeedX);
            }

            if (UpKeyPressed == true && Canvas.GetTop(Survivor) > 0)
            {
                Canvas.SetTop(Survivor, Canvas.GetTop(Survivor) - SpeedY);
            }
            if (DownKeyPressed == true && Canvas.GetTop(Survivor) + (Survivor.Height - 20) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(Survivor, Canvas.GetTop(Survivor) + SpeedY);
            }


            Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) - BallSpeedx);

            if (Canvas.GetLeft(Ball) < 0 || Canvas.GetLeft(Ball) + (Ball.Width * 2) > Application.Current.MainWindow.Width)
            {
                BallSpeedx = -BallSpeedx;
            }

            Canvas.SetTop(Ball, Canvas.GetTop(Ball) - BallSpeedy);

            if (Canvas.GetTop(Ball) < 0 || Canvas.GetTop(Ball) + (Ball.Height * 2) > Application.Current.MainWindow.Height)
            {
                BallSpeedy = -BallSpeedy;
            }
            Canvas.SetLeft(BallKolega, Canvas.GetLeft(BallKolega) - BallkSpeedx);

            if (Canvas.GetLeft(BallKolega) < 0 || Canvas.GetLeft(BallKolega) + (BallKolega.Width * 2) > Application.Current.MainWindow.Width)
            {
                BallkSpeedx = -BallkSpeedx;
            }

            Canvas.SetTop(BallKolega, Canvas.GetTop(BallKolega) - BallkSpeedy);

            if (Canvas.GetTop(BallKolega) < 0 || Canvas.GetTop(BallKolega) + (BallKolega.Height * 2) > Application.Current.MainWindow.Height)
            {
                BallkSpeedy = -BallkSpeedy;
            }
            CheckCollisionWithBall();
        }

        

        private void CheckCollisionWithBall()
        {
            foreach (var Survivor in RunningField.Children.OfType<Rectangle>())
            {
                if ((string)Survivor.Tag == "User")
                {
                    Survivor.Stroke = Brushes.Black;

                    Rect ballHitBox = new Rect(Canvas.GetLeft(Ball), Canvas.GetTop(Ball), Ball.Width, Ball.Height);
                    Rect ballkHitBox = new Rect(Canvas.GetLeft(BallKolega), Canvas.GetTop(BallKolega), BallKolega.Width, BallKolega.Height);
                    Rect SurvivorHitBox = new Rect(Canvas.GetLeft(Survivor), Canvas.GetTop(Survivor), Survivor.Width, Survivor.Height);

                    if (ballHitBox.IntersectsWith(SurvivorHitBox))
                    {
                        MessageBox.Show("You DIED! Restart?");
                        BallSpeedx = -BallSpeedx;
                        BallSpeedy = -BallSpeedy;
                        ResetGame();
                    }
                    if (ballkHitBox.IntersectsWith(SurvivorHitBox))
                    {
                        MessageBox.Show("You DIED! Restart?");
                        BallkSpeedx = -BallkSpeedx;
                        BallkSpeedy = -BallkSpeedy;
                        ResetGame();
                    }

                }
            }
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChoosingGame back = new ChoosingGame();
            back.Show();

            GameTimer.Stop();
        }
    }
}
