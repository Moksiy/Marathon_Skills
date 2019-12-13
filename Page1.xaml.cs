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

namespace WS
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();

            //string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=usersdb;Integrated Security=True";
        }

        /// <summary>
        /// Я хочу стать бегуном
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Runner_Click(object sender, RoutedEventArgs e)
        {
            RunnerMain mainPage = new RunnerMain();
            this.NavigationService.Navigate(mainPage);
        }

        /// <summary>
        /// Я хочу стать спонсором бегуна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sponsor_Click(object sender, RoutedEventArgs e)
        {
            SponsorMain sponsor = new SponsorMain();
            this.NavigationService.Navigate(sponsor);
        }

        /// <summary>
        /// Я хочу знать больше о событии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MoreInfo info = new MoreInfo();
            this.NavigationService.Navigate(info);
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            AutorisationForm autoriz = new AutorisationForm();
            this.NavigationService.Navigate(autoriz);
        }
    }
}
