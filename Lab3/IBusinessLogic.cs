/*
 * Interface for BusinessLogic file
 */

using System.Collections.Generic;

namespace Lab1
{
    interface IBusinessLogic
    {
        /*
         * Method to display the entries
         */
        public List<Entry> GetEntries()
        {
            return new List<Entry>();
        }
        /*
         * Method to add an entry
         */
        public void Add()
        {
           
        }
        /*
         * Method to delete an entry
         */
        public void Delete()
        {

        }
        /*
         * Method to edit an entry
         */
        public void Edit()
        {

        }
    }
}