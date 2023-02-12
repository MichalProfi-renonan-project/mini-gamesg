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

namespace tic_tac_toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int playercounter = 1;

        public MainWindow()
        {
            InitializeComponent();

        }
        private void Butt1_Click(object sender, RoutedEventArgs e)
        {

            if (lbl1.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter % 2 == 0)
            {
                lbl1.Content = "O";
                playercounter++;
            }
            else
            {
                lbl1.Content = "X";
                playercounter++;
            }

            lbl1.Content = "X";


        }

        private void butt2_Click(object sender, RoutedEventArgs e)
        {

            if (lbl2.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter % 2 == 0)
            {
                lbl2.Content = "O";
                playercounter++;
            }
            else
            {
                lbl2.Content = "X";
                playercounter++;
            }


            lbl2.Content = "X";

        }

        private void butt3_Click(object sender, RoutedEventArgs e)
        {

            if (lbl3.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter % 2 == 0)
            {
                lbl3.Content = "O";
                playercounter++;
            }
            else
            {
                lbl3.Content = "X";
                playercounter++;
            }




        }

        private void butt4_Click(object sender, RoutedEventArgs e)
        {
            if (lbl4.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter % 2 == 0)
            {
                lbl4.Content = "O";
                playercounter++;
            }
            else
            {
                lbl4.Content = "X";
                playercounter++;
            }

        }
        private void butt5_Click(object sender, RoutedEventArgs e)
        {
            if (lbl5.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter % 2 == 0)
            {
                lbl5.Content = "O";
                playercounter++;
            }
            else
            {
                lbl5.Content = "X";
                playercounter++;
            }
        }
        private void butt6_Click(object sender, RoutedEventArgs e)
        {
            if (lbl6.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter % 2 == 0)
            {
                lbl6.Content = "O";
                playercounter++;
            }
            else
            {
                lbl6.Content = "X";
                playercounter++;
            }

        }

        private void butt7_Click(object sender, RoutedEventArgs e)
        {
            if (lbl7.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter % 2 == 0)
            {
                lbl7.Content = "O";
                playercounter++;
            }
            else
            {
                lbl7.Content = "X";
                playercounter++;
            }
        }

        private void butt8_Click(object sender, RoutedEventArgs e)
        {
            if (lbl8.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter % 2 == 0)
            {
                lbl8.Content = "O";
                playercounter++;
            }
            else
            {
                lbl8.Content = "X";
                playercounter++;
            }

        }

        private void butt9_Click(object sender, RoutedEventArgs e)
        {

            if (lbl9.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter % 2 == 0)
            {
                lbl9.Content = "O";
                playercounter++;
            }
            else
            {
                lbl9.Content = "X";
                playercounter++;
            }
        }
    }
}