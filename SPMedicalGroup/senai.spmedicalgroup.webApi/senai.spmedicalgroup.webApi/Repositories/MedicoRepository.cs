using senai.spmedicalgroup.webApi.Contexts;
using senai.spmedicalgroup.webApi.Domains;
using senai.spmedicalgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int id, Medico objAtualizado)
        {
            Medico objBuscado = ctx.Medicos.FirstOrDefault(u => u.IdMedico == id);

            if (objBuscado.Nome != null)
            {
                objBuscado.IdClinica = objAtualizado.IdClinica;
                objBuscado.IdEspecialidade = objAtualizado.IdEspecialidade;
                objBuscado.Email = objAtualizado.Email;
                objBuscado.Nome = objAtualizado.Nome;
                objBuscado.Crm = objAtualizado.Crm;
            }

            ctx.Medicos.Update(objBuscado);
            ctx.SaveChanges();
        }

        public Medico BuscarPorEmail(string email)
        {
            return ctx.Medicos.FirstOrDefault(u => u.Email == email);
        }

        public Medico BuscarPorId(int id)
        {
            return ctx.Medicos.FirstOrDefault(u => u.IdMedico == id);
        }

        public void Cadastrar(Medico objAtualizado)
        {
            ctx.Medicos.Add(objAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Medicos.Remove(ctx.Medicos.FirstOrDefault(u => u.IdMedico == id));
            ctx.SaveChanges();
        }

        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.ToList();
        }
    }
}
