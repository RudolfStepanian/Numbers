using System.ComponentModel.DataAnnotations;

namespace NumbertTestTask.Models
{
    public class NumberConverterModel
    {
        [Required]
        [Range(-1000000000, 1000000000)]
        public decimal Number { get; set; }
    }
}
