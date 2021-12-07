using senai.spmedicalgroup.webApi.Contexts;
using senai.spmedicalgroup.webApi.Domains;
using senai.spmedicalgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int id, Clinica objAtualizado)
        {
            Clinica objBuscado = ctx.Clinicas.FirstOrDefault(u => u.IdClinica == id);

            if (objBuscado.NomeClinica != null)
            {
                objBuscado.NomeClinica  = objAtualizado.NomeClinica; 
                objBuscado.RazaoSocial  = objAtualizado.RazaoSocial; 
                objBuscado.Cnpj         = objAtualizado.Cnpj;        
                objBuscado.Endereco     = objAtualizado.Endereco;
                objBuscado.HorarioFecha = objAtualizado.HorarioFecha;
            }

            ctx.Clinicas.Update(objBuscado);
            ctx.SaveChanges();
        }

        public Clinica BuscarPorId(int id)
        {
            return ctx.Clinicas.FirstOrDefault(u => u.IdClinica == id);
        }

        public void Cadastrar(Clinica objAtualizado)
        {
            ctx.Clinicas.Add(objAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Clinicas.Remove(ctx.Clinicas.FirstOrDefault(u => u.IdClinica == id));
            ctx.SaveChanges();
        }

        public List<Clinica> ListarTodos()
        {
            return ctx.Clinicas.ToList();
        }
    }
}
