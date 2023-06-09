using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppObuca.Models
{
    public class Obuca
    {
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; }
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "Slika")]
        public string SlikaUrl { get; set; }
        [Display(Name = "Brend")]
        public int BrendId { get; set; }
        public Brend Brend { get; set; }
    }
}
