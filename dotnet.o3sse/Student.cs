using System;
using System.Collections.Generic;
using System.Text;

namespace dotnet.o3sse
{
    class Student
    {
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return Firstname + " " + Secondname;
        }
    }
}
