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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Tictactoe : Window
    {
        int playercounter = 1;
        int[] gridnumbers = new int[9];

        public Tictactoe()
        {
            InitializeComponent();

        }
        
        private void WinChecker1()
        {
            if (WinChecker2(lbl1, lbl2, lbl3))
            {
                if (playercounter % 2 == 0)
                    MessageBox.Show("cross wins");
                if (playercounter % 2 == 1)
                {
                    MessageBox.Show("circle wins");
                }
            }
            if (WinChecker2(lbl4, lbl5, lbl6))
            {
                if (playercounter % 2 == 0)
                    MessageBox.Show("cross wins");
                if (playercounter % 2 == 1)
                {
                    MessageBox.Show("circle wins");
                }
            }
            if (WinChecker2(lbl7, lbl8, lbl9))
            {
                if (playercounter % 2 == 0)
                    MessageBox.Show("cross wins");
                if (playercounter % 2 == 1)
                {
                    MessageBox.Show("circle wins");
                }
            }
            if (WinChecker2(lbl1, lbl4, lbl7))
            {
                if (playercounter % 2 == 0)
                    MessageBox.Show("cross wins");
                if (playercounter % 2 == 1)
                {
                    MessageBox.Show("circle wins");
                }
            }
            if (WinChecker2(lbl2, lbl5, lbl8))
            {
                if (playercounter % 2 == 0)
                    MessageBox.Show("cross wins");
                if (playercounter % 2 == 1)
                {
                    MessageBox.Show("circle wins");
                }
            }
            if (WinChecker2(lbl3, lbl6, lbl9))
            {
                if (playercounter % 2 == 0)
                    MessageBox.Show("cross wins");
                if (playercounter % 2 == 1)
                {
                    MessageBox.Show("circle wins");
                }
            }
            if (WinChecker2(lbl1, lbl5, lbl9))
            {
                if (playercounter % 2 == 0)
                    MessageBox.Show("cross wins");
                if (playercounter % 2 == 1)
                {
                    MessageBox.Show("circle wins");
                }
            }
            if (WinChecker2(lbl3, lbl5, lbl7))
            {
                if (playercounter % 2 == 0)
                    MessageBox.Show("cross wins");
                if (playercounter % 2 == 1)
                {
                    MessageBox.Show("circle wins");
                }
            }
        }
        private bool WinChecker2(Label lbl1, Label lbl2, Label lbl3)
        {
            if (lbl1.Content != null && lbl2.Content != null && lbl3.Content != null && lbl1.Content == lbl2.Content && lbl2.Content == lbl3.Content)
            {
                return true;
            }
            else
                return false;
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
                WinChecker1();
            }
            else
            {
                lbl1.Content = "X";
                playercounter++;
                WinChecker1();
            }




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
                WinChecker1();

            }
            else
            {
                lbl2.Content = "X";
                playercounter++;
                WinChecker1();
            }



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
                WinChecker1();

            }
            else
            {
                lbl3.Content = "X";
                playercounter++;
                WinChecker1();
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
                WinChecker1();
            }
            else
            {
                lbl4.Content = "X";
                ;
                playercounter++;
                WinChecker1();
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
                WinChecker1();
            }
            else
            {
                lbl5.Content = "X";

                playercounter++;
                WinChecker1();
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
                WinChecker1();
            }
            else
            {
                lbl6.Content = "X";

                playercounter++;
                WinChecker1();
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
                WinChecker1();
            }
            else
            {
                lbl7.Content = "X";

                playercounter++;
                WinChecker1();
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
                WinChecker1();

                playercounter++;
            }
            else
            {
                lbl8.Content = "X";
                WinChecker1();

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
                WinChecker1();

                playercounter++;
            }
            else
            {
                lbl9.Content = "X";
                WinChecker1();

                playercounter++;
            }
        }

        private void Button_backd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChoosingGame back = new ChoosingGame();
            back.Show();
        }
    }
}
