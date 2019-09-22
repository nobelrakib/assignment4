using System;
using System.Collections.Generic;
using System.Text;

namespace assignment4
{
   public class studentbook
    {
        public int studentId { get; set; }
        public int bookId { get; set; }
        public book book { get; set; }
        public student student { get; set; }
        public DateTime issuedate { get; set; }
        public DateTime returneDate { get; set; }
    }
}
