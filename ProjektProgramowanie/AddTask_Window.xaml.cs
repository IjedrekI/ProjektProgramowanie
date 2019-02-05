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
using System.Windows.Shapes;

namespace ProjektProgramowanie
{
    /// <summary>
    /// Logika interakcji dla klasy AddTask_Window.xaml
    /// </summary>
    public partial class AddTask_Window : Window
    {
        ToDoContext context = new ToDoContext();

        public AddTask_Window()
        {
            InitializeComponent();
            LoadAvailableWorkers();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var shopInString = shopInput.Text;
            Enum.TryParse(shopInString, out Shop shop);

            Worker hardCodedWorker = new Worker()
            {
                Name = "Stefan"
            };
            context.Workers.Add(hardCodedWorker);

            ToDoItem item = new ToDoItem() //add validation
            {
                Name = nameInput.Text,
                Shop = shop,
                Quantity = int.Parse(quantityInput.Text),
                Notes = notesInput.Text,
                Date = dateInput.SelectedDate.Value.Date,
                WorkerId = hardCodedWorker.Id
            };


            context.ToDoItems.Add(item);
            context.SaveChanges();
            MainWindow.dataGrid.ItemsSource = context.ToDoItems.ToList();
            Hide();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void LoadAvailableWorkers()
        {
            var workerList = (from w in context.Workers
                      select w).ToList();
            workerInput.ItemsSource = workerList;
            workerInput.DisplayMemberPath = "Name";
        }
    }
}