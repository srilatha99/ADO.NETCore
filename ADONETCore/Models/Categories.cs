﻿using System.ComponentModel.DataAnnotations;

namespace ADONETCore.Models
{
    public class Categories
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
