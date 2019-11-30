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
    /// Логика взаимодействия для Runner.xaml
    /// </summary>
    public partial class Runner : Page
    {
        public Runner()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutorisationForm info = new AutorisationForm();
            this.NavigationService.Navigate(info);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Регистрация на марафон
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Runner_Click(object sender, RoutedEventArgs e)
        {

        }

        
        /// <summary>
        /// Мои результаты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Results_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Редактирование профиля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Redact_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Мой спонсор
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sponsor_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Контакты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Contacts_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
