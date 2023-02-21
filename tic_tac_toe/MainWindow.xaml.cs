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
using tic_tac_toe;

namespace tic_tac_toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;
            WindowStyle = WindowStyle.None;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ChoosingGame choose = new ChoosingGame();
            choose.Show();

         
        }

        private void Button_exit_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}