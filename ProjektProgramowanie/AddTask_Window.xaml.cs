using ProjektProgramowanie.Infrastructure;
using ProjektProgramowanie.Infrastructure.Entities;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace ProjektProgramowanie
{
    /// <summary>
    /// Logika interakcji dla klasy AddTask_Window.xaml
    /// </summary>
    public partial class AddTask_Window : Window
    {
        ToDoContext context = new ToDoContext();
        private ToDoItem selectedRecord;
        bool isEdited = false;

        public AddTask_Window()//Add item
        {
            InitializeComponent();
            LoadAvailableWorkers();
        }
        public AddTask_Window(ToDoItem selectedRecord)//Edit item
        {
            InitializeComponent();
            LoadAvailableWorkers();
            this.selectedRecord = selectedRecord;

            isEdited = true;
            Title = "Edit a task";

            //load data to inputs
            nameInput.Text = selectedRecord.Name;
            //shopInput.SelectedItem = selectedRecord.Shop;
            quantityInput.Text = selectedRecord.Quantity.ToString();
            notesInput.Text = selectedRecord.Notes;
            dateInput.SelectedDate = selectedRecord.Date;
            workerInput.SelectedItem = selectedRecord.WorkerId;

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

            if (isEdited)
            {
                selectedRecord.Name = nameInput.Text;
                selectedRecord.Shop = shop;
                selectedRecord.Quantity = int.Parse(quantityInput.Text);
                selectedRecord.Notes = notesInput.Text;
                selectedRecord.Date = dateInput.SelectedDate.Value.Date;
                selectedRecord.WorkerId = hardCodedWorker.Id;
            
            } else
            {
                ToDoItem item = new ToDoItem() //add validation
                {
                    //Name = nameInput.Text,
                    //Shop = shop,
                    //Quantity = int.Parse(quantityInput.Text),
                    //Notes = notesInput.Text,
                    //Date = dateInput.SelectedDate.Value.Date,
                    //WorkerId = hardCodedWorker.Id
                };
                item.Name = nameInput.Text;
                item.Shop = shop;
                item.Quantity = int.Parse(quantityInput.Text);
                item.Notes = notesInput.Text;
                item.Date = dateInput.SelectedDate.Value.Date;
                item.WorkerId = hardCodedWorker.Id;
                context.ToDoItems.Add(item);
            }

            context.SaveChanges();
            MainWindow.dataGrid.ItemsSource = context.ToDoItems.ToList();
            Hide();
        }
        private void LoadAvailableWorkers()
        {
            var workerList = (from w in context.Workers
                      select w).ToList();
            workerInput.ItemsSource = workerList;
            workerInput.DisplayMemberPath = "Name";
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}