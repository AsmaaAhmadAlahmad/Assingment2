using Assingment2_Data;
using Assingment2_Domain;
using Assingment2_Domain.Handlers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Assingment2App
{
    internal class Program
    {
        static void Main(string[] args)
            
        {

            //ماتم طلبه في الطلب الاخير 

            ////اضافة مصنع 
            Supplier supplier1 = new Supplier()
            {
                Name = "YousefAlahmed",
                Address = "Homs",
                Parts = new List<Part>
                  {
                      new Part
                      {
                          Name="Filters",Quantity=100,Price="603$"
                      },
                  }
            };
            SupplierHandler supplierHandler1 = new SupplierHandler();
            supplierHandler1.AddSupplier(supplier1);


            ////اضافة سيارة
            Car car1 = new Car
            {
                Model = "Honda Accord2005",
                Gear = "Automatic",
                Km = 60.43
                ,
                Year = 2004,
                Parts = new List<Part>
                {
                    new Part {Name="Car Radio" , Price="384$",Quantity=80 ,SupplierId=2},
                    new Part {Name="Car Glass" , Price="123$",Quantity=40 ,SupplierId=3 } ,
                }
            };
            CarHandler carHandler1 = new CarHandler();
            carHandler1.CarAdd(car1);

            ////اضافة جزء 
            Part part1 = new Part
            {
                Name = "Oil Filter2",
                Price = "200$",
                Quantity = 324,
                SupplierId = 5,
                Cars = new List<Car>
                      {
                          new Car { Model="Jeep Wrangler2005",Gear="Automatic",Km=40,Year=2005},
                          new Car { Model="Tesla Model S2006",Gear="Automatic",Km=60,Year=2006}

                   }

            };
            PartHandler partHandler1 = new PartHandler();
            partHandler1.AddParts(part1);




































            //            //this is test 
            //            //for the car class

            //            Car car = new Car
            //            {
            //                Model = "Audi A1",
            //                Gear = "Automatic",
            //                Km = 100.43,
            //                Parts = new List<Part>
            //                {
            //                    new Part {Name="Engine" , Price="800",Quantity=30 ,SupplierId=1},
            //                    new Part {Name="light" , Price="200$",Quantity=10 ,SupplierId=1 } ,
            //                }
            //            };
            //            CarHandler carHandler = new CarHandler();
            //            carHandler.GetCars();
            //            carHandler.CarDelete("Audi A4");
            //            carHandler.CarAdd(car);
            //            carHandler.CarUpdate("model", " Range Rover", " Range Rover2009");



            //        //    for the customer class
            //             Customer Anas = new Customer
            //             {
            //                 Name = "Anas",
            //                 Address = "Idleb",
            //                 Age = 28,
            //                 Sales = new List<Sales>//ارقام السيارات التي لهذا الزبون لايمكنني وضعها لزبون اخر لان 
            //                                             //العلاقة بين جدول المبيعات والسيارت  1 الى 1  
            //                                           //يعني بأن السيارة يتم بيعها مرة واحدة
            //                                           //والا ستظهر رسالة للمستخدم بأن السيارة تم
            //                                           //بيعها سابقا
            //                                  {
            //                     new Sales { Total = "53.2", CarId = 52 },
            //                     new Sales { Total = "57.2", CarId = 53 }

            //                 }

            //             };
            //Customer Samer = new Customer//أنشأت هذا الزبون لكني لم اضيفه بعد
            //{
            //    Name = "Samer",
            //    Address = "Idleb",
            //    Age = 28,
            //    Sales = new List<Sales>//ارقام السيارات التي لهذا الزبون لايمكنني وضعها لزبون اخر لان 
            //                                             //العلاقة بين جدول المبيعات والسيارت  1 الى 1  
            //                                           //يعني بأن السيارة يتم بيعها مرة واحدة
            //                                           //والا ستظهر رسالة للمستخدم بأن السيارة تم
            //                                           //بيعها سابقا
            //                                  {
            //                                      new Sales {Total="53.2" ,CarId=50},
            //                                      new Sales {Total= "57.2",CarId=51}

            //                                  }

            //};
            //CustomerHandler customerHandler = new CustomerHandler();
            //customerHandler.AddCustomer(Anas);
            //// customerHandler.UpdateCustomer("Name", "Anas", "Asmaa");
            //customerHandler.DeleteCustomer("Anas");
            //customerHandler.GetCustomer();



            ////for the part class
            //                     Part part = new Part
            //                     {
            //                         Name = "Wheels",
            //                         Price = "100$",
            //                         Quantity = 1000,
            //                         SupplierId = 1,
            //                         Cars = new List<Car>
            //                         {
            //                                            new Car { Model=" Range Rover",Gear="Automatic",Km=80,Year=2000},
            //                                            new Car { Model="Mercedes-Benz",Gear="Automatic",Km=80,Year=1993}

            //                         }

            //                     };
            //PartHandler handler = new PartHandler();
            ////handler.AddParts(part);
            ////handler.GetParts();
            ////handler.UpdateParts("Quantity", 1000, 500);
            //handler.RemoveParts("Wheels");

            ////for the sale class
            //SalesHandler saleHandler = new SalesHandler();
            ////saleHandler.GetSales();
            //Sales sales = new Sales//رقم السيارة التي لعملية البيع هذه لايمكنني وضعها لعملية اخرى لان 
            //                       //العلاقة بين جدول المبيعات والسيارت  1 الى 1  
            //                       //يعني بأن السيارة يتم بيعها مرة واحدة فقط
            //                       //والا ستظهر رسالة للمستخدم بأن السيارة تم
            //                       //بيعها سابقا
            //{
            //    Total = "234.6",
            //    CarId = 43,
            //    CustomerId = 27,
            //};
            //Sales sales2 = new Sales//هذه لم اقم بإضافتها بعد
            //{
            //    Total = "234.6",
            //    CarId = 43,
            //    CustomerId = 27,
            //};
            //saleHandler.AddSales(sales);
            //saleHandler.UpdateSales("total", "234.6", "547.8");
            //saleHandler.GetSales();

            ////for supplier class
            //SupplierHandler supplierHandler = new SupplierHandler();
            ////supplierHandler.GetSupplier();

            //Supplier supplier = new Supplier()
            //{
            //    Name = "Ahmed",
            //    Address = "Idleb",
            //    Parts = new List<Part>
            //                  {
            //                      new Part
            //                      {
            //                          Name="Battery",Quantity=34,Price="400$"
            //                      },
            //                  }
            //};
            //supplierHandler.AddSupplier(supplier);
            //supplierHandler.DeleteSupplier("osame");
            //supplierHandler.UpdateSupplier("name", "Ahmed", "osame");

        }
    }
}