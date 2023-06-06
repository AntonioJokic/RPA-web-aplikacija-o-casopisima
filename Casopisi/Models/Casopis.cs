using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Casopisi.Models
{
    public class Casopis
    {
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [Display(Name = "Tečaj")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [Display(Name = "Vrsta")]
        public int KategorijaId { get; set; }
        public Kategorija Kategorija { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [DataType(DataType.Currency)]
        public decimal Cijena { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [Display(Name = "Zemlja podrijetla")]
        public int ZemljaPodrijetlaId { get; set; }
        public ZemljaPodrijetla ZemljaPodrijetla { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        public string Urednik { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [Display(Name = "Poster")]
        public string SlikaUrl { get; set; }
    }
}
