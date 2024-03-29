﻿using System;
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
    /// Логика взаимодействия для MoreInfo.xaml
    /// </summary>
    public partial class MoreInfo : Page
    {
        public MoreInfo()
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
        /// Marathon Skills 2019
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Runner_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Насколько долгий марафон
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HowLong_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Предыдущие результаты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Results_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Благотворительные организации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DonOrganisations_Click(object sender, RoutedEventArgs e)
        {
            DonationOrganisationsList donationlist = new DonationOrganisationsList();
            this.NavigationService.Navigate(donationlist);
        }

        /// <summary>
        /// BMI калькулятор
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BMI_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// BMR калькулятор
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BMR_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
