using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Practical_13.Models.entities
{
    public class Employees_Task2
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="varchar")]
        [StringLength(50)]
        public string First_name { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Middle_name { get; set; }


        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Last_name { get; set; }

        [Required]
        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(10)]
        public string MobileNumber { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "decimal")]
        public decimal Salary { get; set; }

        
        public int? DesignationId { get; set; }

        [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }   
    }

}
