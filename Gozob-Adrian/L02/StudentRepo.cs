using System;
using System.Collections.Generic;


namespace L02
{
    public class StudentRepo {
        private static Random random = new Random();

        private static String[] Nume = new[]
        {
            "Ion", "Alex", "Gigel", "Bob"
        };

        private static String[] Facultati = new[]
        {
            "AC", "ETC", "Mecanica"
        };

        public static List<Student> list = new List<Student>()
        {
            new Student(1, Nume[random.Next(Nume.Length)], Facultati[random.Next(Facultati.Length)], random.Next(4) + 1),
            new Student(2, Nume[random.Next(Nume.Length)], Facultati[random.Next(Facultati.Length)], random.Next(4) + 1),
            new Student(3, Nume[random.Next(Nume.Length)], Facultati[random.Next(Facultati.Length)], random.Next(4) + 1)
        };
    }
}