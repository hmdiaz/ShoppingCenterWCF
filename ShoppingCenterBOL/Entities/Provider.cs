using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterBOL.Entities
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }

        [StringLength(50)]
        [Required]
        public string ProviderName { get; set; }

        //----------------Navigation Property----------------//
        public ICollection<Product> Products { get; set; }
    }
}