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
    /// Логика взаимодействия для Coordinator.xaml
    /// </summary>
    public partial class Coordinator : Page
    {
        public Coordinator()
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
            //ОТКЛЮЧЕНИЕ ОТ СИСТЕМЫ
            Page1 info = new Page1();
            this.NavigationService.Navigate(info);
        }

        /// <summary>
        /// Бегуны
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Runner_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Спонсоры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sponsors_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
