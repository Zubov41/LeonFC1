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
using LeonFC.ClassHelper;

namespace LeonFC.Windows
{
    /// <summary>
    /// Логика взаимодействия для ServiceListWindow.xaml
    /// </summary>
    public partial class ClientList : Window
    {
        public ClientList()
        {
            InitializeComponent();
            GetClientList();

        }

        private void GetClientList()
        {
            List<Client> ClientList = new List<Client>();

            ClientList = EFClass.context.Client.ToList();

            // фильтрация, поиск и сортировку


            //поиск
            ClientList = ClientList.Where(i => i.FirstName.ToLower().Contains(TbSearch.Text.ToLower())).ToList();

            lvClient.ItemsSource = ClientList;
        }

        private void BtnAddClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var service = button.DataContext as Service;


            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow(service);
            addEditServiceWindow.ShowDialog();

            GetClientList();
        }

        private void lvClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetClientList();    
        }

        private void TbSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
