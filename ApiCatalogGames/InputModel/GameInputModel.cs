using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogGames.InputModel
{
    public class GameInputModel
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "The game name must contain, between 3 and 100 characters.")]
        public string Nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength =1, ErrorMessage = "The producer's name must contain, between 1 and 100 characters.")]
        public string Produtora { get; set; }
        [Required]
        [Range(1,1000,ErrorMessage = "The price must be, a minimum of 1 real and a maximum of 1000 reais.")]
        public double Preco { get; set; }
    }

}

