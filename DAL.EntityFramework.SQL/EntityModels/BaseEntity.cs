using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DAL.EntityFramework.SQL
{
    public class BaseEntity
    {
        [Key]
        public string id { get; set; }
        public string Headline { get; set; } 
        //public DateTime CreatedAt { get; set; }

        public BaseEntity()
        {
            //this.id = Guid.NewGuid().ToString();
            //this.CreatedAt = DateTime.Now;
        }
    }
}
