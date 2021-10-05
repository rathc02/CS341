using System;
using System.Collections.Generic;
using System.Configuration;
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
using MySql.Data.MySqlClient;
using Lab1;
/*
 * Clayton Rath
 * CS 341
 * 
 * Main window xaml.cs file. Handles button/display functionality
 * 
 * 
 */
namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Database db;
        private BusinessLogic bl;
        /*
         * Main window contructor
         */
        public MainWindow()
        {
            InitializeComponent();
            this.db = new();
            this.bl = new BusinessLogic(db);
            ListEntries.ItemsSource = bl.GetEntries("");
        }

        /*
         * Method to display the current entries in the database
         */
        private void ListAllEntries(object sender, RoutedEventArgs e)
        {
           
            ListEntries.ItemsSource = bl.GetEntries("");
        }
        /*
          * Method to add a new entry to the database
          */
        private void AddEntry(object sender, RoutedEventArgs e)
        {
            AddWindow Add = new();
            Add.Show();
        }
        
        /*
         * Method to update a current entry in the database
         */
        private void UpdateEntry(object sender, RoutedEventArgs e)
        {
            Entry entry = (Entry)ListEntries.SelectedItem;
            if (entry == null)
            {
                MessageBox.Show("Please choose an entry to update");
                return;
            }
            else
            {
                UpdateWindow Update = new(entry);
                Update.Show();
            }
        }

        /*
         * Method to delete a current entry in the database
         */
        private void DeleteEntry(object sender, RoutedEventArgs e)
        {
            Entry entry = (Entry)ListEntries.SelectedItem;
            if (entry == null)
            {
                MessageBox.Show("Please choose an entry to delete");
                return;
            }
            else
            {
                MessageBox.Show(bl.Delete(entry.Id));
            }
        }

        /*
         * Method to terminate the program
         */
        private void Exit(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Happy crosswording :)");
            System.Environment.Exit(0);
        }
        /*
         * Sorts the entries by clue when pressed
         */
        private void SortByClue(object sender, RoutedEventArgs e)
        {
            ListEntries.ItemsSource = bl.GetEntries(" ORDER BY clue");
        }
        /*
         * Sorts the entries by answer when pressed
         */
        private void SortByAnswer(object sender, RoutedEventArgs e)
        {
            ListEntries.ItemsSource = bl.GetEntries(" ORDER BY answer");
        }
    }
}
