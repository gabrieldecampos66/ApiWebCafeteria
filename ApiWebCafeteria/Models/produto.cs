using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiWebCafeteria.Models
{
    [Table("produtos")]
    public class produto
    {

        public int Id { get; set; }// Só de chamar ele de Id ele já sabe que é chave primária

        [Required]

        public string Nome { get; set; }

        [Required]

        public decimal Preco { get; set; }


        public string? Categoria { get; set; }


        public string? Descricao { get; set; }


        public string? Foto { get; set; }


        [Required]

        public string Status { get; set; }

    }

}
