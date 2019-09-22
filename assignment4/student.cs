using System;
using System.Collections.Generic;
using System.Text;

namespace assignment4
{
    public class student
    {
        public int Id { get; set; }
        public int studentId { get; set; }
        public string Name { get; set; }
        public int fine { get; set; } = 0;
        public IList<studentbook> books { get; set; }

    }

}
