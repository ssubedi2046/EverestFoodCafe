using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EverestFoodCafe.Models
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string CustomerName { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Comments { get; set; }
        public int Rating { get; set; }
        public int DishID { get; set; }
    }
}