using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace beautyTech.Models
{
    [Table("BT_EMPRESA")]
    public class Empresa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_EMPRESA { get; set; }

        [Required]
        public string NM_EMPRESA { get; set; }

        [Required]
        public string CNPJ_EMPRESA { get; set; }

        [Required]
        public string DESC_EMPRESA { get; set; }

        
    }
}
