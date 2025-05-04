namespace studentdbfinal1._0
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Studentquery1
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        public int Age { get; set; }

        [Required]
        [StringLength(10)]
        [RegularExpression(@"^B\d{8}$", ErrorMessage = "BNumber must start with 'B' followed by 8 digits.")]
        public string BNumber { get; set; }

        [Required]
        [StringLength(15)]
        public string Telephone { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public decimal Assessment1Mark { get; set; }

        public decimal Assessment2Mark { get; set; }

        public decimal OverallModuleMark { get; set; }

        // ✅ Add this method to fix the controller error
        public decimal CalculateOverallModuleMark()
        {
            return (Assessment1Mark + Assessment2Mark) / 2;
        }
    }
}
