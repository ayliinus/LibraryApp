using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entity
{
    public class Book : BaseEntity
    {
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}
