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
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Page
    {
        public Administrator()
        {
            InitializeComponent();
        }

        /// <summary>
        ///Назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page1 info = new Page1();
            this.NavigationService.Navigate(info);
        }

        /// <summary>
        /// Пользователи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Users_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Волонтеры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Volonters_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Благотворительные организации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Organisations_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Инвентарь
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Inventory_Click(object sender, RoutedEventArgs e)
        {

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
    }
}
