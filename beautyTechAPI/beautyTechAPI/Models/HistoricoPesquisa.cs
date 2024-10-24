using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace beautyTechAPI.Models
{
    [Table("BT_K_HISTORICO_PESQUISA")]
    public class HistoricoPesquisa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID_HISTORICO { get; set; }

        [Required]
        public int ID_CLIENTE { get; set; }

        [Required]
        public int ID_PRODUTO { get; set; }

        // Relacionamento com as tabelas Cliente e Produto
        [ForeignKey("ID_CLIENTE")]
        public virtual Cliente Cliente { get; set; }

        [ForeignKey("ID_PRODUTO")]
        public virtual Produto Produto { get; set; }
    }
}
