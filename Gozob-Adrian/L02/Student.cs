using System;

namespace L02
{
    public class Student
    {
        public int Id { get; set; }
        public String Nume { get; set; }
        public String Facultate { get; set; }
        public int An { get; set; }

        public Student (int id = 0, string nume = "", string faculatate = "", int an = 1) {
            Id = id;
            Nume = nume;
            Facultate = faculatate;
            An = an;
        }

        public Student() {}
    }
}
