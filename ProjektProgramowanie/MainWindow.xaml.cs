using ProjektProgramowanie.Infrastructure;
using ProjektProgramowanie.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


namespace ProjektProgramowanie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ToDoContext db = new ToDoContext();
        public static DataGrid dataGrid;

        public MainWindow()
        {
            InitializeComponent();
            LoadDbData();
        }
        private void LoadDbData()
        {
            xamlDataGrid.ItemsSource = db.ToDoItems.ToList();
            dataGrid = xamlDataGrid;
        }
        private void WorkerBtn_Click(object sender, RoutedEventArgs e)
        {
            Workers_Window ww = new Workers_Window();
            ww.Show();
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            AddTask_Window atw = new AddTask_Window();
            atw.ShowDialog();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            //int id = (xamlDataGrid.SelectedItem as ToDoItem).Id;
            //EditToDoItemWindow editToDoItemWindow = new EditToDoItemWindow(id);
            //editToDoItemWindow.ShowDialog();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (xamlDataGrid.SelectedItem as ToDoItem).Id;
            var deleteItem = db.ToDoItems.Where(item => item.Id == id).Single();
            db.ToDoItems.Remove(deleteItem);
            db.SaveChanges();
            xamlDataGrid.ItemsSource = db.ToDoItems.ToList();
        }
    }
}