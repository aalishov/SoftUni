using P01_StudentSystem.Data;
using System;
using System.Security.Cryptography.X509Certificates;

namespace P01_StudentSystem
{
    public class Program
    {
        public static void Main()
        {
            StudentSystemContext context = new StudentSystemContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

        }
    }
}
