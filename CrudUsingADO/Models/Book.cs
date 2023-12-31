﻿using System.ComponentModel.DataAnnotations;

namespace CrudUsingADO.Models
{
    public class Book
    {
       
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Author { get; set; }
        [Required]
        public int Price { get; set; }
    }

}

