using Assingment2_Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Domain.Handlers
{
    public class PartHandler
    {
        public void GetParts()
        {
            using (Assingment2Context context = new())

            {
                var parts = context.Parts.Where(c => c.IsDeleted == false).Include(x => x.Cars).ToList();
                if (parts.Any())
                {
                    foreach (var item in parts)
                    {
                        Console.WriteLine($"This part is {item.Name}");
                        foreach (var item1 in item.Cars)
                        {
                            Console.WriteLine($" The part belongs to this car {item1.Model}");
                        }
                    }

                }
                else
                    Console.WriteLine("The parts table doesn't has any data!");
            }
        }
        public void AddParts(Part part)
        {
            using (Assingment2Context context = new())

            {
                context.Parts.Add(part);
                context.SaveChanges();
            }
        }
        public void RemoveParts(String name)
        {
            using (Assingment2Context context = new())

            {
                var part = context.Parts.Where(p=>p.IsDeleted!=true)
                    .FirstOrDefault(p => p.Name == name);
                if (part != null)
                {
                    part.IsDeleted = true;
                    context.SaveChanges();
                }
                else
                    Console.WriteLine($"This is no part with this name {name}!");
            }
        }
        public void UpdateParts(object NameProperty, object oldValue, object newValue)
        {
            using (Assingment2Context context = new())
            {
                    string oldValueAsString="";
                    string newValueAsString="";
                if ((string)NameProperty == "Name" || (string)NameProperty == "name")
                {
                    try
                    {
                        oldValueAsString = (string)oldValue;
                        newValueAsString = (string)newValue;
                    }
                    catch (InvalidCastException )
                    {
                        Console.WriteLine("In the part update function," +
                            "and to update the name of a car part ,you must enter string values for " +
                         "the old value and the new value");
                    }
                    var part = context.Parts.FirstOrDefault(c => c.Name == oldValueAsString);
                    if (part != null)
                    {
                        part.Name = newValueAsString;
                        context.SaveChanges();
                    }
                    else
                        Console.WriteLine($"This is no part with this name{oldValueAsString}!");

                }
                else if ((string)NameProperty == "Price" || (string)NameProperty == "price")
                {

                    try
                    {
                        oldValueAsString = (string)oldValue;
                        newValueAsString = (string)newValue;
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("In the part update function,and to update the price" +
                            "of a car part,you must enter string values for " +
                         "the old value and the new value");
                    }
                    var part = context.Parts.FirstOrDefault(p => p.Price == oldValueAsString);
                    if (part != null)
                    {
                        part.Price = newValueAsString;
                        context.SaveChanges();

                    }
                    else
                        Console.WriteLine($"This is no part with this price {oldValueAsString}!");

                }
                else if ((string)NameProperty == "Quantity" || (string)NameProperty == "quantity")
                {
                    int oldValueAsInt=0;
                    int newValueAsInt=0;
                    try
                    {
                         oldValueAsInt = (int)oldValue;
                         newValueAsInt = (int)newValue;
                    }
                    catch (Exception) 
                    {
                        Console.WriteLine("In the part update function,and to update the quantity" +
                            "of a car part,you must enter integer values for " +
                         "the old value and the new value");
                    }
                    var part = context.Parts.FirstOrDefault(p => p.Quantity == oldValueAsInt);
                    if (part != null)
                    {
                        part.Quantity = newValueAsInt;
                        context.SaveChanges ();
                    }
                    else
                        Console.WriteLine($"This is no parts with this Quantity{oldValueAsInt}!");

                }
                else    
                 Console.WriteLine("The property you entered does not exist in the car class, enter an existing property !");

            }
        }
    }
}
