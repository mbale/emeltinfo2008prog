using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace emeltinfo2008
{
    class Program
    {
        static void Main(string[] args)
        {
            #region "1. Feladat"
            List<SMS> messages = new List<SMS>();

            List<string> file =  new List<string>(File.ReadAllLines("data/sms.txt"));
            file.RemoveAt(0);

            for (int i = 1; i < file.Count; i+=2)
            {                
                string[] buffer = file[i-1].Split(' ');

                string hour = buffer[0];
                string minute = buffer[1];
                string number = buffer[2];
                DateTime format = new DateTime().AddYears(2012).AddHours(double.Parse(hour)).AddMinutes(double.Parse(minute));

                string message = file[i];

                messages.Add(new SMS() { Hour = hour, Minute = minute, Number = number, HourMinuteFormat = format, Message = message});
            }
            #endregion

            #region "2. Feladat"
            Console.WriteLine("2. Feladat:");
            Console.WriteLine("A legfrisebb üzenet: " + messages.Last().Message);
            #endregion

            #region "3. Feladat"

            SMS leghosszabb = messages.OrderByDescending(sms => sms.Message.Length).First();
            SMS legrovidebb = messages.OrderByDescending(sms => sms.Message.Length).Last();

            Console.WriteLine("3. Feladat");
            Console.WriteLine("A leghosszabb üzenet: " + leghosszabb.Hour + "óra " + leghosszabb.Minute + "perc " + leghosszabb.Number + " számról -" + leghosszabb.Message);
            Console.WriteLine("A legrövidebb üzenet: " + legrovidebb.Hour + "óra " + legrovidebb.Minute + "perc " + legrovidebb.Number + " számról -" + legrovidebb.Message);
            #endregion

            #region "4. Feladat"
            Console.WriteLine("4. Feladat");
            List<SMS> egyhusz = new List<SMS>(messages.Where(sms => sms.Message.Length >= 1 && sms.Message.Length <= 20).ToList());
            List<SMS> huszonegynegyven = new List<SMS>(messages.Where(sms => sms.Message.Length >= 21 && sms.Message.Length <= 40).ToList());
            List<SMS> negyvenegyhatvan = new List<SMS>(messages.Where(sms => sms.Message.Length >= 41 && sms.Message.Length <= 60).ToList());
            List<SMS> hatvanegynyolcvan = new List<SMS>(messages.Where(sms => sms.Message.Length >= 61 && sms.Message.Length <= 80).ToList());
            List<SMS> nyolcvanegyszaz = new List<SMS>(messages.Where(sms => sms.Message.Length >= 81 && sms.Message.Length <= 100).ToList());

            Console.WriteLine("1-20: " + egyhusz.Count + " 21-40: " + huszonegynegyven.Count + " 41-60: " + negyvenegyhatvan.Count + " 61-80: " + hatvanegynyolcvan.Count + " 81-100: " + nyolcvanegyszaz.Count);
            
            #endregion

            

            Console.ReadLine();
        }

        class SMS 
        {
            public string Hour { get; set; }
            public string Minute { get; set; }
            public string Number { get; set; }
            public DateTime HourMinuteFormat { get; set; }
            public string Message { get; set; }
        }
    }
}
