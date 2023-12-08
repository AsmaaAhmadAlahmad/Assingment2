using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assingment2_Domain
{
    public class Sales
    {
        public int Id { get; set; }
        public string Total { get; set; }
        public bool IsDeleted { get; set; } = false;

        public int CustomerId { get; set; }// لاجل العلاقة مع الزبائن
        public Customer Customers { get; set; }// لاجل العلاقة مع الزبائن
        public int CarId { get; set; }// لاجل العلاقة مع جدول السيارات
        public Car Car { get; set; }// لاجل العلاقة مع جدول السيارات

    }
}
