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
    public partial class Game2 : Page
    {
        private DispatcherTimer GameTimer = new DispatcherTimer();
        private bool UpKeyPressed, DownKeyPressed, LeftKeyPressed, RightKeyPressed;
        private float Speedx, Speedy, Friction = 0.88f, Speed = 2;
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

        public Game2()
        {
            InitializeComponent();
            Gamescreen.Focus();
            GameTimer.Interval = TimeSpan.FromMilliseconds(16);
            GameTimer.Tick += GameTick;
            GameTimer.Start();
        }
        
        private void GameTick(object sender, EventArgs e)
        {
            if (UpKeyPressed)
            {
                Speedy += Speed;
            }
            if (RightKeyPressed)
            {
                Speedx += Speed;
            }
            if (LeftKeyPressed)
            {
                Speedx -= Speed;
            }
            if (DownKeyPressed)
            {
                Speedy -= Speed;
            }

            Speedx = Speedx * Friction;
            Speedy = Speedy * Friction;

            Canvas.SetLeft(Player, Canvas.GetLeft(Player) + Speedx);
            Canvas.SetTop(Player, Canvas.GetTop(Player) - Speedy);
        }
    }
}
