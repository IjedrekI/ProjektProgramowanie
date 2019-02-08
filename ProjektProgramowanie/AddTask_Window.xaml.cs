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
        static ToDoContext db = new ToDoContext();
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
        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AreInputsValid())
            {
                if (!isEdited)
                {
                    item = new ToDoItem();
                }

                SaveInputDataToObj(item);
                db.ToDoItems.AddOrUpdate(item);
                db.SaveChanges();
                MainWindow.dataGrid.ItemsSource = db.ToDoItems.ToList();
                Hide();
            }
            else
            {
                MessageBox.Show("Plese complete all data");
            }
        }

        private bool AreInputsValid()
        {
            return (nameInput.Text != ""
                && shopInput.SelectedItem != null
                && quantityInput.Text != ""
                && notesInput.Text != ""
                && dateInput.SelectedDate != null
                && workerInput.SelectedItem != null);
        }

        private void LoadAvailableWorkers()
        {
            var workerList = (from w in db.Workers
                      select w).ToList();
            workerInput.ItemsSource = workerList;
            workerInput.DisplayMemberPath = "Name";
            workerInput.SelectedValuePath = "Id";
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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
            item.WorkerId = int.Parse(workerInput.SelectedValue.ToString());
        }
    }
}