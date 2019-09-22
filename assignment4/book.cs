using System;
using System.Collections.Generic;
using System.Text;

namespace assignment4
{
    public class book
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public string edition { get; set; }
        public string barcode { get; set; }
        public int copycount { get; set; }
        public IList<studentbook> books { get; set; }
    }
}
