using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NoteBook.Models
{
    public class User
    {        
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите Фамилию!")]
        [Display(Name = "Фамилия:")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Введите Имя!")]
        [Display(Name = "Имя:")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Введите Email!")]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль! Пароль должен быть не меньше 6 символов, содержать буквы нижнего и верхнего регистров и один спецсимвол.")]
        [Display(Name = "Пароль:")]
        public string Password { get; set; }
    }

    public class Login
    {
        [Required(ErrorMessage = "Введите Email!")]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите пароль! Пароль должен быть не меньше 6 символов, содержать буквы нижнего и верхнего регистров и один спецсимвол.")]
        [Display(Name = "Пароль:")]
        public string Password { get; set; }
    }

    public class RestorePass
    {
        [Required(ErrorMessage = "Введите логин!")]
        [Display(Name = "Логин:")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите текущий пароль! Пароль должен быть не меньше 6 символов, содержать буквы нижнего и верхнего регистров и один спецсимвол.")]
        [Display(Name = "Текущий Пароль:")]
        public string OldPassword { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Введите новый пароль! Пароль должен быть не меньше 6 символов, содержать буквы нижнего и верхнего регистров и один спецсимвол.")]
        [Display(Name = "Новый Пароль:")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Passwd", ErrorMessage = "Пароли не совпадают")]
        [Display(Name = "Новый Пароль:")]
        public string ConfirmPassword { get; set; }
    }
}
