using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WrapupDemo
{
   

    class Program
    {
        static void Main(string[] args)
        {
            List<PersonModel> people = new List<PersonModel>() 
            {
                 new PersonModel {FirstName = "Shah", LastName = "darn", Email = "ShahHaque123@gmail.com"},
                 new PersonModel {FirstName = "Tim", LastName = "Corey", Email = "IAMTimCorey.com"},
                 new PersonModel {FirstName = "Sue", LastName = "Storm", Email = "SueStorm@gmail.com"},
            };

            List<CarModel> cars = new List<CarModel>()
            { 
                new CarModel {Manufacturer = "Ford", Model = "DARNCorolla" },
                new CarModel {Manufacturer = "Tesla", Model = "FRICKX7" },
                new CarModel {Manufacturer = "BMW", Model = "WH5" }
            };

            DataAccess<PersonModel> PeopleData = new DataAccess<PersonModel>();
            PeopleData.BadEntryFound += Peopledata_BadEntryFound;
            PeopleData.SaveToCSV(people,@"C:\Users\Dell\Documents\FilePath\people.csv");

            DataAccess<CarModel> CarData = new DataAccess<CarModel>();
            CarData.BadEntryFound += CarData_BadEntryFound;
            CarData.SaveToCSV(cars,@"C:\Users\Dell\Documents\FilePath\cars.csv");
            Console.ReadLine();

        }

        private static void CarData_BadEntryFound(object sender, CarModel e)
        {
            Console.WriteLine($"Bad entry for {e.Manufacturer} {e.Model}");
        }

        private static void Peopledata_BadEntryFound(object sender, PersonModel e)
        {
            Console.WriteLine($"Bad entry found for {e.FirstName} {e.LastName}");
        }
    }
}