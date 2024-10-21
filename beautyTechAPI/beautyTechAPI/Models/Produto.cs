using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace beautyTechAPI.Models
{
    [Table("BT_K_PRODUTO")]
    public class Produto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int ID_PRODUTO { get; set; }

        [Required]
        public string NM_PRODUTO { get; set; }

        [Required]
        public string DESC_PRODUTO { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal VL_PRODUTO { get; set; }

        [Required]
        public DateTime DT_FAB_PRODUTO { get; set; }

        [Required]
        public DateTime DT_VALIDADE { get; set; }

        [Required]
        public DateTime DT_CADASTRO { get; set; } = DateTime.Now;
    }
}
