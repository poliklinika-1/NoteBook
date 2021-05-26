using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NoteBook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NoteBook.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        /*public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        
        string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }

        string p;
        UserContext db;        

        public HomeController(UserContext context)
        {
            db = context;
        }        

        [HttpGet]
        public IActionResult Index()
        {
            var data = DateTime.Now.ToShortDateString();
            var time = DateTime.Now.ToShortTimeString();
            var hour = DateTime.Now.Hour;
            if (hour < 12)
            {
                ViewBag.Message = "Доброе утро!";
            }
            if (hour >= 12 && hour < 18)
            {
                ViewBag.Message = "Добрый день!";
            }
            if (hour >= 18 && hour < 24)
            {
                ViewBag.Message = "Добрый вечер!";
            }
            if (hour >= 24)
            {
                ViewBag.Message = "Добрая ночь!";
            }
            var DataTime = data + ' ' + time;
            ViewBag.Data = DataTime;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login log)
        {
            if (ModelState.IsValid)
            {
                User user = null;
                p = GetHashString(log.Password);
                log.Password = p;                
                using (db)
                {
                    //if (db != null)
                    user = db.Users.FirstOrDefault(u => u.Email == log.Email && u.Password == log.Password);
                }
                if (user != null)
                {
                    //username = user.Email;
                    //HttpContext.Response.Cookies["user"].Value = username;
                    //userid = user.UserId;
                    //HttpContext.Session.SetString(SessionName, userid);   
                    return RedirectToAction("Desktop", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином и паролем не найден!");
                }
            }
            return View(log);
        }


        [HttpGet]
        public IActionResult Register()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {                       
            if (ModelState.IsValid) {
                p = GetHashString(user.Password);
                user.Password = p;
                db.Users.Add(user);
                db.SaveChanges();
            }
                return View(user);
        }

        [HttpGet]
        public IActionResult Desktop()
        {
            var data = DateTime.Now.ToShortDateString();
            var time = DateTime.Now.ToShortTimeString();
            var hour = DateTime.Now.Hour;
            if (hour < 12) 
            {
                ViewBag.Message = "Доброе утро!";
            }
            if (hour >= 12 && hour < 18)
            {
                ViewBag.Message = "Добрый день!";
            }
            if (hour >= 18 && hour < 24)
            {
                ViewBag.Message = "Добрый вечер!";
            }
            if (hour >= 24)
            {
                ViewBag.Message = "Добрая ночь!";
            }
            var DataTime = data + ' ' + time;
            ViewBag.Data = DataTime;
            var notes = from p in db.Notes                                       
                            select p;
            //не работает
            //var pattern = "~\\[[^]]+].*?\\[[^]]+]\\s?~";
            //var target = "";
            //Regex regex = new Regex(pattern);
            /*foreach (var t in notes)
            {
                //Note_text = t.Note_text.Replace(pattern, "");
                var result = regex.Replace(t.Note_text, target);
                ViewBag.reptext = result;
            }*/
            return View(notes);
        }


        [HttpGet]
        public IActionResult NoteAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NoteAdd(Note note)
        {
            var data = DateTime.Now;
            if (ModelState.IsValid)
            {                
                note.Id_user = 1;
                note.Id_notepad = 1;
                //note.Note_date = DateTime.Parse(data);
                note.Note_date = data;
                db.Notes.Add(note);
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult NoteEdit(int Id)
        {
            var note = (from p in db.Notes
                          where p.Id == Id
                          select p).First();
            return View(note);
        }

        [HttpPost]
        public IActionResult NoteEdit(Note note)
        {
            var data = DateTime.Now;
            if (ModelState.IsValid)
            {
                note.Id_user = 1;
                note.Id_notepad = 1;
                //note.Note_date = DateTime.Parse(data);
                note.Note_date = data;
                db.Notes.Update(note);
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult NoteBookAdd()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NoteBookAdd(Note note)
        {
            var data = DateTime.Now;
            if (ModelState.IsValid)
            {
                note.Id_user = 1;
                note.Id_notepad = 1;
                //note.Note_date = DateTime.Parse(data);
                note.Note_date = data;
                db.Notes.Add(note);
                db.SaveChanges();
            }
            return View();
        }

    }
}
