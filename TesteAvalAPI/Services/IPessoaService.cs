using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAvalAPI.Models;

namespace TesteAvalAPI.Services
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> GetPessoas();
        Task<Pessoa> GetPessoa(int id);
        void AddPessoa(Pessoa item);
        void UpdatePessoa(Pessoa item);
        void DeletePessoa(int id);
        Task<bool> PessoaExists(int id);
    }
}
