
using Assingment2_Data;
using Microsoft.EntityFrameworkCore;

namespace Assingment2_Domain.Handlers;

public class CarHandler
{
    public void GetCars()
    {
        using (Assingment2Context context = new())

        {
           var cars= context.Cars.Where(c => c.IsDeleted == false).Include(c=>c.Parts)
                .ToList();
            if (cars.Any())
            {
                foreach (var item in cars)
                {
                    Console.WriteLine($"The car model is {item.Model}");
                    foreach (var item1 in item.Parts)
                    {
                        Console.WriteLine($"   The car contains this part {item1.Name}");
                    }
                }
            }
            else
                Console.WriteLine("The cars table doesn't has any data!");
        }
    }
    public void CarAdd(Car car)
    {
        using (Assingment2Context context = new())
        
        {
            context.Cars.Add(car);
            context.SaveChanges();
        }
    }
    public void CarDelete(String model)
    {
        using (Assingment2Context context = new())

        {
          var  car = context.Cars.Where(p => p.IsDeleted != true)
                .FirstOrDefault(c => c.Model == model);
            
            if (car != null)//للتأكد من تواجد الموديل  الذي سيدخله المستخدم في قاعدة البيانات
            {
                car.IsDeleted = true;
                //استعلام حتى يتم جلب مبيعات هذا الزبون ثم حذفها ايضا من السطر 49 حتى 55
                context.SaveChanges();

                var Car_sales = context.Sales.Where(s => s.CarId == car.Id).ToList();
                foreach (var item in Car_sales)
                {
                    item.IsDeleted = true;
                    
                }
               
                context.SaveChanges();
            }
            else 
                Console.WriteLine($"There is no car with this model {model}!");
            
        }
    }
    public void CarUpdate(object propertyName, object oldValue , object newValue)
    {
        var oldColor = Console.ForegroundColor;
        using (Assingment2Context context =new())
        {
            string  oldValueAsString="";
            string newValueAsString = "";
            if ((string)propertyName == "model" || (string)propertyName == "Model")
            {
                try
                {
                    oldValueAsString = (string)oldValue;
                    newValueAsString = (string)newValue;
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("In the car update function," +
                        "and to update the model of a car part ,you must enter string values for " +
                     "the old value and the new value");
                }

                var car = context.Cars.FirstOrDefault(c => c.Model == oldValueAsString);

                if (car != null)
                {
                    car.Model = newValueAsString;
                    context.SaveChanges();
                }
                else
                   Console.WriteLine($"There is no car from this model{oldValue}!");
                
            }
            else if ((string)propertyName == "Gear" || (string)propertyName == "Gear")
            {

                try
                {
                    oldValueAsString = (string)oldValue;
                    newValueAsString = (string)newValue;
                }
                catch (InvalidCastException)
                {
                    Console.WriteLine("In the car update function," +
                        "and to update the Gera of a car  ,you must enter string values for " +
                     "the old value and the new value");
                }
                var car = context.Cars.FirstOrDefault(c => c.Gear == oldValueAsString);
                if (car != null)
                {
                    car.Gear = newValueAsString;
                    context.SaveChanges();

                }
                else
                    Console.WriteLine("The specified gear value is not valid!");
                   
            }
            else if ((string)propertyName == "year" || (string)propertyName == "Year")
            {
                int oldValueAsInt = 0;
                int newValueAsInt = 0;
                try
                {
                    oldValueAsInt = (int)oldValue;
                    newValueAsInt = (int)newValue;
                }
                catch (Exception)
                {
                    Console.WriteLine("In the car update function,and to update year of a car, you must enter integer values for " +
                     "the old value and the new value");
                }
                var car = context.Cars.FirstOrDefault(c => c.Year == oldValueAsInt);
                if (car != null)
                {
                    car.Year = newValueAsInt;
                    context.SaveChanges();
                }
                else
                    Console.WriteLine("The specified year value is not valid!");

            }
            else if ((string)propertyName == "Km" || (string)propertyName == "km")
            {
                double oldValueAsDouble = 0.0;
                double newValueAsDouble = 0.0;
                try
                {
                    oldValueAsDouble = (double)oldValue;
                    newValueAsDouble = (double)newValue;
                }
                catch (Exception)
                {
                    Console.WriteLine("In the car update function," +
                        "and to update the km of a car  ,you must enter double values for " +
                     "the old value and the new value");

                }
                var car = context.Cars.FirstOrDefault(c => c.Km == oldValueAsDouble);
                if (car != null)
                {
                    car.Km = newValueAsDouble;
                    context.SaveChanges();
                }
                else
                    Console.WriteLine("The km value is not valid!");
                 
            }
            else
                    Console.WriteLine("The property you entered does not exist in the car class, enter an existing property !");
             
            
            
        }
    }
}
