/*
 * Class that handles checking of input
*/
using System;
using System.Collections.Generic;

namespace Lab1
{
    class BusinessLogic : IBusinessLogic
    {
        IDatabase db;
        public int clueMax = 250, ansMax = 21, dateLength = 10, difMin = 1, difMax = 5;
        public BusinessLogic(Database db)
        {
            this.db = db;
        }

        /*
         * Method that is called when List Entries is chosen.
         * Displays entries.
         */
        public List<Entry> GetEntries(string orderBy)
        {
            return db.GetEntries(orderBy);
        }


        /*
         * Method that is called when option 2 is chosen.
         * Checks all inputs for validity, adds to database if valid.
         */
        public String Add(string clue, string ans, int dif, string date)
        {
            if (clue.GetType() != typeof(string))
            {
                return "Error: Clue must be a string";
            }
            if (clue == "" || clue.Length > clueMax)
            {
                return "Error: Invalid clue length";
            }
            if (ans.GetType() != typeof(string))
            {
                return "Error: Answer must be a string";
            }
            if (ans == "" || ans.Length > ansMax)
            {
                return "Error: Invalid answer length";
            }
            if (dif > difMax || dif < difMin )
            {
                return "Error: Invalid difficulty";
            }
            if (date.Length != dateLength)
            {
                return "Error: Date must be in format dd/mm/yyyy";
            }
            db.Add(clue, ans, dif, date);
            return "Successful add; list entries again to refresh";

        }

        /*
         * Method to delete an entry.
         */
        public String Delete(int id)
        {
           return db.Delete(id);
        }
        /*
         * Method to edit an entry.
         * Input checked for validity.
         */
        public String Edit(string clue, string ans, int dif, string date, int id)
        {
            if (clue.GetType() != typeof(string))
            {
                return "Error: Clue must be a string";
            }
            if (clue == "" || clue.Length > clueMax)
            {
                return "Error: Invalid clue length";
            }
            if (ans.GetType() != typeof(string))
            {
                return "Error: Answer must be a string";
            }
            if (ans == "" || ans.Length > ansMax)
            {
                return "Error: Invalid answer length";
            }
            if (dif > difMax || dif < difMin)
            {
                return "Error: Invalid difficulty";
            }
            if (date.Length != dateLength)
            {
                return "Error: Date must be in format dd/mm/yyyy";
            }
            return db.Edit(clue, ans, dif, date, id);
        }
    }
}