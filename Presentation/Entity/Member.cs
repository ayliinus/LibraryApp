
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Member : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Books { get; set; }
    }
}
