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
    /// Interaction logic for ToDoList.xaml
    /// </summary>
    public partial class ToDoList : Window
    {
        private readonly ToDoContext _db = new ToDoContext();
        public static DataGrid datagrid;

        public ToDoList()
        {
            InitializeComponent();
        }
        private async void Load()
        {
            //myDataGrid.ItemsSource = await _db.ToDoItem.ToListAsync();
            //datagrid = myDataGrid;
        }


    }
}






