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
        ToDoContext context = new ToDoContext();
        public static DataGrid dataGrid;

        public Workers_Window()
        {
            InitializeComponent();
            LoadDbData();
        }

        private void LoadDbData()
        {
            xamlDataGrid.ItemsSource = context.Workers.ToList();
            dataGrid = xamlDataGrid;
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWorker_Window w = new AddWorker_Window();
            w.ShowDialog();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            var selectedRecord = xamlDataGrid.SelectedItem as Worker;
            //AddWorker_Window w = new AddWorker_Window(selectedRecord);
            //w.ShowDialog();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (xamlDataGrid.SelectedItem as Worker).Id;
            var deleteItem = context.Workers.Where(item => item.Id == id).Single();
            context.Workers.Remove(deleteItem);
            context.SaveChanges();
            xamlDataGrid.ItemsSource = context.Workers.ToList();
            MainWindow.dataGrid.ItemsSource = context.ToDoItems.ToList();
        }
    }
}