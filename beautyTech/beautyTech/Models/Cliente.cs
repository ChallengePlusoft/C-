using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace beautyTech.Models
{
    [Table("BT_K_CLIENTE")]
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_CLIENTE { get; set; }

        [Required]
        public string CPF_CLIENTE { get; set; }

        [Required]
        public string NM_CLIENTE { get; set; }

        [Required]
        public string EMAIL_CLIENTE { get; set; }

        [Required]
        public DateTime DT_NASCIMENTO_CLIENTE { get; set; }

        [Required]
        public string ESTADO_CIVIL_CLIENTE { get; set; }

        [Required]
        public DateTime DT_CADASTRO { get; set; } = DateTime.Now;

        [Required]
        public string PELE_CLIENTE { get; set; } 

        [Required]
        public string CABELO_CLIENTE { get; set; } 
    }
}
