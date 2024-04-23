using AniversarioAlunos.Data;
using AniversarioAlunos.Models;
using Microsoft.EntityFrameworkCore;

namespace AniversarioAlunos.Services
{
    public class AlunoService :IAlunoService
    {
        private readonly AppDbContext _context;
        public AlunoService(AppDbContext context) { _context = context; }

        public async Task<List<Aluno>> FindAllAsync()
        {
            try
            {
                return await _context.Alunos.ToListAsync();
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task CreateAluno(Aluno aluno)
        {
            try
            {
                _context.Add(aluno);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
           
        }

        public async Task UpdateAluno(Aluno aluno)
        {
            bool hasAny = await _context.Alunos.AnyAsync(x => x.Id == aluno.Id);
            if (!hasAny)
            {
                throw new Exception("Id não encontrado");
            }
            try
            {
                _context.Update(aluno);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex) 
            {
                throw new Exception($"{ex.Message}", ex);

            }
        }

        public async Task Delete(int alunoId)
        {
            var aluno = await _context.Alunos.FindAsync(alunoId);
            if(aluno != null)
            {
                _context.Remove(aluno);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<Aluno>> FiltrarPorMesAsync(int mes)
        {
            if (mes < 1 || mes > 12)
            {
                throw new ArgumentException("mês invalido");
            }
            return await _context.Alunos.Where(a => a.DataAniversario.Month == mes).ToListAsync();
        }

    }
}
