using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesMovie.Models
{
    public class Movie
    {
        private decimal price;

        public int ID { get; set; }
        public string Title { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName="decimal(18,2)")]
        public decimal Price { 
            get { 
                return price;
            }
            set { 
                if (decimal.TryParse(value.ToString(), out decimal x)) price = x;
            }
        }
    }
}