using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Data.Models
{
    public class Order
    {
        [BindNever]        
        public int Id { get; set; }

        [Required(ErrorMessage = "Текст не менее символов")]
        [Display(Name="Введите имя")]
        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Текст не менее символов")]
        [Display(Name = "Введите фамилию")]
        [StringLength(30, MinimumLength = 2)]        
        public string Surname { get; set; }


        [Display(Name = "Адрес")]
        [StringLength(30, MinimumLength = 2)]
        [Required(ErrorMessage = "Длинна адреса не менее 4 символов")]
        public string Address { get; set; }


        [Display(Name = "Введите номер телефона")]
        [StringLength(30,MinimumLength = 2)]
        [Required(ErrorMessage = "Длинна номера не менее 9 символов")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(25,MinimumLength =2)]
        [Required(ErrorMessage = "Длинна Email не менее 4 символов")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        
        public List<OrderDetail>? OrderDetails { get; set; }
    }
}
