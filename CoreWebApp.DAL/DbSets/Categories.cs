using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.DAL.DbSets
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisaplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
