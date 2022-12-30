using System;
using System.ComponentModel.DataAnnotations;

namespace Mrt.Northwind.MvcWepUI.Models
{
    public class RegisterViewModel : IDisposable
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required]
        //[DataType(DataType.Password)]
        //public string ConfirmPassword { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        public void Dispose()
        {
            return;
        }
    }
}
