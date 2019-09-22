using System;
using System.Linq;

namespace assignment4
{
    public class Program
    {
       public static void Main(string[] args)
        {
            var context = new ShoppingContext();
            var multiline = @"Welcome to library system.
                            Please enter your choice:
                           To entry student information enter: 1
                            To entry book information enter: 2
                            To issue a book, enter: 3
                            To return a book enter: 4
                            To check fine, enter: 5
                            To receive fine, enter: 6";

            Console.WriteLine(multiline);
            int num;
            string s = Console.ReadLine();
            int.TryParse(s, out num);
            if (num == 1) studentinfo(context);
            else if (num == 2) bookinfo(context);
            else if (num == 3) issuebook(context);
            else if (num == 4) returnbook(context);
            else if (num == 5) fine(context);
            else if (num == 6) fineamount(context);

        }
        public static void studentinfo(ShoppingContext context)
        {
            Console.WriteLine("Please enter student Id: _");
            int id;
            String s = Console.ReadLine();
            int.TryParse(s, out id);
            Console.WriteLine("Please enter student Name: _");
            String s1 = Console.ReadLine();
            context.Students.Add(new student
            {
                studentId = id,
                Name = s1
            });
            context.SaveChanges();

        }
        public static void bookinfo(ShoppingContext context)
        {
            Console.WriteLine("Please enter book Id: _");
            int id;
            String s = Console.ReadLine();
            int.TryParse(s, out id);
            Console.WriteLine("Please enter bookname: _");
            String n = Console.ReadLine();
            Console.WriteLine("Please enter edition: _");
            String e = Console.ReadLine();
            Console.WriteLine("Please enter barcode: _");
            String c = Console.ReadLine();
            int count;
            String copy = Console.ReadLine();
            int.TryParse(copy, out count);
            context.Books.Add(new book
            {
                bookId= id,
                title = n,
                edition=e,
                barcode=c,
                copycount=count
            });
            context.SaveChanges();

        }
        public static void issuebook(ShoppingContext context)
        {
            Console.WriteLine("Please enter student Id: _");
            int id;
            String s = Console.ReadLine(); int.TryParse(s, out id);
            Console.WriteLine("Please enter barcode: _");
            String c = Console.ReadLine();
            var boi = context.Books.Where(x => x.barcode == c).FirstOrDefault();
            var stu = context.Students.Where(x =>x.studentId ==id ).FirstOrDefault();
            //int idofbook = boi.Id;
            //int idofstudent = stu.Id;
            if (stu == null) Console.WriteLine("invalid id");
            else
            {
                if (boi.copycount > 0)
                {
                    context.Studentbooks.Add(new studentbook
                    {
                        book = boi,
                        student = stu,
                        issuedate = DateTime.Now
                    });
                    context.SaveChanges();
                }
            }

        }
        public static void returnbook(ShoppingContext context)
        {
            Console.WriteLine("Please enter student Id: _");
            int id;
            String s = Console.ReadLine(); int.TryParse(s, out id);
            Console.WriteLine("Please enter barcode: _");
            String c = Console.ReadLine();
            var boi = context.Books.Where(x => x.barcode == c).FirstOrDefault();
            var stu = context.Students.Where(x => x.studentId == id).FirstOrDefault();
            //int idofbook = boi.Id;
            //int idofstudent = stu.Id;
            if (stu == null) Console.WriteLine("invalid id");
            else
            {
                var sb = context.Studentbooks.Where(x => x.student == stu && x.book == boi).FirstOrDefault();
                sb.returneDate =  DateTime.Now;
                int diffrence = (sb.returneDate - sb.issuedate).Days;
                if (diffrence > 7)
                {
                    stu.fine = (diffrence - 7) * 10;
                }
                context.Studentbooks.Remove(sb);
                context.SaveChanges();
            }

        }
        public static void fine(ShoppingContext context)
        {
            Console.WriteLine("Please enter student Id: _");
            int id;
            String s = Console.ReadLine(); int.TryParse(s, out id);
            
            var stu = context.Students.Where(x => x.studentId == id).FirstOrDefault();
            if (stu == null) Console.WriteLine("invalid id");
            else Console.WriteLine(stu.fine);
        }
        public static void fineamount(ShoppingContext context)
        {
            Console.WriteLine("Please enter student Id: _");
            int id;
            String s = Console.ReadLine(); int.TryParse(s, out id);
            Console.WriteLine("Please enter amount");
            int amount;
            String a = Console.ReadLine(); int.TryParse(s, out amount);
            var stu = context.Students.Where(x => x.studentId == id).FirstOrDefault();
            if (stu == null) Console.WriteLine("invalid id");
            else { stu.fine = stu.fine - amount; context.SaveChanges(); }
            
        }


    }
}
