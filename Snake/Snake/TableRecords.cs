using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Snake
{
    class TableRecords
    {
        List<MyRecord> myRecords;

        [Serializable]
        struct MyRecord
        {
            public string Name;
            public int Score;

            public MyRecord(string Name, int Score)
            {
                this.Name = Name;
                this.Score = Score;

            }
        }

        public void Save()
        {
            FileStream fileStream = File.Create("TableRecords.dat");
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            binaryFormatter.Serialize(fileStream, myRecords);
            fileStream.Close();
        }

        public void Load()
        {
            try
            {
                FileStream fileStream = File.OpenRead("TableRecords.dat");
                BinaryFormatter binaryFormatter = new BinaryFormatter();


                myRecords = binaryFormatter.Deserialize(fileStream) as List<MyRecord>;
                fileStream.Close();
            }
            catch
            {
                myRecords = new List<MyRecord>();
            }
        }

        public TableRecords()
        {
            Load();
        }
   
        public void addScore(int Score)
        {
           if(myRecords.Count < 5)
           {
                newRecords(Score);
           }
           else
           {
                bool notRecord = true;
                for (int i = 0; i < myRecords.Count; i++ )
                {
                    if(myRecords[i].Score < Score )
                    {
                        newRecords(Score);
                        notRecord = false;
                        break;
                    }
                    
                }
                if (notRecord)
                {
                    Console.SetCursorPosition(28, 2);
                    Console.WriteLine("SCORE");
                    Console.WriteLine();
                    Console.CursorLeft = 25;
                    Console.WriteLine("You score: {0}", Score);
                    Console.CursorLeft = 23;
                    Console.WriteLine("Press any button.");
                    Console.ReadKey();
                }
            }

            Console.WriteLine("You score: {0}", Score);
        }

        public void newRecords(int Score)
        {
            Console.SetCursorPosition(28, 2);
            Console.WriteLine("SCORE");
            Console.WriteLine();
            Console.CursorLeft = 25;
            Console.WriteLine("New record: {0}", Score);
            Console.WindowTop = 23;
            Console.WriteLine("Enter your name:");  
            Console.CursorLeft = 23;
            Console.CursorVisible = true;

            string Name = Console.ReadLine();
            if(Name.Length > 10)
                Name = Name.Substring(0, 10);
            myRecords.Add(new MyRecord(Name,Score));
            Console.CursorVisible = false;
            Sort();
            if(myRecords.Count > 5 )
            {
                
                myRecords.Remove(myRecords[myRecords.Count - 1]);
            }
            Save();

        }

        private void Sort()
        {
            var sortRecords = from myRecord in myRecords
                              orderby myRecord.Score descending
                              select myRecord;

            foreach (MyRecord record in sortRecords)
            {
                myRecords.Remove(record);
                myRecords.Add(record);
            }
        }

        public void ShowTable()
        {
            Console.Clear();
            Console.SetCursorPosition(28, 2);
            Console.WriteLine("TABLE SCORE");
            Console.CursorLeft = 22;
            Console.WriteLine("┌──┬──────────┬─────┐");
            Console.CursorLeft = 22;
            Console.WriteLine("│{0,-2}│{1,-10}│{2,-5}│", "  ", "Name", "Score");
            
            for (int i = 0; i < myRecords.Count ; i++)
            {
                Console.CursorLeft = 22;
                Console.WriteLine("├──┼──────────┼─────┤");
                Console.CursorLeft = 22;
                Console.WriteLine("│{0,-2}│{1,-10}│{2,-5}│", i+1, myRecords[i].Name, myRecords[i].Score);
            }
            Console.CursorLeft = 22;
            Console.WriteLine("└──┴──────────┴─────┘");
            Console.CursorLeft = 22;
            Console.WriteLine("Press any button.");
            Console.ReadKey();
        }

        public void Reset()
        {
            File.Delete("TableRecords.dat");

            myRecords = new List<MyRecord>();

            Save();
        }
    }
}
