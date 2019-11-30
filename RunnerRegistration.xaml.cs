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
    /// Логика взаимодействия для RunnerRegistration.xaml
    /// </summary>
    public partial class RunnerRegistration : Page
    {
        public RunnerRegistration()
        {
            InitializeComponent();
            //Photo.Source = new BitmapImage(new Uri("PHOTO.jpg"));
            //this.Photo.Source = new BitmapImage(new Uri("PHOTO.jpg", UriKind.Relative)) { CreateOptions = BitmapCreateOptions.IgnoreImageCache };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Page1 mainPage = new Page1();
            this.NavigationService.Navigate(mainPage);
        }


        /// <summary>
        /// Email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailAdress_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            EmailAdress.Text = "";
        }

        /// <summary>
        /// Пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Password_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Password.Text = "";
        }

        /// <summary>
        /// Повторите пароль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordRepeat_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PasswordRepeat.Text = "";
        }

        /// <summary>
        /// Имя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Name_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Name.Text = "";
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastName_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LastName.Text = "";
        }

        /// <summary>
        /// Регистрация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            bool errorbool = false;
            string errors = "";
            //Проверка введенных значений
            //проверка Email
            if(EmailAdress.Text.Length>4 && EmailAdress.Text.Contains("@")&& EmailAdress.Text.Contains("."))
            {

            }else
            {
                errorbool = true; errors += "Некорректный ввод Email\n";
            }
            //Проверка Пароля
            if(Password.Text.Length >= 6)
            {
                bool numberinpassword = false;
                bool charinpassword = false;
                bool symbolsinpassword = false;
                foreach(char c in Password.Text)
                {
                    if (char.IsLetter(c))
                        charinpassword = true;
                    if (!char.IsLetter(c))
                        numberinpassword = true;
                    //! @ # $ % ^
                    if (c == '!' || c == '@' || c == '#' || c == '$' || c == '%' || c == '^')
                        symbolsinpassword = true;
                }
                if(numberinpassword && charinpassword && symbolsinpassword)
                { }
                else { errorbool = true; errors += "Небезопасный пароль\n"; }
            }
            else
            {
                errorbool = true;
                errors += "Слишком короткий пароль🌚\n";
            }
            //проверка повторного пароля
            if(Password.Text == PasswordRepeat.Text)
            {
                //ок
            }
            else
            {
                errorbool = true;
                errors += "Пароли не совпадают\n";
            }
            //проверка имени
            if(Name.Text.Length >3)
            {
                bool check = false;
                foreach(char c in Name.Text)
                {
                    if (!char.IsLetter(c))
                        check = true;
                }
                if (check)
                {
                    errorbool = true;
                    errors += "Некорректный ввод имени\n";
                }
            }
            else {
                errorbool = true;
                errors += "Некорректный ввод имени\n";
            }
            //Проверка фамилии
            if (LastName.Text.Length > 3)
            {
                bool check = false;
                foreach (char c in LastName.Text)
                {
                    if (!char.IsLetter(c))
                        check = true;
                }
                if (check)
                {
                    errorbool = true;
                    errors += "Некорректный ввод фамилии\n";
                }
            }
            else
            {
                errorbool = true;
                errors += "Некорректный ввод фамилии\n";
            }
            //проверка пола🌚
            if(SEX.SelectedItem != null)
            {
                //Ок
            }
            else {
                errorbool = true;
                errors += "Не выбран пол\n";
            }
            //проверка даты рождения
            DateTime date = new DateTime();
            if(DateTime.TryParse(BirthDate.Text, out date))
            {

            }else
            {
                errorbool = true;
                errors += "Некорректный ввод даты\n";
            }
            //проверка страны(потом из бд)
            if(Country.SelectedItem != null)
            {

            }else
            {
                errorbool = true;
                errors += "Не выбрана страна\n";
            }
            //Вывод ошибок (если есть)
            if (errorbool)
            {
                MessageBox.Show(errors);
            }
            else
            {
                //нормалды
                //Регистрация
            }
        }

        /// <summary>
        /// Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            RunnerMain info = new RunnerMain();
            this.NavigationService.Navigate(info);
        }

        /// <summary>
        /// Имя файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SponsorName_Copy4_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            PhotoPath.Text = "";
        }

        /// <summary>
        /// Дата рождения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BirthDate_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BirthDate.Text = "";
        }

        /// <summary>
        /// Просмотр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Text documents (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.FilterIndex = 2;
            Nullable<bool> result = dialog.ShowDialog();
            if (result == true)
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(dialog.FileName);
                img.EndInit();
                Photo.Source = img;                
            }
        }
    }
}
