using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotNetCoreMVCAndMariaDBApiExample.Entities
{


   // [Table("computers")]
    public class Computers
    {

        //[Key]
        public int id { get; set; }


        //[Required]
        //[MaxLength(100)]
        public string data { get; set; }


       // [Required]
        //[MaxLength(15)]
        public Double price { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string name { get; set; }

    }
}
