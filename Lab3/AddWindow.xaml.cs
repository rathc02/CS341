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
using System.Windows.Shapes;
using Lab1;

/*
 * Add entry functionality. Adds a new entry to the database file. 
 */
namespace Lab3
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        Database db;
        BusinessLogic bl;
        /*
         * AddWindow contructor
         */
        public AddWindow()
        {
            InitializeComponent();
            this.db = new();
            this.bl = new(db);
        }
        /*
         * Method that is called on submit. Adds the new entry to the database
         */
        private void Submit(object sender, RoutedEventArgs e)
        {
            Database db = new();
            BusinessLogic bl = new BusinessLogic(db);
            int dif = 0;
            if (Difficulty.Text.Length != 0)
            {
                dif = Int32.Parse(Difficulty.Text);
            }
            MessageBox.Show(bl.Add(Clue.Text, Answer.Text, dif, Date.Text));
            Close();        
        }
    }
}
