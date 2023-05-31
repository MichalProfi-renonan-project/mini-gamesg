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
    /// Interaction logic for Game2.xaml
    /// </summary>
    public partial class MovinS0v1n : Window
    {
        private DispatcherTimer GameTimer = new DispatcherTimer();
        DispatcherTimer _timer;
        TimeSpan _time;
        private DispatcherTimer ballSpawnTimer = new DispatcherTimer();
        private Random random = new Random();
        private int score = 1;
        DispatcherTimer timer = new DispatcherTimer();
        private bool UpKeyPressed, DownKeyPressed, LeftKeyPressed, RightKeyPressed;
        private float SpeedX = 6, SpeedY = 6;
        private int BoxSpeedx = 6;
        private int BoxSpeedy = 7;

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

        public MovinS0v1n()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            Gamescreen.Focus();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();
            ballSpawnTimer.Interval = TimeSpan.FromSeconds(5);
            ballSpawnTimer.Tick += BallSpawnTimer_Tick;
            ballSpawnTimer.Start();


            _time = TimeSpan.FromSeconds(60);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                LblTime.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero) _timer.Stop();
                _time = _time.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }



        private void BallSpawnTimer_Tick(object sender, EventArgs e)
        {
            // Create a new instance of the Ball rectangle
            Rectangle newBall = new Rectangle();
            newBall.Width = 40;
            newBall.Height = 40;
            newBall.Fill = Brushes.White;
            Canvas.SetLeft(newBall, random.Next(0, (int)Gamescreen.ActualWidth - (int)newBall.Width));
            Canvas.SetTop(newBall, random.Next(0, (int)Gamescreen.ActualHeight - (int)newBall.Height));
            newBall.Tag = "Enemy";
            Gamescreen.Children.Add(newBall);

            // Create a new instance of the BallKolega rectangle
            Rectangle newBallKolega = new Rectangle();
            newBallKolega.Width = 40;
            newBallKolega.Height = 40;
            newBallKolega.Fill = Brushes.White;
            Canvas.SetLeft(newBallKolega, random.Next(0, (int)Gamescreen.ActualWidth - (int)newBallKolega.Width));
            Canvas.SetTop(newBallKolega, random.Next(0, (int)Gamescreen.ActualHeight - (int)newBallKolega.Height));
            newBallKolega.Tag = "Enemy";
            Gamescreen.Children.Add(newBallKolega);


        }


        private void GameTick(object sender, EventArgs e)
        {
            if (LeftKeyPressed == true && Canvas.GetLeft(Player) > 0)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - SpeedX);
            }
            if (RightKeyPressed == true && Canvas.GetLeft(Player) + (Player.Width + 10) < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + SpeedX);
            }

            if (UpKeyPressed == true && Canvas.GetTop(Player) > 0)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) - SpeedY);
            }
            if (DownKeyPressed == true && Canvas.GetTop(Player) + (Player.Height - 20) < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) + SpeedY);
            }


        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChoosingGame back = new ChoosingGame();
            back.Show();
        }



    }
}
