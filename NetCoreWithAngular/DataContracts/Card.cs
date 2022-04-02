using System.ComponentModel.DataAnnotations;

namespace NetCoreWithAngular.DataContracts
{
    public class Card
    {        
        public Guid Id { get; set; }

        [Required]  
        [StringLength(200, ErrorMessage = "The {0} value cannot exceed {1} characters. ")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int ItemsCount { get; set; } 
    }
}
