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
        DispatcherTimer EnemyPlayTimer = new DispatcherTimer();

        Random rand = new Random();

        int totalships = 10;
        int buttonClickCount = 0;
        private bool firstTime = true;
        int playerscore;
        int enemyscore;
        int times;
        int round = 10;

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
            
        }

        private void RestartGame()
        {
            playerPositionButtons = new List<Button> {A1, A2, A3, A4, A5, A6, A7, A8, B1, B2, B3, B4, B5, B6, B7, B8, C1, C2, C3, C4, C5, C6, C7, C8, D1, D2, D3, D4, D5, D6, D7, D8, E1, E2, E3, E4, E5, E6, E7, E8, F1, F2, F3, F4, F5, F6, F7, F8, G1, G2, G3, G4, G5, G6, G7, G8, H1, H2, H3, H4, H5, H6, H7, H8, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8};
            enemyPositionButtons = new List<Button> {I1, I2, I3, I4, I5, I6, I7, I8, J1, J2, J3, J4, J5, J6, J7, J8, K1, K2, K3, K4, K5, K6, K7, K8, L1, L2, L3, L4, L5, L6, L7, L8, M1, M2, M3, M4, M5, M6, M7, M8, N1, N2, N3, N4, N5, N6, N7, N8, O1, O2, O3, O4, O5, O6, O7, O8, P1, P2, P3, P4, P5, P6, P7, P8, R1, R2, R3, R4, R5, R6, R7, R8};

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
            round = 10;

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

        }
       
        private void PlayerPositionButtonsEvent(object sender, RoutedEventArgs e)
        {
            if (totalships > 0)
            {
                var button = (Button)sender;

                button.IsEnabled = false;
                button.Tag = "playerShip";
                button.Foreground = Brushes.Orange;
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
