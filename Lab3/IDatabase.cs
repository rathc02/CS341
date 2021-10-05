/*
 * Interface for Database file
 */

using System;
using System.Collections.Generic;

namespace Lab1
{
    public interface IDatabase
    {
        /*
         * <Method to fetch the entries
         */
        public List<Entry> GetEntries(string orderBy) { return new List<Entry>(); }
        /*
         * Method to add an entry to the database
         */
        public void Add(string clue, string ans, int dif, string date) { }
        /*
         * Method to delete an entry from the database
         */
        public String Delete(int id) { return ""; }
        /*
         * Method to edit an entry in the database
         */
        public String Edit(string clue, string ans, int dif, string date, int id) { return ""; }
    }
}