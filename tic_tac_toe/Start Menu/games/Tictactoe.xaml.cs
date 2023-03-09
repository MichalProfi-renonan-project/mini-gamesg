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
        int clickscounter = 0;
        int[] gridnumbers = new int[9];
        int Winscircle = 0;
        int Winscross = 0;

        List<Button> buttons = new List<Button>();
        
        public static List<Label> labels = new List<Label>();

        public Tictactoe()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
        }
        
        private void WinChecker1()
        {
            if (clickscounter > 8)
            {
                resetgame();
            }
            if (WinChecker2(lbl1, lbl2, lbl3))
            {
                if (playercounter == 2)
                {
                    MessageBox.Show("cross wins");
                    resetgame();
                    Winscross++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
                   
                else if (playercounter == 1)
                {
                    MessageBox.Show("circle wins");
                    resetgame();
                    Winscircle++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
            }
            if (WinChecker2(lbl4, lbl5, lbl6))
            {
                if (playercounter == 2)
                {
                    MessageBox.Show("cross wins");
                    resetgame();
                    Winscross++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }

                else if (playercounter == 1)
                {
                    MessageBox.Show("circle wins");
                    resetgame();
                    Winscircle++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
            }
            if (WinChecker2(lbl7, lbl8, lbl9))
            {
                if (playercounter == 2)
                {
                    MessageBox.Show("cross wins");
                    resetgame();
                    Winscross++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }    
                else if (playercounter == 1)
                {
                    MessageBox.Show("circle wins");
                    resetgame();
                    Winscircle++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
            }
            if (WinChecker2(lbl1, lbl4, lbl7))
            {
                if (playercounter == 2)
                {
                    MessageBox.Show("cross wins");
                    resetgame();
                    Winscross++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
                else if (playercounter == 1)
                {
                    MessageBox.Show("circle wins");
                    resetgame();
                    Winscircle++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
            }
            if (WinChecker2(lbl2, lbl5, lbl8))
            {
                if (playercounter == 2)
                {
                    MessageBox.Show("cross wins");
                    resetgame();
                    Winscross++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
                   
                else if (playercounter == 1)
                {
                    MessageBox.Show("circle wins");
                    resetgame();
                    Winscircle++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
            }
            if (WinChecker2(lbl3, lbl6, lbl9))
            {
                if (playercounter == 2)
                {
                    MessageBox.Show("cross wins");
                    resetgame();
                    Winscross++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
              
                else if (playercounter == 1)
                {
                    MessageBox.Show("circle wins");
                    resetgame();
                    Winscircle++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
            }
            if (WinChecker2(lbl1, lbl5, lbl9))
            {
                if (playercounter == 2)
                {
                    MessageBox.Show("cross wins");
                    resetgame();
                    Winscross++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
                else if (playercounter == 1)
                {
                    MessageBox.Show("circle wins");
                    resetgame();
                    Winscircle++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
            }
            if (WinChecker2(lbl3, lbl5, lbl7))
            {
                if (playercounter == 2)
                {
                    MessageBox.Show("cross wins");
                    resetgame();
                    Winscross++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }

                else if (playercounter == 1)
                {
                    MessageBox.Show("circle wins");
                    resetgame();
                    Winscircle++;
                    lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
                }
            }
        }
        
        private bool WinChecker2(Label lbl1, Label lbl2, Label lbl3)
        {
            if (lbl1.Content != null && lbl2.Content != null && lbl3.Content != null && lbl1.Content == lbl2.Content && lbl2.Content == lbl3.Content)
            {
                lbl1.Foreground = Brushes.Gold;
                lbl2.Foreground = Brushes.Gold;
                lbl3.Foreground = Brushes.Gold;
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
            else if (playercounter == 2)
            {
                lbl1.Content = "O";
                butt1.Background = Brushes.White;
                playercounter = 1;
                clickscounter++;
                WinChecker1();
            }
            else if (playercounter == 1)
            {
                lbl1.Content = "X";
                butt1.Background = Brushes.White;
                playercounter = 2;
                clickscounter++;
                WinChecker1();
            }




        }

        private void butt2_Click(object sender, RoutedEventArgs e)
        {

            if (lbl2.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter == 2)
            {
                lbl2.Content = "O";
                butt2.Background = Brushes.White;
                playercounter = 1;
                clickscounter++;
                WinChecker1();

            }
            else if (playercounter == 1)
            {
                lbl2.Content = "X";
                butt2.Background = Brushes.White;
                playercounter = 2;
                clickscounter++;
                WinChecker1();
            }



        }

        private void butt3_Click(object sender, RoutedEventArgs e)
        {

            if (lbl3.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter == 2)
            {
                lbl3.Content = "O";
                butt3.Background = Brushes.White;
                playercounter = 1;
                clickscounter++;
                WinChecker1();

            }
            else if (playercounter == 1)
            {
                lbl3.Content = "X";
                butt3.Background = Brushes.White;
                playercounter = 2;
                clickscounter++;
                WinChecker1();
            }




        }

        private void butt4_Click(object sender, RoutedEventArgs e)
        {
            if (lbl4.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter == 2)
            {
                lbl4.Content = "O";
                butt4.Background = Brushes.White;
                playercounter = 1;
                clickscounter++;
                WinChecker1();
            }
            else if (playercounter == 1)
            {
                lbl4.Content = "X";
                butt4.Background = Brushes.White;
                playercounter = 2;
                clickscounter++;
                WinChecker1();
            }

        }
        private void butt5_Click(object sender, RoutedEventArgs e)
        {
            if (lbl5.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter == 2)
            {
                lbl5.Content = "O";
                butt5.Background = Brushes.White;
                playercounter = 1;
                clickscounter++;
                WinChecker1();
            }
            else if (playercounter == 1)
            {
                lbl5.Content = "X";
                butt5.Background = Brushes.White;
                playercounter = 2;
                clickscounter++;
                WinChecker1();
            }
        }
        private void butt6_Click(object sender, RoutedEventArgs e)
        {
            if (lbl6.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter == 2)
            {
                lbl6.Content = "O";
                butt6.Background = Brushes.White;
                playercounter = 1;
                clickscounter++;
                WinChecker1();
            }
            else if (playercounter == 1)
            {
                lbl6.Content = "X";
                butt6.Background = Brushes.White;
                playercounter = 2;
                clickscounter++;
                WinChecker1();
            }

        }

        private void butt7_Click(object sender, RoutedEventArgs e)
        {
            if (lbl7.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter == 2)
            {
                lbl7.Content = "O";
                butt7.Background = Brushes.White;
                playercounter = 1;
                clickscounter++;
                WinChecker1();
            }
            else if (playercounter == 1)
            {
                lbl7.Content = "X";
                butt7.Background = Brushes.White;
                playercounter = 2;
                clickscounter++;
                WinChecker1();
            }
        }

        private void butt8_Click(object sender, RoutedEventArgs e)
        {
            if (lbl8.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter == 2)
            {
                lbl8.Content = "O";
                butt8.Background = Brushes.White;
                playercounter = 1;
                clickscounter++;
                WinChecker1();
            }
            else if (playercounter == 1)
            {
                lbl8.Content = "X";
                butt8.Background = Brushes.White;
                playercounter = 2;
                clickscounter++;
                WinChecker1();
            }

        }

        private void butt9_Click(object sender, RoutedEventArgs e)
        {

            if (lbl9.Content != null)
            {
                MessageBox.Show("error");
            }
            else if (playercounter  == 2)
            {
                lbl9.Content = "O";
                butt9.Background = Brushes.White;
                playercounter = 1;
                clickscounter++;
                WinChecker1();
            }
            else if (playercounter == 1)
            {
                lbl9.Content = "X";
                butt9.Background = Brushes.White;
                playercounter = 2;
                clickscounter++;
                WinChecker1();
            }
        }
        
        private void resetgame()
        {
            butt1.Background = Brushes.Transparent;
            butt2.Background = Brushes.Transparent;
            butt3.Background = Brushes.Transparent;
            butt4.Background = Brushes.Transparent;
            butt5.Background = Brushes.Transparent;
            butt6.Background = Brushes.Transparent;
            butt7.Background = Brushes.Transparent;
            butt8.Background = Brushes.Transparent;
            butt9.Background = Brushes.Transparent;
            lbl1.Foreground = Brushes.Black;
            lbl2.Foreground = Brushes.Black;
            lbl3.Foreground = Brushes.Black;
            lbl4.Foreground = Brushes.Black;
            lbl5.Foreground = Brushes.Black;
            lbl6.Foreground = Brushes.Black;
            lbl7.Foreground = Brushes.Black;
            lbl8.Foreground = Brushes.Black;
            lbl9.Foreground = Brushes.Black;
            lbl1.Content = null;
            lbl2.Content = null;
            lbl3.Content = null;
            lbl4.Content = null;
            lbl5.Content = null;
            lbl6.Content = null;
            lbl7.Content = null;
            lbl8.Content= null;
            lbl9.Content = null;
            playercounter = 1;
            clickscounter = 0;
        }

            private void Button_backd_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChoosingGame back = new ChoosingGame();
            back.Show();
        
        }
    }
}
