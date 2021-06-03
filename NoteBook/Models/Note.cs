using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBook.Models
{
    public class Note
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите наименование заметки!")]
        [Display(Name = "Наименование заметки:")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Напишите что-нибудь в заметке")]
        [Display(Name = "Текст заметки:")]
        public string Note_text { get; set; }
        public DateTime Note_date { get; set; }
        public int Id_user { get; set; }
        public int Id_notepad { get; set; }
    }    
}
