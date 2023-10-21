using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FutScout_2023.Models
{
    [Table("Atacantes")]
    public class Atacante
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Inserir o dado")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Inserir o dado")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Inserir o dado")]
        public int Clube { get; set; }

        [Required(ErrorMessage = "Inserir o dado")]
        public int Partidas2023 { get; set; }

        [Required(ErrorMessage = "Inserir o dado")]
        public int Gols2023 { get; set; }

        [Required(ErrorMessage = "Inserir o dado")]
        public int Assists2023 { get; set; }

        [Required(ErrorMessage = "Inserir o dado")]
        public int Partidas2022 { get; set; }

        [Required(ErrorMessage = "Inserir o dado")]
        public int Gols2022 { get; set; }

        [Required(ErrorMessage = "Inserir o dado")]
        public int Assists2022 { get; set; }

        public int Partidas2021 { get; set; }

        public int Gols2021 { get; set; }

        public int Assists2021 { get; set; }

    }
}
