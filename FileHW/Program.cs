using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHW
{
    class Program
    {
        static void Main(string[] args)
        {
            #region #1
            PoetryCollection poetryCollection = new PoetryCollection(0);
            poetryCollection.Add(new Poetry());
            poetryCollection.Add(new Poetry("The Universe", "Dr.Maruki", 2017, "There is no such thing as occultism", "SciFi"));
            poetryCollection.Add(new Poetry("108", "Jine", 2004, "Bla Bla bla", "SciFi"));
            poetryCollection.Add(new Poetry("Amazing Title", null, 2011, "Am amazing Poetry, desu", "Romance"));
            poetryCollection.Print();
            poetryCollection.Report("report.txt");
            #endregion

        }
    }
}
