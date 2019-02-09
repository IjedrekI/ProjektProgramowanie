using ProjektProgramowanie.Infrastructure;
using ProjektProgramowanie.Infrastructure.Entities;
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

namespace ProjektProgramowanie
{
    /// <summary>
    /// Logika interakcji dla klasy Workers_Window.xaml
    /// </summary>
    public partial class Workers_Window : Window
    {
        ToDoContext dB = new ToDoContext();
        public static DataGrid dataGrid;

        private int _page = 1;


        public Workers_Window()
        {
            InitializeComponent();
            LoadDbData(_page);
        }

        private void LoadDbData(int pageNumber)
        {
            xamlDataGrid.ItemsSource = null;
            var pageSize = 3; //shows 3 elements per page
            var skip = pageSize * (pageNumber - 1);

            xamlDataGrid.ItemsSource = dB.Workers.ToList()
                .Skip(skip)
                .Take(pageSize);

            dataGrid = xamlDataGrid;
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWorker_Window w = new AddWorker_Window();
            w.ShowDialog();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Worker selectedRecord = xamlDataGrid.SelectedItem as Worker;
            AddWorker_Window w = new AddWorker_Window(selectedRecord);
            w.ShowDialog();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (xamlDataGrid.SelectedItem as Worker).Id;
            var deleteItem = dB.Workers.Where(item => item.Id == id).Single();
            dB.Workers.Remove(deleteItem);
            dB.SaveChanges();
            xamlDataGrid.ItemsSource = dB.Workers.ToList();
            MainWindow.dataGrid.ItemsSource = dB.ToDoItems.ToList();
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            _page++;
            LoadDbData(_page);
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (_page == 1)
                return;
            _page--;
            LoadDbData(_page);
        }
        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            var w = new FindWorker_Window();
            w.Show();
        }
    }
}