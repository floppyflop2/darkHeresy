using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace darkHeresyModel
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DarkHeresyModel())
            {
                //db.PersonalInfos.Add(new PersonalInfo { Id =1 , Name="toto", PersonalGender=Gender.UNDEFINED,
                //    Age=12, Description="blablabalb", Build="huge", Complexion="wow", Hair="brown" });
                db.Tests.Add(new Test { TestName="toto" });
                db.SaveChanges();

                foreach (var pi in db.Tests)
                {
                    Console.WriteLine(pi.TestName);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
    
}
