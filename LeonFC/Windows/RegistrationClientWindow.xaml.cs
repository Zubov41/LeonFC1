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
    /// Логика взаимодействия для RegistrationClientWindow.xaml
    /// </summary>
    public partial class RegistrationClientWindow : Window
    {
        public RegistrationClientWindow()
        {
            InitializeComponent();
            CMBGender.ItemsSource = ClassHelper.EFClass.context.Gender.ToList();
            CMBGender.DisplayMemberPath = "NameGender";
            CMBGender.SelectedIndex = 0;
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {
            // Валидация

            if (string.IsNullOrWhiteSpace(TbLastName.Text))
            {
                MessageBox.Show("Поле фамилия не может быть пустым");
                return;
            }

            // Добавление клиента
            Client client = new Client();

            client.LastName = TbLastName.Text;
            client.FirstName = TbFirstName.Text;
            client.patronymic = TbMiddleName.Text;
            client.Address = TbAddress.Text;
            client.Phone = TbPhone.Text;
            client.DateOfBirth = DPbDateOfBirth.SelectedDate.Value;
            client.PassportSeries = TbSerPass.Text;
            client.PassportNumber = TbNumberPass.Text;
            //client.IDGender = (CMBGender.SelectedItem as Gender).IDGender;

            ClassHelper.EFClass.context.Client.Add(client);

            ClassHelper.EFClass.context.SaveChanges();

            MessageBox.Show("Ok");

        }
    }
}