using ProjektProgramowanie.Infrastructure;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            Workers_Window w = new Workers_Window();
            w.Show();
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsAnyWorkerInDb())
            {
                AddTask_Window w = new AddTask_Window();
                w.ShowDialog();
            }
            else
            {
                MessageBox.Show("You have to add a worker before creating a task", Title);
            }
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            ToDoItem selectedRecord = xamlDataGrid.SelectedItem as ToDoItem;
            AddTask_Window w = new AddTask_Window(selectedRecord);
            w.ShowDialog();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (xamlDataGrid.SelectedItem as ToDoItem).Id;
            var deleteItem = db.ToDoItems.Where(item => item.Id == id).Single();
            db.ToDoItems.Remove(deleteItem);
            db.SaveChanges();
            xamlDataGrid.ItemsSource = db.ToDoItems.ToList();
        }
        private bool IsAnyWorkerInDb()
        {
            var workerNum = db.Workers.ToArray();
            return (workerNum.Length > 0);
        }
    }
}