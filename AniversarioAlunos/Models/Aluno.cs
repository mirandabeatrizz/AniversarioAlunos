using System.ComponentModel.DataAnnotations;

namespace AniversarioAlunos.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="É preciso informar um nome.")]
        [MinLength(3, ErrorMessage = "O nome deve conter pelo menos 3 caracteres.")]
        public string ?Nome { get; set; }

        [Required(ErrorMessage ="é preciso informar a data de aniversário ")]
        public DateOnly DataAniversario { get; set; }

        public Aluno() { }

    }

}
