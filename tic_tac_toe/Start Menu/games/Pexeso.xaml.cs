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
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Imaging;

namespace tic_tac_toe
{
    /// <summary>
    /// Interaction logic for Pexeso.xaml
    /// </summary>
    public partial class Pexeso : Window
    {
        bool allowClick = false;
        Image firstGuess;
        Random rnd = new Random();
        DispatcherTimer clickTimer = new DispatcherTimer();
        int time = 60;
        DispatcherTimer timer = new DispatcherTimer();
        
        
        public Pexeso()
        {
            InitializeComponent();

            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

            timer.Interval = TimeSpan.FromSeconds(1);
        }
        private Image[] immages
        {
            get { return Pole.Children.OfType<Image>().ToArray(); }
        }
        private static IEnumerable<BitmapImage> images
        {
            get
            {
                return new BitmapImage[]
                {
                    new BitmapImage(new Uri("Properties/Resources/Hot-dog.png", UriKind.RelativeOrAbsolute)),
                    new BitmapImage(new Uri("Properties/Resources/Oliver.png", UriKind.RelativeOrAbsolute)),
                    new BitmapImage(new Uri("Properties/Resources/Vydra.png", UriKind.RelativeOrAbsolute)),
                    new BitmapImage(new Uri("Properties/Resources/uwu_cat.png", UriKind.RelativeOrAbsolute)),
                    new BitmapImage(new Uri("Properties/Resources/s0v1k3.jpg", UriKind.RelativeOrAbsolute)),
                    new BitmapImage(new Uri("Properties/Resources/Pes.jpg", UriKind.RelativeOrAbsolute)),
                    new BitmapImage(new Uri("Properties/Resources/patkan.png", UriKind.RelativeOrAbsolute)),
                    new BitmapImage(new Uri("Properties/Resources/patkan2.png", UriKind.RelativeOrAbsolute)),

                };
            }
        }
        private void startGameTimer()
        {
            timer.Start();
            timer.Tick += delegate
            {
                time--;
                if (time < 0)
                {
                    timer.Stop();
                    MessageBox.Show("Time off");
                    ResetImages();
                }

                var sstime = TimeSpan.FromSeconds(time);

                LblTime.Content = "00: " + time.ToString();
            };
        }
        private void ResetImages()
        {
            foreach (var pic in immages)
            {
                pic.Tag = null;
                pic.Visibility = Visibility.Visible;
            }

            HideImages();
            setRandomImages();
            time = 60;
            timer.Start();
        }

        

        private void HideImages()
        {
            foreach (var image in immages)
            {
                image.Source = new BitmapImage(new Uri("Properties/Resources/what_if.png", UriKind.RelativeOrAbsolute));
            }
        }
        private Image getFreeSlot()
        {
            int num;
            int daco = 0;
            do
            {
                num = rnd.Next(0, immages.Count());
                Console.WriteLine(num);
                
            }
            while (daco<2);
            return immages[num];
            daco++;
        }
        private void setRandomImages()
        {
            foreach (var image in images)
            {
                getFreeSlot().Tag = image;
                getFreeSlot().Tag = image;
            }
        }
        private void CLICKTIMER_TICK(object sender, EventArgs e)
        {
            HideImages();

            allowClick = true;
            clickTimer.Stop();
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChoosingGame back = new ChoosingGame();
            back.Show();
        }

        private void clickImage(object sender, MouseButtonEventArgs e)
        {
            if (!allowClick) return;

            var pic = (Image)sender;

            if (firstGuess == null)
            {
                firstGuess = pic;
                pic.Source = (ImageSource)pic.Tag;
                return;
            }

            pic.Source = (ImageSource)pic.Tag;

            if (pic.Source == firstGuess.Source && pic != firstGuess)
            {
                pic.Visibility = firstGuess.Visibility = Visibility.Hidden;
                {
                    firstGuess = pic;
                }
                HideImages();
            }
            else
            {
                allowClick = false;
                clickTimer.Start();
            }

            firstGuess = null;
            if (immages.Any(p => p.Visibility == Visibility.Visible)) return;
            MessageBox.Show("You win! Now try again");
            ResetImages();
        }

        private void startGame(object sender, RoutedEventArgs e)
        {
            allowClick = true;
            setRandomImages();
            HideImages();
            startGameTimer();
            clickTimer.Interval = TimeSpan.FromSeconds(1);
            clickTimer.Tick += CLICKTIMER_TICK;
            Start.IsEnabled = false;
        }
    }
}
