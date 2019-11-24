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
using System.Threading;

namespace WS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StartCounter();
        }

        /// <summary>
        /// Запуск паточека
        /// </summary>
        /// <returns></returns>
        public async Task StartCounter()
        {
            await Task.Run(() => Counter());
        }

        /// <summary>
        /// Счетчик оставшегося время
        /// </summary>
        public void Counter()
        {
            while (true)
            {
                DateTime dateNow = DateTime.Now;
                DateTime dateMarathon = new DateTime(2019, 12, 31, 12, 00, 00);
                TimeSpan dateDiff = dateMarathon.Subtract(dateNow);

                this.Dispatcher.BeginInvoke((Action)delegate
                {
                    Days.Text = Convert.ToString(dateDiff.Days);
                    Hours.Text = Convert.ToString(dateDiff.Hours);
                    Minutes.Text = Convert.ToString(dateDiff.Minutes);
                });
                Thread.Sleep(10000);    
            }
        }

        /// <summary>
        /// Я хочу стать бегуном
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Runner_Click(object sender, RoutedEventArgs e)
        {
           
        }

        /// <summary>
        /// Я хочу стать спонсором бегуна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sponsor_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Я хочу знать больше о событии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Info_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
