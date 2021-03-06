namespace LearnEF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HumanResources.Employee_Temporal")]
    public partial class Employee_Temporal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        [Required]
        [StringLength(15)]
        public string NationalIDNumber { get; set; }

        [Required]
        [StringLength(256)]
        public string LoginID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public short? OrganizationLevel { get; set; }

        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(1)]
        public string MaritalStatus { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime HireDate { get; set; }

        public short VacationHours { get; set; }

        public short SickLeaveHours { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidFrom { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ValidTo { get; set; }
    }
}
