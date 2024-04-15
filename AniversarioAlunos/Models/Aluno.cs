namespace AniversarioAlunos.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string ?Nome { get; set; }
        public DateOnly DataAniversario { get; set; }

        public Aluno() { }

    }

}
