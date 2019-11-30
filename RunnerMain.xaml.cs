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
    /// Логика взаимодействия для RunnerMain.xaml
    /// </summary>
    public partial class RunnerMain : Page
    {
        public RunnerMain()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            AutorisationForm autoriz = new AutorisationForm();
            this.NavigationService.Navigate(autoriz);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page1 mainPage = new Page1();
            this.NavigationService.Navigate(mainPage);
        }

        private void Runner_Copy_Click(object sender, RoutedEventArgs e)
        {
            RunnerRegistration reg = new RunnerRegistration();
            this.NavigationService.Navigate(reg);
        }
    }
}
