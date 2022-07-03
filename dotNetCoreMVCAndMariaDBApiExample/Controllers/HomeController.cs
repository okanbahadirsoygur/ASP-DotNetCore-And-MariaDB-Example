using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dotNetCoreMVCAndMariaDBApiExample.Models;
using System.Collections;

using System.Text.Json;
using dotNetCoreMVCAndMariaDBApiExample.Entities;
using dotNetCoreMVCAndMariaDBApiExample.Contexts;
using MySql.Data.MySqlClient;

namespace dotNetCoreMVCAndMariaDBApiExample.Controllers
{


    public class HomeController : Controller
    {

        private ApiDatabase apiDatabase;


        /**
         * Java Springden farklı olarak;
         * Spring'de Repositoryler @Autowired annotaition'u ile tanımlanırken burada kurucu metod içinde tanımlanıyor.
         */

        public HomeController(ApiDatabase context)
        {
            this.apiDatabase = context;

        }




        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {

            //bütün verileri contex'den alıp fiyata göre büyükten küçüğe sıralayıp front end tarafına yollayalım.
            List<Computers> computersList = apiDatabase.computers.OrderByDescending(c => c.price).ToList();

            ViewData.Add("computerList",computersList);

            return View();
        }



        [HttpGet]
        [Route("okan")]
        public JsonResult Edit()
        {

            Computers c = new Computers();

            c.name = "okan";


            List<Computers> list = new List<Computers>();


            list = this.apiDatabase.computers.ToList();

            //this.apiDatabase.computers.Add(c);

            // this.apiDatabase.SaveChanges();

           
            list = apiDatabase.computers.Where(c => c.name == "okan" && c.price > 10).ToList();

            return (Json(list));

            //return View();
        }



        public IActionResult License()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
