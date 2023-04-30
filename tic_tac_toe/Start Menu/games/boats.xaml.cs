using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Threading;


namespace tic_tac_toe
{
    /// <summary>
    /// Interaction logic for boats.xaml
    /// </summary>
    public partial class boats : Window
    {
        List<Button> playerPositionButtons;
        List<Button> enemyPositionButtons;
        List<Label> playerPositionLabels;
        DispatcherTimer EnemyPlayTimer = new DispatcherTimer();

        Random rand = new Random();

        int totalships = 10;
        int playerscore;
        int enemyscore;
        int round = 31;

        public boats()
        {
            InitializeComponent();

            RestartGame();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;

            EnemyPlayTimer.Interval = TimeSpan.FromMilliseconds(16);
            EnemyPlayTimer.Tick += EnemyPlayTimerEvent;
            EnemyPlayTimer.Start();
        }

        private void EnemyPlayTimerEvent(object sender, EventArgs e)
        {
            if (playerPositionButtons.Count > 0 && round > 0 && totalships == 0)
            {
                round -= 1;

                txtRound.Content = "Round: " + round;

                int index = rand.Next(playerPositionButtons.Count);

                if ((string)playerPositionButtons[index].Tag == "playerShip")
                {
                    playerPositionButtons[index].Background = Brushes.Red;
                    EnemyMove.Content = playerPositionButtons[index].Content;
                    playerPositionButtons[index].IsEnabled = false;
                    playerPositionButtons.RemoveAt(index);
                    enemyscore += 1;
                    txtEnemy.Content = enemyscore.ToString();
                    EnemyPlayTimer.Stop();
                }
                else
                {
                    playerPositionButtons[index].Background = Brushes.Blue;
                    EnemyMove.Content = playerPositionButtons[index].Content;
                    playerPositionButtons[index].IsEnabled = false;
                    playerPositionButtons.RemoveAt(index);
                    txtEnemy.Content = enemyscore.ToString();
                    EnemyPlayTimer.Stop();
                }
                
            }

            
            
            if (round == 0 && playerscore > enemyscore)
            {
                MessageBox.Show("You Win!", "Winning");
                RestartGame();
            }
            else if (round == 0 && enemyscore > playerscore)
            {
                MessageBox.Show("You are the worst captain I have ever seen!", "Lost");
                RestartGame();
            }
            else if (round == 0 && playerscore == enemyscore)
            {
                MessageBox.Show("No one wins this battle captain!", "Draw");
                RestartGame();
            }

        }


        private void RestartGame()
        {
            playerPositionButtons = new List<Button> {A1, A2, A3, A4, A5, A6, A7, A8, B1, B2, B3, B4, B5, B6, B7, B8, C1, C2, C3, C4, C5, C6, C7, C8, D1, D2, D3, D4, D5, D6, D7, D8, E1, E2, E3, E4, E5, E6, E7, E8, F1, F2, F3, F4, F5, F6, F7, F8, G1, G2, G3, G4, G5, G6, G7, G8, H1, H2, H3, H4, H5, H6, H7, H8, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8};
            enemyPositionButtons = new List<Button> {I1, I2, I3, I4, I5, I6, I7, I8, J1, J2, J3, J4, J5, J6, J7, J8, K1, K2, K3, K4, K5, K6, K7, K8, L1, L2, L3, L4, L5, L6, L7, L8, M1, M2, M3, M4, M5, M6, M7, M8, N1, N2, N3, N4, N5, N6, N7, N8, O1, O2, O3, O4, O5, O6, O7, O8, P1, P2, P3, P4, P5, P6, P7, P8, R1, R2, R3, R4, R5, R6, R7, R8};
            playerPositionLabels = new List<Label> { lblA1, lblA2, lblA3, lblA4, lblA5, lblA6, lblA7, lblA8, lblB1, lblB2, lblB3, lblB4, lblB5, lblB6, lblB7, lblB8, lblC1, lblC2, lblC3, lblC4, lblC5, lblC6, lblC7, lblC8, lblCH1, lblCH2, lblCH3, lblCH4, lblCH5, lblCH6, lblCH7, lblCH8, lblD1, lblD2, lblD3, lblD4, lblD5, lblD6, lblD7, lblD8, lblE1, lblE2, lblE3, lblE4, lblE5, lblE6, lblE7, lblE8, lblF1, lblF2, lblF3, lblF4, lblF5, lblF6, lblF7, lblF8, lblG1, lblG2, lblG3, lblG4, lblG5, lblG6, lblG7, lblG8, lblH1, lblH2, lblH3, lblH4, lblH5, lblH6, lblH7, lblH8 };

            EnemyLocationListBox.Items.Clear();

            EnemyLocationListBox.Text = null;

            for (int i = 0; i < enemyPositionButtons.Count; i++)
            {
                enemyPositionButtons[i].IsEnabled = true;
                enemyPositionButtons[i].Tag = null;
                EnemyLocationListBox.Items.Add(enemyPositionButtons[i].Content);
            }

            for (int i = 0; i < playerPositionButtons.Count; i++)
            {
                playerPositionButtons[i].IsEnabled = true;
                playerPositionButtons[i].Tag = null;
            }

            playerscore = 0;
            enemyscore = 0;
            round = 31;

            txtPlayer.Content = playerscore.ToString();
            txtEnemy.Content = enemyscore.ToString();
            EnemyMove.Content = "A1";

            btnFire.IsEnabled = false;

            enemyLocationPicker();
        }

