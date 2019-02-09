using ProjektProgramowanie.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaction logic for FindWorker.xaml
    /// </summary>
    public partial class FindWorker_Window : Window
        
    {
        ToDoContext db = new ToDoContext();
        public FindWorker_Window()
        {
            InitializeComponent();
        }
        private async void findBtn_Click(object sender, RoutedEventArgs e)
        {
            var name = nameInput.Text;
            if(name=="")
            {
                MessageBox.Show("Provide data ");
                return;
            }

            var result = await db.Workers.FirstOrDefaultAsync(w => w.Name == name);

            if(result == null)
            {
                MessageBox.Show("Worker not found");
                return;
            }

            ifFound.Text = $"Worer {result.Name} with id {result.Id} found";
        }


    }
}
