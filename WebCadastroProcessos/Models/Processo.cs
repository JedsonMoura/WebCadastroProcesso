using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebCadastroProcessos.Models
{
    [Table("Processo")]
    public class Processo
    {
        [Display(Name ="Id")]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Column("Nome")]
        public string Nome { get; set; }

        [Display(Name = "Npu")]
        [Column("Npu")]
        //[RegularExpression(@"^\d{7}-\d{2}\.\d{4}\.\d{1}\.\d{2}\.\d{4}$", ErrorMessage = "O NPU deve estar no formato 1111111-11.1111.1.11.1111")]
        public string Npu { get; set; }

        [Display(Name = "DataCadastro")]
        [Column("DataCadastro")]
        public DateTime DataCadastro { get; set; }

        [Display(Name = "DataVisualizacao")]
        [Column("DataVisualizacao")]
        public DateTime DataVisualizacao { get; set; }

        [Display(Name = "Uf")]
        [Column("Uf")]
        public string Uf { get; set; }

        [Display(Name = "Municipio")]
        [Column("Municipio")]
        public string Municipio { get; set; }

    }
}