        private void enemyLocationPicker()
        {
            for (int i = 0; i < 10; i++)
            {
                int index = rand.Next(enemyPositionButtons.Count);

                if (enemyPositionButtons[index].IsEnabled == true && (string)enemyPositionButtons[index].Tag == null)
                {
                    enemyPositionButtons[index].Tag = "enemyShip";

                    Debug.WriteLine("Enemy Position: " + enemyPositionButtons[index].Content);
                }
                else
                {
                    index = rand.Next(enemyPositionButtons.Count);
                }
            }
        }

        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChoosingGame back = new ChoosingGame();
            back.Show();
        }

        private void FireButtonEvent(object sender, RoutedEventArgs e)
        {

            if (EnemyLocationListBox.Text != "")
            {
                var firePosition = EnemyLocationListBox.Text;

                int index = enemyPositionButtons.FindIndex(a => a.Name == firePosition);

                if (index > 0)
                {
                    if (enemyPositionButtons[index].IsEnabled && round > 0)
                    {


                        if ((string)enemyPositionButtons[index].Tag == "enemyShip")
                        {
                            enemyPositionButtons[index].IsEnabled = false;
                            enemyPositionButtons[index].Background = Brushes.Red;
                            playerscore += 1;
                            txtPlayer.Content = playerscore.ToString();
                            EnemyPlayTimer.Start();
                        }
                        else
                        {
                            enemyPositionButtons[index].IsEnabled = false;
                            enemyPositionButtons[index].Background = Brushes.Red;
                            EnemyPlayTimer.Start();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Choose a location of your attack first", "Information");
                }
            }
        }
       
        private void PlayerPositionButtonsEvent(object sender, RoutedEventArgs e)
        {

            if (totalships > 0)
            {

                playerPositionLabels = new List<Label> { lblA1, lblA2, lblA3, lblA4, lblA5, lblA6, lblA7, lblA8, lblB1, lblB2, lblB3, lblB4, lblB5, lblB6, lblB7, lblB8, lblC1, lblC2, lblC3, lblC4, lblC5, lblC6, lblC7, lblC8, lblD1, lblD2, lblD3, lblD4, lblD5, lblD6, lblD7, lblD8, lblE1, lblE2, lblE3, lblE4, lblE5, lblE6, lblE7, lblE8, lblF1, lblF2, lblF3, lblF4, lblF5, lblF6, lblF7, lblF8, lblG1, lblG2, lblG3, lblG4, lblG5, lblG6, lblG7, lblG8, lblH1, lblH2, lblH3, lblH4, lblH5, lblH6, lblH7, lblH8, lblCH1, lblCH2, lblCH3, lblCH4, lblCH5, lblCH6, lblCH7, lblCH8 };



                var button = (Button)sender;
                var label = playerPositionLabels[playerPositionButtons.IndexOf(button)];

                /*   var label = button.FindName(button.Name) as Label;

                   string fromlist = "";

                   foreach (var item in playerPositionLabels)
                   {
                       if (item == label)
                           fromlist = item.ToString();
                   }

                   Console.WriteLine("Co to je");

                   Console.WriteLine(fromlist);
                */
                button.IsEnabled = false;
                button.Tag = "playerShip";
                label.Background = Brushes.Gold;
                totalships -= 1;
            }
            if (totalships == 0)
            {
                btnFire.IsEnabled = true;
                btnFire.Background = Brushes.Red;
                btnFire.Foreground = Brushes.White;
            }
        }

    }
}
