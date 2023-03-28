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
    public partial class ServiceListWindow : Window
    {
        List<string> listSort = new List<string>()
        {
            "По умолчанию",
            "По названию (по возрастанию)",
            "По названию (по убыванию)"
        };
        public ServiceListWindow()
        {
            InitializeComponent();
            GetServiceList();

            CmbSort.ItemsSource = listSort;
            CmbSort.SelectedIndex = 0;

        }

        private void GetServiceList()
        {
            List<Service> serviceList = new List<Service>();

            serviceList = EFClass.context.Service.ToList();

            // фильтрация, поиск и сортировку

            //поиск
            serviceList = serviceList.Where(i => i.NameService.ToLower().Contains(TbSearch.Text.ToLower())).ToList();


            // сортировка
            switch (CmbSort.SelectedIndex)
            {
                case 0:
                    serviceList = serviceList.OrderBy(i => i.IDService).ToList();
                    break;
                case 1:
                    serviceList = serviceList.OrderBy(i => i.NameService).ToList();
                    break;
                case 2:
                    serviceList = serviceList.OrderByDescending(i => i.NameService).ToList();
                    break;
                default:
                    serviceList = serviceList.OrderBy(i => i.IDService).ToList();
                    break;
            }

            lvService.ItemsSource = serviceList;
        }

        private void BtnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow();
            addEditServiceWindow.ShowDialog();

            GetServiceList();
        }

        // редактирование
        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var service = button.DataContext as Service;


            AddEditServiceWindow addEditServiceWindow = new AddEditServiceWindow(service);
            addEditServiceWindow.ShowDialog();

            GetServiceList();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            GetServiceList();
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetServiceList();
        }

        private void BtnCartService_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }

            var service = button.DataContext as Service;

            ClassHelper.CartClass.serviceCart.Add(service);
            MessageBox.Show($"Услуга {service.NameService.ToString()} добавлена");
        }

        private void BtnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            CartWindow cartWindow = new CartWindow();
            cartWindow.ShowDialog();
        }
    }
}