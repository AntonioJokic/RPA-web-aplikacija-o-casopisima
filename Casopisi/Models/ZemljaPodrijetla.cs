using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Casopisi.Models
{
    public class ZemljaPodrijetla
    {
        [Required(ErrorMessage = "Polje {0} se mora popuniti!")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje {0} se mora ispuniti!")]
        [Display(Name = "Jezik")]
        public string Naziv { get; set; }
        public List<Casopis> Casopisi { get; set; }
    }
}
