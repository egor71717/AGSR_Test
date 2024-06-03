using Db;
using Db.Models;

var rand = new Random();
var patients = new List<Patient>();
for (int i = 0; i < 100; i++)
{
    var patient = new Patient()
    {
        Active = Active.valueList[rand.Next(Active.valueList.Count() - 1)],
        Gender = Gender.valueList[rand.Next(Gender.valueList.Count() - 1)]
    };
}

var db = new AGSR_Context("Host=localhost; Database=AGSR; Username=postgres; Password=postgres");
Console.WriteLine("Hello, World!");
