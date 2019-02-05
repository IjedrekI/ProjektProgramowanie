using ProjektProgramowanie.Infrastructure;
using ProjektProgramowanie.Infrastructure.Entities;
using System.Linq;
using System.Windows;


namespace ProjektProgramowanie
{
    /// <summary>
    /// Logika interakcji dla klasy AddWorker_Window.xaml
    /// </summary>
    public partial class AddWorker_Window : Window
    {
        public AddWorker_Window()
        {
            InitializeComponent();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var context = new ToDoContext();

            Worker worker = new Worker()
            {
                Name = nameInput.Text
            };

            context.Workers.Add(worker);
            context.SaveChanges();
            Workers_Window.dataGrid.ItemsSource = context.Workers.ToList();
            //MainWindow.dataGrid.ItemsSource = context.ToDoItems.ToList();
            Hide();
        }
    }
}