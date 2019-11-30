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
    /// Логика взаимодействия для RegConfirm.xaml
    /// </summary>
    public partial class RegConfirm : Page
    {
        public RegConfirm()
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
            Page1 info = new Page1();
            this.NavigationService.Navigate(info);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Page1 info = new Page1();
            this.NavigationService.Navigate(info);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Page1 info = new Page1();
            this.NavigationService.Navigate(info);
        }
    }
}
