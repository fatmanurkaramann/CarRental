using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //cartest();
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " : " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);  
            }

           




        }

        private static void cartest()
        {
            CarManager carManager = new CarManager(new EfCarDal());


           //// foreach (var car in carManager.GetAll())
           // {
           //     Console.WriteLine(car.CarName);
           // }
        }
    }
}
