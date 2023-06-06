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

        public List<Button> buttons = new List<Button>();
        public List<Label> labels = new List<Label>();

    public Tictactoe()
        {
            InitializeComponent();
            Components();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
            lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
        }
        static void lbcolor(Label lbl)
        {
            var brush = (SolidColorBrush)new BrushConverter().ConvertFrom("#85388c");
            lbl.Foreground = brush;
        }

        public void AddLabel(Label label)  
        {
            labels.Add(label);
        }
        public void AddButton(Button butt)
        {
            buttons.Add(butt);
        }
        public void Components()
        {
            AddLabel(lbl1);
            AddLabel(lbl2);
            AddLabel(lbl3);
            AddLabel(lbl4);
            AddLabel(lbl5);
            AddLabel(lbl6);
            AddLabel(lbl7);
            AddLabel(lbl8);
            AddLabel(lbl9);
            AddButton(butt1);
            AddButton(butt2);
            AddButton(butt3);
            AddButton(butt4);
            AddButton(butt5);
            AddButton(butt6);
            AddButton(butt7);
            AddButton(butt8);
            AddButton(butt9);
        }
        public void crosswin()
        {
            MessageBox.Show("cross wins");
            resetgame();
            Winscross++;
            lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
        }
        public void circlewin()
        {
            MessageBox.Show("circle wins");
            resetgame();
            Winscircle++;
            lblcounter.Content = $"X: {Winscross.ToString()} O:{Winscircle.ToString()}";
        }
        public void buttclicked(Label lbl, Button butt)
        {


            if (playercounter == 1)
            {
                lbl.Content = "X";
                butt.Background = Brushes.White;
                playercounter = 2;
                clickscounter++;
                WinChecker1();
            }
               
            else if (playercounter == 2)
            {
                lbl.Content = "O";
                butt.Background = Brushes.White;
                playercounter = 1;
                clickscounter++;
                WinChecker1();
            }
        }

        private void WinChecker1()
        {

            if (clickscounter > 8)
            {
                MessageBox.Show("draw");
                resetgame();
            }
            if (WinChecker2(lbl1, lbl2, lbl3))
            {
                if (playercounter == 2)
                {
                    crosswin();
                }
                   
                else if (playercounter == 1)
                {
                    circlewin();
                }
            }
            if (WinChecker2(lbl4, lbl5, lbl6))
            {
                if (playercounter == 2)
                {
                    crosswin();
                }

                else if (playercounter == 1)
                {
                    circlewin();
                }
            }
            if (WinChecker2(lbl7, lbl8, lbl9))
            {
                if (playercounter == 2)
                {
                    crosswin();
                }    
                else if (playercounter == 1)
                {
                    circlewin();
                }
            }
            if (WinChecker2(lbl1, lbl4, lbl7))
            {
                if (playercounter == 2)
                {
                    crosswin();
                }
                else if (playercounter == 1)
                {
                    circlewin();
                }
            }
            if (WinChecker2(lbl2, lbl5, lbl8))
            {
                if (playercounter == 2)
                {
                    crosswin();
                }
                   
                else if (playercounter == 1)
                {
                    circlewin();
                }
            }
            if (WinChecker2(lbl3, lbl6, lbl9))
            {
                if (playercounter == 2)
                {
                    crosswin();
                }
              
                else if (playercounter == 1)
                {
                    circlewin();
                }
            }
            if (WinChecker2(lbl1, lbl5, lbl9))
            {
                if (playercounter == 2)
                {
                    crosswin();
                }
                else if (playercounter == 1)
                {
                    circlewin();
                }
            }
            if (WinChecker2(lbl3, lbl5, lbl7))
            {
                if (playercounter == 2)
                {
                    crosswin();
                }

                else if (playercounter == 1)
                {
                    circlewin();
                }
            }
        }
        
        private bool WinChecker2(Label lbl1, Label lbl2, Label lbl3)
        {
            if (lbl1.Content != null && lbl2.Content != null && lbl3.Content != null && lbl1.Content == lbl2.Content && lbl2.Content == lbl3.Content)
            {
                lbcolor(lbl1);
                lbcolor(lbl2);
                lbcolor(lbl3);
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
            else
            {
                buttclicked(lbl1, butt1);
            } 
        }

        private void butt2_Click(object sender, RoutedEventArgs e)
        {

            if (lbl2.Content != null)
            {
                MessageBox.Show("error");
            }
            else
            {
                buttclicked(lbl2, butt2);
            }
        }

        private void butt3_Click(object sender, RoutedEventArgs e)
        {

            if (lbl3.Content != null)
            {
                MessageBox.Show("error");
            }
            else
            {
                buttclicked(lbl3, butt3);
            }
        }
        private void butt4_Click(object sender, RoutedEventArgs e)
        {
            if (lbl4.Content != null)
            {
                MessageBox.Show("error");
            }
            else
            {
                buttclicked(lbl4, butt4);
            }
        }
        private void butt5_Click(object sender, RoutedEventArgs e)
        {
            if (lbl5.Content != null)
            {
                MessageBox.Show("error");
            }
            else
            {
                buttclicked(lbl5, butt5);
            }
        }
        private void butt6_Click(object sender, RoutedEventArgs e)
        {
            if (lbl6.Content != null)
            {
                MessageBox.Show("error");
            }
            else
            {
                buttclicked(lbl6, butt6);
            }
        }

        private void butt7_Click(object sender, RoutedEventArgs e)
        {
            if (lbl7.Content != null)
            {
                MessageBox.Show("error");
            }
            else
            {
                buttclicked(lbl7, butt7);
            }
        }

        private void butt8_Click(object sender, RoutedEventArgs e)
        {
            if (lbl8.Content != null)
            {
                MessageBox.Show("error");
            }
            else
            {
                buttclicked(lbl8, butt8);
            }
        }

        private void butt9_Click(object sender, RoutedEventArgs e)
        {

            if (lbl9.Content != null)
            {
                MessageBox.Show("error");
            }
            else
            {
                buttclicked(lbl9, butt9);
            }
        }
        
        private void resetgame()
        {
            foreach(Label lbl in labels)
            {
                lbl.Foreground = Brushes.Black;
                lbl.Content = null;
            }

            foreach(Button btn in buttons)
            {
                btn.Background = Brushes.Transparent;
            }
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
