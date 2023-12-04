using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Domain
{
    public class Customer
    {
       
        public Customer() 
        {
           Sales=new List<Sales>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public bool IsDeleted { get; set; } = false;

        public List<Sales> Sales { get; set; }//لاجل العلاقة مع المبيعات
    }
}
