using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assingment2_Data;
using Microsoft.EntityFrameworkCore;

namespace Assingment2_Domain.Handlers
{
    public class SalesHandler
    {
        public void GetSales()
        {
            using (Assingment2Context context = new())
            {
                // جلب المبيعات الغير محذوفة 
                var sales = context.Sales.Where(s=>s.IsDeleted==false).ToList();
                if (sales.Any())
                {
                    foreach (var item in sales)
                    {
                        // استعلام لجلب اسم الزبون الذي تمت عملية البيع هذه له وطباعته
                        var customerName = (from customer in context.Customers
                                            where customer.Id == item.CustomerId
                                            select customer.Name
                                        ).FirstOrDefault();
                       // استعلام لمعرفة موديل السيارة التي تم بيعها في عملية البيع هذه وطباعته
                        var carModel = (from car in context.Cars
                                        where car.Id == item.CarId
                                        select car.Model
                                        ).FirstOrDefault();
                        // طباعة اجمالي عملية البيع هذه مع اسم الزبون الذي تمت عملية البيع له
                        // وموديل السيارة التي تم بيعها 
                        Console.WriteLine($"Total amount of the sales {item.Total}," +
                            $" and the customer who bought the car is {customerName}," +
                            $" The model of the car he purchased it {carModel}"
                            );

                    }
                }
                else 
                    Console.WriteLine("The sales table doesn't has any data!");
            }
        }



        // اضافة مبيعات
        public void AddSales(Sales sales)
        {
            using (Assingment2Context context = new())
            {
                try { 
                    context.Sales.Add(sales);
                    context.SaveChanges();
                }
                catch(DbUpdateException) {
                    // في حال تم وضع رقم سيارة تم بيعها سابقا لعملية البيع هذه لان السيارة يتم
                    // بيعها مرة واحدة فقط
                    Console.WriteLine("This car has been previously sold!");
                }
            }
        }



        //لم أكتب دالة الحذف للمبيعات لان السجل سيتم  حذفه
        //حذف ناعم عندما يتم حذف الزبون المتعلق به او السيارة المتعلقة به
        //وقد اخذت هذا في عين الاعتبار في دالة الحذف للزبائن
        //ودالة الحذف للسيارات 
        //public void RemoveSales()
        //{SqlException: Cannot insert duplicate key row in object 'dbo.Sales' with unique index 'IX_Sales_CarId'. The duplicate key value is (43).
        //    using (Assingment2Context context = new())
        //    {

        //    }
        //}




        // دالة تعديل مبيعات 
        // حيث يقوم المستخدم بإدخال اسم الخاصية التي يريد تعديلها ثم يدخل القيمة القديمة للخاصية ثم الجديدة
        // لانه يحوي كل الانواع object لذلك استخدمت النوع  
        public void UpdateSales(object NameProperty, object oldValue, object newValue)
        {
            using (Assingment2Context context = new())
            {
                // total في حال كانت الخاصية التي ادخلها المستخدم هي  
                if ((string)NameProperty == "Total" || (string)NameProperty == "total")
                {
                    string oldValueAsString = "";
                    string newValueAsString = "";

                    try
                    {
                        // تحويل القيمتين القديمة والجديدة الى النوع سترينغ لان خاصية اسم الزبون نوعها سترينغ
                        oldValueAsString = (string)oldValue;
                        newValueAsString   = (string)newValue;
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("In the sales update function," +
                            "and to update the total of a sales  ,you must enter string values for " +
                         "the old value and the new value");
                    }
                    //الذي ادخله المستخدم ليتم تعديله total جلب اول مبيعات تملك ال
                    var sales = context.Sales.Where(c => c.IsDeleted != true).FirstOrDefault(s=>s.Total== oldValueAsString);
                    if (sales != null)
                    {
                        // Total تعديل ال 
                        sales.Total = newValueAsString;
                        context.SaveChanges();
                    }
                    else // الذي ادخله المستخدم غير موجود total في حال كان ال
                        Console.WriteLine($"This total {oldValueAsString} is not valid! ");
                }

                else // في حال كان اسم الخاصية التي ادخلها المستخدم ليست من خصائص المبيعات
                    Console.WriteLine("The property you entered does not exist in the car class, enter an existing property !");

            }
        }
    }
}
