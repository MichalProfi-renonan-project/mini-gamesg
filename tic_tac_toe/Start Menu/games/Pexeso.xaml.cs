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
        bool allowClick = true;
        Label firstGuess;
        Random rnd = new Random();
        DispatcherTimer clickTimer = new DispatcherTimer();
        int time = 60;
        DispatcherTimer timer = new DispatcherTimer();
        bool gameStarted = false;

        public List<int> GeneratedValues { get; set; }

        public Pexeso()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        //    timer.Interval = TimeSpan.FromSeconds(1);
          //  clickTimer.Interval = TimeSpan.FromSeconds(1);
           // clickTimer.Tick += ClickTimer_Tick;
           
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            GeneratedValues = RandomGenerated();
            DataContext = this;
            setRandomNumbers();
          //  timer.Start();
         //   timer.Tick += Timer_Tick;
            gameStarted = true;
        }

        private List<int> RandomGenerated()
        {
            List<int> numberList = new List<int>();
            int generatedNumber;
            Random random = new Random();

            for (int i = 0; i < 9; i++)
            {
                generatedNumber = random.Next(1, 1000);
                numberList.Add(generatedNumber);
                numberList.Add(generatedNumber);
            }

            return numberList;
        }

        private void setRandomNumbers()
        {
            List<Label> labels = new List<Label>()
        {
            label1,
            label2,
            label3,
            label4,
            label5,
            label6,
            label7,
            label8,
            label9,
            label10,
            label11,
            label12,
            label13,
            label14,
            label15,
            label16,
            label17,
            label18,
        };
            ShuffleLabels(labels);

            for (int i = 0; i < GeneratedValues.Count; i++)
            {
                labels[i].Content = GeneratedValues[i].ToString();
                labels[i].Background = Brushes.Black;
                labels[i].FontSize = 24;
                labels[i].HorizontalContentAlignment = HorizontalAlignment.Center;
                labels[i].VerticalContentAlignment = VerticalAlignment.Center;

                //    labels[i].MouseDown += Label_Click;
            }

            
        }

        public static void ShuffleLabels(List<Label> labels)
        {
            Random random = new Random();

            for (int i = 0; i < labels.Count - 1; i++)
            {
                int randomIndex = random.Next(i, labels.Count);
                Label temp = labels[i];
                labels[i] = labels[randomIndex];
                labels[randomIndex] = temp;
                
            }
        }

        private Label beforeLabel = null;
        private string firstTap = null;
        private string secondTap = null;
        private int pocetPokusov = 0;
        private int pocetUhadnutých = 0;
        private bool test = false;

        private async void Label_Click(object sender, MouseButtonEventArgs e)
        {
            

            Label clickedLabel = (Label)sender;
            clickedLabel.Background = Brushes.White;

            if (clickedLabel.Content != null)
            {

                if (firstTap == null)
                    firstTap = clickedLabel.Content.ToString();
                else
                {
                    secondTap = firstTap;
                    firstTap = clickedLabel.Content.ToString();
                }

                if (beforeLabel != null)
                {

                    if (secondTap != null && firstTap == secondTap)
                    {


                        clickedLabel.Background = Brushes.Chartreuse;
                        clickedLabel.Foreground = Brushes.Black;
                        beforeLabel.Background = Brushes.Chartreuse;
                        beforeLabel.Foreground = Brushes.Black;
                        clickedLabel.IsEnabled = false;
                        beforeLabel.IsEnabled = false;
                        beforeLabel = null;
                        firstTap = null;
                        secondTap = null;

                        pocetUhadnutých++;


                        if (pocetUhadnutých == 9)
                            MessageBox.Show("Vyhral si! Potreboval si " + pocetPokusov.ToString() + " pokusov.");


                    }
                    else if (secondTap != null && firstTap != secondTap)
                    {

                        await Task.Delay(1000);
                        clickedLabel.Background = Brushes.Black;
                        clickedLabel.Foreground = Brushes.Black;
                        beforeLabel.Foreground = Brushes.Black;
                        beforeLabel.Background = Brushes.Black;
                        beforeLabel = null;
                        firstTap = null;
                        secondTap = null;
                    }
                }
                if (test)
                {
                    pocetPokusov++;
                    LblPokus.Content = "Pokusy: " + pocetPokusov;
                    test = false;
                }
                else
                {
                    test = true;
                }


                beforeLabel = clickedLabel;
            }
        }



        private void Button_back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ChoosingGame back = new ChoosingGame();
            back.Show();
        }

        private void LabelButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
    }
