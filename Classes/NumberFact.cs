using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactsAboutNumbers.Classes
{
    public class NumberFact
    {
        [Key]
        [Required]
        public int Number { get; set; }

        [Required]
        public string Fact { get; set; }
    }
}
