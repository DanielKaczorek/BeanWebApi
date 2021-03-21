using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BeanWebApi.Models
{
    public class Bean
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Aroma { get; set; }
        [Required]
        public string Colour { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public double Cost { get; set; }
    }
}
