
using System;
using System.ComponentModel.DataAnnotations;


namespace HW5.Models
{
    public class RequestForm
    {
        [Key]
        public int ID { get; set; }

        [Required, Display(Name = "First Name:")]
        [RegularExpression("^[a-zA-Z]{1,20}$", ErrorMessage = "Please Input Your Legal Name")]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name:")]
        [RegularExpression("^[a-zA-Z]{1,20}$", ErrorMessage = "Please Input Your Legal Name")]
        public string LastName { get; set; }

        [Required, Display(Name = "Phone Number:")]
        [RegularExpression("^[0-9]{3}-[0-9]{3}-[0-9]{4}$", ErrorMessage = "Plese Input Phone Number Like: xxx-xxx-xxxx")]
        public string PhoneNumber { get; set; }

        [Required, Display(Name = "Apartment Name:")]
        public string ApartmentName { get; set; }

        [Display(Name = "Unit Number:"), Required]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "Please Input An Integer")]
        public int UnitNumber { get; set; }

        [Required]
        public string Description { get; set; }

        public bool Permission { get; set; }

        [Display(Name = "Submmition Time:")]
        public DateTime DateValue { get; set; } = DateTime.Now;
    }
}