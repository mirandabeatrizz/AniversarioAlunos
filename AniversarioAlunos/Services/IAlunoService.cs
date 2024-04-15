using AniversarioAlunos.Models;

namespace AniversarioAlunos.Services
{
    public interface IAlunoService
    {
        Task CreateAluno(Aluno aluno);
        Task<List<Aluno>> FindAllAsync();
        Task<List<Aluno>> FiltrarPorMesAsync(int mes);
        Task Delete(int alunoId);
    }
}
