using senai.spmedicalgroup.webApi.Contexts;
using senai.spmedicalgroup.webApi.Domains;
using senai.spmedicalgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace senai.spmedicalgroup.webApi.Repositories
{
    public class ConsultumRepository : IConsultumRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int id, Consultum objAtualizado)
        {
            Consultum objBuscado = ctx.Consulta.FirstOrDefault(u => u.IdConsulta == id);

            if (objBuscado.Situacao != null)
            {
                objBuscado.IdMedico     = objAtualizado.IdMedico;
                objBuscado.IdPaciente   = objAtualizado.IdPaciente;
                objBuscado.Situacao     = objAtualizado.Situacao;
                objBuscado.Valor        = objAtualizado.Valor;
                objBuscado.DataConsulta = objAtualizado.DataConsulta;
                objBuscado.Descricao    = objAtualizado.Descricao;
            }

            ctx.Consulta.Update(objBuscado);
            ctx.SaveChanges();
        }

        public Consultum BuscarPorId(int id)
        {
            return ctx.Consulta.Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation).FirstOrDefault(u => u.IdConsulta == id);
        }

        public void Cadastrar(Consultum objAtualizado)
        {
            ctx.Consulta.Add(objAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Consulta.Remove(ctx.Consulta.FirstOrDefault(u => u.IdConsulta == id));
            ctx.SaveChanges();
        }

        public List<Consultum> ListarTodos()
        {
            return ctx.Consulta.Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation).Include(c => c.IdMedicoNavigation.IdEspecialidadeNavigation).ToList();
        }

        public List<Consultum> ListarPorMed(int id)
        {
            return ctx.Consulta.Where(u => u.IdMedico == id).Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation).ToList();
        }

        public List<Consultum> ListarPorPac(int id)
        {
            return ctx.Consulta.Where(u => u.IdPaciente == id).Include(c => c.IdMedicoNavigation).Include(c => c.IdPacienteNavigation).ToList();
        }
    }
}
