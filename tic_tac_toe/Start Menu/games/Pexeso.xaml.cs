using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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
        Timer clickTimer = new Timer();
        int time = 60;
        Timer timer = new Timer {Interval = 1000 };
        
        public Pexeso()
        {
            InitializeComponent();

            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
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
            timer.Elapsed += delegate
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

            do
            {
                num = rnd.Next(0, immages.Count());
            }
            while (immages[num].Tag != null);
            return immages[num];
        }
        private void setRandomImages()
        {
            throw new NotImplementedException();
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChoosingGame back = new ChoosingGame();
            back.Show();
        }
    }
}
