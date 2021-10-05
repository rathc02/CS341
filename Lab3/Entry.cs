using System;

/*
 * Class to represent an entry
 */

namespace Lab1
{
	public class Entry
	{
		public string Clue { get; set; }

		public string Answer { get; set; }

		public int Difficulty { get; set; }

		public string Date { get; set; }

		public int Id { get; set; }

		/*
		 * ToString implementation for displaying Entries
		 */
        public override string ToString()
        {
            return $"{Id + 1}. {Clue}, {Answer}, {Difficulty}";
        }

    }
}
