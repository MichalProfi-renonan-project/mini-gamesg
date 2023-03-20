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



        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChoosingGame back = new ChoosingGame();
            back.Show();
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

            Canvas.SetLeft(Box, Canvas.GetLeft(Box) - BoxSpeedx);

            if (Canvas.GetLeft(Box) < 0 || Canvas.GetLeft(Box) + (Box.Width * 2) > Application.Current.MainWindow.Width)
            {
                BoxSpeedx = -BoxSpeedx;
            }

            Canvas.SetTop(Box, Canvas.GetTop(Box) - BoxSpeedy);

            if (Canvas.GetTop(Box) < 0 || Canvas.GetTop(Box) + (Box.Height * 2) > Application.Current.MainWindow.Height)
            {
                BoxSpeedy = -BoxSpeedy;
            }



            

            foreach (var Player in Gamescreen.Children.OfType<Rectangle>())
            {
                if ((string)Player.Tag == "User")
                {
                    Player.Stroke = Brushes.Black;

                    Rect boxHitBox = new Rect(Canvas.GetLeft(Box), Canvas.GetTop(Box), Box.Width, Box.Height);
                    Rect PlayerHitBox = new Rect(Canvas.GetLeft(Player), Canvas.GetTop(Player), Player.Width, Player.Height);

                    if (boxHitBox.IntersectsWith(PlayerHitBox))
                    {
                        BoxSpeedx = -BoxSpeedx;
                        BoxSpeedy = -BoxSpeedy;
                    }

                }
            }
        }
        


    }
}
