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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ProjektProgramowanie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            var context = new ToDoContext();

            var shopInString = shopTextBox.Text;
            Enum.TryParse(shopInString, out Shop shop);

            Worker worker = new Worker()
            {
                Name = "Stefan"
            };

            ToDoItem item = new ToDoItem()
            {
                Name = nameTextBox.Text,
                Shop = shop,
                Quantity = int.Parse(quantityBox.Text),
                //Notes = notesTextBox.Text,
                //Date = datenotesTextBox.Text
                WorkerId = worker.Id

            };


            context.Workers.Add(worker);
            context.ToDoItems.Add(item);
            context.SaveChanges();

        }
    }
}
