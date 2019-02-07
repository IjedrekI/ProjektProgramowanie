using ProjektProgramowanie.Infrastructure;
using ProjektProgramowanie.Infrastructure.Entities;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ProjektProgramowanie
{
    /// <summary>
    /// Logika interakcji dla klasy AddWorker_Window.xaml
    /// </summary>
    public partial class AddWorker_Window : Window
    {
        private Worker worker;
        private bool isEdited;
        ToDoContext db = new ToDoContext();

        public AddWorker_Window() //Adding worker
        {
            InitializeComponent();
            isEdited = false;
        }
        public AddWorker_Window(Worker selectedWorker) //Editing worker
        {
            InitializeComponent();
            worker = selectedWorker;
            isEdited = true;
            Title = "Edit a worker";
            LoadDefaultInputValues(worker);
        }
        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!isEdited)
            {
                worker = new Worker();
            }

            SaveInputDataToObj(worker);
            db.Workers.AddOrUpdate(worker);
            db.SaveChanges();
            Workers_Window.dataGrid.ItemsSource = db.Workers.ToList();
            MainWindow.dataGrid.ItemsSource = db.ToDoItems.ToList();
            Hide();
        }
        private void SaveInputDataToObj(Worker worker)
        {
            worker.Name = nameInput.Text;
        }
        private void LoadDefaultInputValues(Worker selectedWorker)
        {
            nameInput.Text = selectedWorker.Name;
        }
    }
}