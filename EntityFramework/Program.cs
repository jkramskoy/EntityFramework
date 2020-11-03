using System;
using System.Linq;
using EntityFramework.EntityFramework;

namespace EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                using var context = new Entity_FrameworkContext();
                var listEmp = context.Employees.ToList();


                listEmp.ForEach(employee => Console.Write($"{employee.FirstName},{employee.LastName} \n"));
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}
