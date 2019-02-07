using ProjektProgramowanie.Infrastructure;
using ProjektProgramowanie.Infrastructure.Entities;
using System.Data.Entity.Migrations;
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
        private ToDoItem item;
        private bool isEdited;

        public AddTask_Window()//Add item
        {
            InitializeComponent();
            LoadAvailableWorkers();
            isEdited = false;
        }
        public AddTask_Window(ToDoItem selectedItem)//Edit item
        {
            InitializeComponent();
            LoadAvailableWorkers();
            item = selectedItem;
            isEdited = true;

            Title = "Edit a task";

            LoadDefaultInputValues(item);
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!isEdited)
            {
                item = new ToDoItem();
            }
              
            SaveInputDataToObj(item);
            context.ToDoItems.AddOrUpdate(item);
            context.SaveChanges();
            MainWindow.dataGrid.ItemsSource = context.ToDoItems.ToList();
            Hide();
        }
        private void SaveInputDataToObj(ToDoItem item)  //add validation
        {
            var shopInString = shopInput.Text;
            Enum.TryParse(shopInString, out Shop shop);

            item.Name = nameInput.Text;
            item.Shop = shop;
            item.Quantity = int.Parse(quantityInput.Text);
            item.Notes = notesInput.Text;
            item.Date = dateInput.SelectedDate.Value.Date;
            item.WorkerId = 6; //hardcoded
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
        private void LoadDefaultInputValues(ToDoItem selectedItem)
        {
            nameInput.Text = selectedItem.Name;
            shopInput.SelectedItem = selectedItem.Shop;
            quantityInput.Text = selectedItem.Quantity.ToString();
            notesInput.Text = selectedItem.Notes;
            dateInput.SelectedDate = selectedItem.Date;
            workerInput.SelectedItem = selectedItem.WorkerId;
        }
    }
}