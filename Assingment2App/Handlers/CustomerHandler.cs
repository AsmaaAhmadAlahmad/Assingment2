using Assingment2_Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Domain.Handlers
{
    public class CustomerHandler
    {
        public void GetCustomer()
        {
            using (Assingment2Context context = new())
            {
               var Customers= context.Customers.Where(c=>c.IsDeleted==false).Include(c => c.Sales).ToList();
                if (Customers.Any())
                {
                    foreach (var item in Customers)
                    {
                        Console.WriteLine("The customer name is " + item.Name);
                        foreach (var item1 in item.Sales)
                        {
                            Console.WriteLine(" Total sales " + item1.Total);
                        }
                    }
                }
                else 
                    Console.WriteLine("The table customer doesn't has any data!"); 
            }
        }
        public void AddCustomer(Customer customer)
        {
            using (Assingment2Context context = new())
            {
                try { 
                  context.Customers.Add(customer);
                   context.SaveChanges();
            }
               
                catch(DbUpdateException) {
                Console.WriteLine("This car has been previously sold!");
            }

            }
        }
        public void DeleteCustomer(String name)
        
        {
            using (Assingment2Context context = new())
            {
                var customer = context.Customers.Where(p => p.IsDeleted != true).FirstOrDefault(c=>c.Name==name);
                if (customer != null)
                { 
                  customer.IsDeleted = true;
                    //استعلام حتى يتم جلب مبيعات هذا الزبون ثم حذفها ايضا من السطر 52 حتى 61
                    var Customer_sales=context.Sales
                        .Where(c=>c.CustomerId==customer.Id).ToList();
                    if (Customer_sales.Any())
                    {
                        foreach (var item in Customer_sales)
                        {
                            item.IsDeleted = true;
                        }
                    }
                  context.SaveChanges();
                }
                else
                    Console.WriteLine("This name doesn't exist to delete!");
            }
        }
        public void UpdateCustomer(object NameProperty, object oldValue , object newValue)
        {
            using (Assingment2Context context = new())
            {
                if ((string)NameProperty == "Name" || (string)NameProperty == "name")
                {
                    string oldValueAsString = "";
                    string newValueAsString = "";
                    try
                    {
                        oldValueAsString = (string)oldValue;
                        newValueAsString = (string)newValue;
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("In the customer update function,and to update name of a customer you must enter string values for " +
                         "the old value and the new value");
                    }
                    var customer = context.Customers.FirstOrDefault(c => c.Name == oldValueAsString);
                    if (customer != null)
                    {
                        customer.Name = newValueAsString;
                        context.SaveChanges();
                    }
                    else
                        Console.WriteLine("This name doesn't exist to updata!");
                }
                else if ((string)NameProperty == "Address" || (string)NameProperty == "address")
                {
                    string oldValueAsString = "";
                    string newValueAsString = "";
                    try
                    {
                        oldValueAsString = (string)oldValue;
                        newValueAsString = (string)newValue;
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("In the customer update function,and to update address of a customer you must enter string values for " +
                         "the old value and the new value");
                    }
                    var customer = context.Customers.FirstOrDefault(c => c.Address == oldValueAsString);
                    if (customer != null)
                    {
                        customer.Address = newValueAsString;
                        context.SaveChanges();

                    }
                    else
                        Console.WriteLine("This address doesn't exist!");
                }
                else if ((string)NameProperty == "Age" || (string)NameProperty == "age")
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
                        Console.WriteLine("In the age update function,and to update the age of a customer you must enter integer values for " +
                         "the old value and the new value");
                    }
                    var customer = context.Customers.FirstOrDefault(c => c.Age == oldValueAsInt);
                    if (customer != null)
                    {
                        customer.Age = newValueAsInt;
                        context.SaveChanges();
                    }
                    else
                        Console.WriteLine("This age doesn't exist");
                }
                else
                    Console.WriteLine("The property you entered does not exist in the car class, enter an existing property !");

            }
        }
    }
}
