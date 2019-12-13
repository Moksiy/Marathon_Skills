using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
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
        SqlConnection connection = new SqlConnection();

        public MainWindow()
        {
            InitializeComponent();
            Page1 mainPage = new Page1();
            MainPage.NavigationService.Navigate(mainPage);
            StartCounter();
            ConnectDataBase();
        }

        /// <summary>
        /// Подключение БД
        /// </summary>
        private async void ConnectDataBase()
        {
            //Строка подключения            
            connection.ConnectionString = @"Data Source=DESKTOP-SJE2N6P\SQLEXPRESS;Initial Catalog=Marathon;Integrated Security=True";
            
            try
            {
                //Открываем подключение
                await connection.OpenAsync();

                //TEST
                MessageBox.Show("Подключение: \n" +
                    $"{connection.ConnectionString}\n" +
                    $"{connection.Database}\n" +
                    $"{connection.DataSource}\n" +
                    $"{connection.ServerVersion}\n" +
                    $"{connection.State}\n" +
                    $"{connection.WorkstationId}\n");
                //TEST

            }
            catch (SqlException ex)
            {
                //Выводим сообщение об ошибке
                MessageBox.Show(Convert.ToString(ex));
            }
            finally
            {
                //В любом случае закрываем подключение
                connection.Close();
            }
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
    }
}
