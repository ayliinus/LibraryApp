using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class BookListVM
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string BookImage { get; set; }
        public string OnLoan { get; set; }
        public string CustomerName { get; set; }
        public string DeliveryDate { get; set; }
    }
}
