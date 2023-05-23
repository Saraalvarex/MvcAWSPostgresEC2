using Microsoft.EntityFrameworkCore;
using MvcAWSPostgresEC2.Data;
using MvcAWSPostgresEC2.Models;

namespace MvcAWSPostgresEC2.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;
        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartsAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }

        public async Task<Departamento> FindDepartAsync(int id)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(x=>x.IdDepartamento==id);
        }

        public async Task InsertarDepartAsync(int id, string nombre, string localidad)
        {
            Departamento depart = new Departamento();
            depart.IdDepartamento = id;
            depart.Nombre = nombre;
            depart.Localidad = localidad;
            this.context.Departamentos.Add(depart);
            await this.context.SaveChangesAsync();
        }
    }
}
