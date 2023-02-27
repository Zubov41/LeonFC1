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
using System.Windows.Shapes;

using LeonFC.DataBase;
using LeonFC.Windows;

namespace LeonFC.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // авторизация
            // 1. получить всех пользователей!
            // 2. выбрать пользователей по условию 
            // 3. из итогового списка выбрать одну запись 
            //

            var authUser = ClassHelper.EFClass.context.Client.ToList()
                .Where(i => i.Login == TbLogin.Text && i.Password == TbPassword.Text)
                .FirstOrDefault();

            if (authUser != null)
            {
                // переход на нужное окно
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Пользователь не найден");
            }
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            RegistrationClientWindow registrationClientWindow = new RegistrationClientWindow();
            registrationClientWindow.ShowDialog();
        }
    }
}