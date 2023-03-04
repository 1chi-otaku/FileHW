using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace FileHW
{
    class Poetry
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public Poetry() {
            Title = string.Empty;
            Author = string.Empty;
            Year = 0;
            Text =  string.Empty;
            Description = string.Empty;
        }
        public Poetry(string title, string author, int year, string text, string description)
        {
            Title = title;
            Author = author;
            Year = year;
            Text = text;
            Description = description;
        }

        public void Print()
        {
            Console.WriteLine("Title - " + Title);
            Console.WriteLine("Author - " + Author);
            Console.WriteLine("Year – " + Year);
            Console.WriteLine("Text - " + Text);
            Console.WriteLine("Description - " + Description);
        }
        public void Init()
        {
            Console.WriteLine("Enter Title:");
            Title = Console.ReadLine();
            Console.WriteLine("Enter Author: ");
            Author = Console.ReadLine();
            Console.WriteLine("Enter Year: ");
            Year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Text: ");
            Text = Console.ReadLine();
            Console.WriteLine("Enter Description: ");
            Description = Console.ReadLine();
        }

        public override string ToString()
        {
            return "Title - " + Title + "\nAuthor - " + Author + "\nYear - " + Year + "\nText - " + Text + "\nDescription - " + Description + "\n";
        }
    }
    class PoetryCollection
    {
        Poetry[] collection;
        public PoetryCollection()
        {
            collection = new Poetry[1];
            collection[0] = new Poetry();
        }
        public PoetryCollection(int count)
        {
            collection = new Poetry[count];
            for (int i = 0; i < count; i++)
            {
                collection[i] = new Poetry();
            }
        }
        public PoetryCollection(Poetry[] collection)
        {
            this.collection = collection;
        }
        public void Add(Poetry poetry) {
            if (collection == null)
                return;
            collection = collection.Concat(new Poetry[] {poetry}).ToArray();
        }
        public void Delete(int number)
        {
           if(number > collection.Length+1 || number <= 0) return;
            for (int i = number; i < collection.Length-1; i++)
            {
                collection[i] = collection[i + 1];
            }
            Array.Resize(ref collection, collection.Length - 1);
        }
        public void Print()
        {
            for (int i = 0; i < collection.Length; i++)
            {
                Console.WriteLine("--------------------------\n" + (i+1) + "\n");
                Console.WriteLine(collection[i].ToString());
                Console.WriteLine("--------------------------\n");
            }
        }
        public void Search(string search)
        {
            for (int i = 0; i < collection.Length; i++)
            {
                if  (  search == collection[i].Text || search == collection[i].Author
                    || search == collection[i].Title || search == collection[i].Description
                    || search == Convert.ToString(collection[i].Year))
                {
                    collection[i].Print();
                    return;
                }
            }
            Console.WriteLine("Failed.");
        }
        public void WriteToFile(string file)
        {
            StreamWriter sr = new StreamWriter(file, false);
            for (int i = 0; i < collection.Length; i++)
            {
                sr.WriteLine((i + 1));
                sr.Write(collection[i].ToString());
                sr.WriteLine();
            }
            sr.Close();
        }
        public string Report(string file)
        {
            int Title_count = 0, Author_count = 0, Description_count = 0;
            int max_year = collection[0].Year;
            int max_len = collection[0].Text.Length;
            for (int i = 0; i < collection.Length; i++)
            {
                if (!String.IsNullOrEmpty(collection[i].Title))
                    Title_count++;
                if (!String.IsNullOrEmpty(collection[i].Author))
                    Author_count++;
                if (!String.IsNullOrEmpty(collection[i].Description))
                    Description_count++;
                if (collection[i].Year > max_year)max_year = collection[i].Year;
                if (collection[i].Text.Length > max_len) max_len = collection[i].Text.Length;
            }
            string report = "Titles: " + Title_count + "\nAuthors - " + Author_count + "\nDescriptions - " + Description_count + "\nMax Year - " + max_year + "\nThe longest poetry is " + max_len + " characters!";
            Console.WriteLine(report);
            StreamWriter sr = new StreamWriter(file, false);
            sr.WriteLine(report);
            sr.Close();
            return report;
        }
      
    }
}
