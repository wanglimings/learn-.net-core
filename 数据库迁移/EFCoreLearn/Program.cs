using System;

namespace EFCoreLearn
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db=new AppDbContext())
            {
                db.Books.Add(new Book() { Title = "c#",Description = "c#学习笔记"});
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database",count);
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
