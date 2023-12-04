using Assingment2_Data;
namespace Assingment2_Domain.Handlers
{
    public class SupplierHandler
    {
        public void GetSupplier()
        {
            using (Assingment2Context context = new())
            {
              var suppliers=  context.Suppliers.ToList();
                if (suppliers.Any())
                {

                    foreach (var item in suppliers)
                    {
                        Console.WriteLine("The supplier name is" + " " + item.Name);

                    }
                }
                else
                 Console.WriteLine("The supplier table doesn't has any data!"); 
                
            }
        }
        public void AddSupplier(Supplier supplier)
        {
            using (Assingment2Context context = new())
            {
                context.Suppliers.Add(supplier);
                context.SaveChanges();
            }
        }
        public void DeleteSupplier (string name)
        {
            using (Assingment2Context context = new())
            {
                var supplier = context.Suppliers.Where(p => p.IsDeleted != true)
                   .FirstOrDefault(s=>s.Name==name);
                if (supplier != null)
                {
                    supplier.IsDeleted = true;
                    //استعلام حتى يتم حذف القطع التي قام بتوريدها هذا الزبون 
                    //كحذف ناعم
                    var ThePartProvidedByThisSupplier = context.Parts.Where(
                   p => p.SupplierId == supplier.Id).ToList();
                    foreach (var item in ThePartProvidedByThisSupplier)
                    {
                        item.IsDeleted = true;
                    }

                    context.SaveChanges();
                }
                else
                    Console.WriteLine($"There is no supplier with this name {name}");
            }
        }
        public void UpdateSupplier(object NameProperty, object oldValue, object newValue)
        {
            using (Assingment2Context context = new())
            {
                    string oldValueAsString = "";
                    string newValueAsString = "";
                if ((string)NameProperty == "Name" || (string)NameProperty == "name")
                {

                    try
                    {
                        oldValueAsString = (string)oldValue;
                        newValueAsString = (string)newValue;
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("In the suppliers update function," +
                            "and to update the name of a supplier  ,you must enter string values for " +
                         "the old value and the new value");
                    }
                    var supplier = context.Suppliers.FirstOrDefault(s => s.Name == oldValueAsString);
                    if (supplier != null)
                    {
                        supplier.Name = newValueAsString;
                        context.SaveChanges();
                    }
                    else
                        Console.WriteLine($"There is no supplier with this name {oldValueAsString}");
                }
                if ((string)NameProperty == "Address" || (string)NameProperty == "address")
                {

                    try
                    {
                        oldValueAsString = (string)oldValue;
                        newValueAsString = (string)newValue;
                    }
                    catch (InvalidCastException)
                    {
                        Console.WriteLine("In the suppliers update function," +
                            "and to update the address of a supplier  ,you must enter string values for " +
                         "the old value and the new value");
                    }
                    var supplier = context.Suppliers.FirstOrDefault(s => s.Address == oldValueAsString);
                    if (supplier != null)
                    {
                        supplier.Address = newValueAsString;
                        context.SaveChanges();
                    }
                    else
                        Console.WriteLine($"There is no supplier with this address {oldValueAsString}");
                }

            }
        }
        
    }
         
}
