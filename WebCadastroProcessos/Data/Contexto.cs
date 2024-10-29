

using Microsoft.EntityFrameworkCore;
using WebCadastroProcessos.Models;

namespace WebCadastroProcessos.Data
{
    public class Contexto : DbContext 
    {

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {            
        }

        public DbSet<Processo> Processo { get; set; }
    }
}
