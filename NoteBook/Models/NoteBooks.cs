using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoteBook.Models
{
    public class NoteBooks
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите наименование блокнота!")]
        [Display(Name = "Наименование блокнота:")]
        public string Title { get; set; }
        public DateTime Notebook_date { get; set; }
    }

    public class NoteWithBook
    {

        public NoteWithBook()
        {

        }
        public NoteWithBook(NoteBooks notebook)
        {
            //TO DO: Complete Member Initialization  
            this.NoteBooks = notebook;
        }
        public NoteBooks NoteBooks { get; set; }
        public Note Note { get; set; }
    }
}
