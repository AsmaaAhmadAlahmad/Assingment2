using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Domain
{
    public class Part
    {
        public int Id { get; set; }
        public string Name {get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; } = false;

        public List<Car> Cars { get; set; }//لاجل العلاقة مع جدول السيارات
        public int SupplierId { get; set; }//لاجل العلاقة مع جدول الموردين
        public Supplier Supplier { get; set; }//لاجل العلاقة مع جدول الموردين
    }
}
