using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCenterBOL
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }

        [StringLength(50)]
        [Required]
        public string ProviderName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}