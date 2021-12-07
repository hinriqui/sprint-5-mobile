using senai.spmedicalgroup.webApi.Contexts;
using senai.spmedicalgroup.webApi.Domains;
using senai.spmedicalgroup.webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SpMedGroupContext ctx = new SpMedGroupContext();

        public void Atualizar(int id, Paciente objAtualizado)
        {
            Paciente objBuscado = ctx.Pacientes.FirstOrDefault(u => u.IdPaciente == id);

            if (objBuscado.Nome != null)
            {
                objBuscado.Email = objAtualizado.Email;
                objBuscado.Nome = objAtualizado.Nome;
                objBuscado.DataNasc = objAtualizado.DataNasc;
                objBuscado.Tel = objAtualizado.Tel;
                objBuscado.Rg = objAtualizado.Rg;
                objBuscado.Cpf = objAtualizado.Cpf;
                objBuscado.Endereco = objAtualizado.Endereco;
            }

            ctx.Pacientes.Update(objBuscado);
            ctx.SaveChanges();
        }

        public Paciente BuscarPorEmail(string email)
        {
            return ctx.Pacientes.FirstOrDefault(u => u.Email == email);
        }

        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(u => u.IdPaciente == id);
        }

        public void Cadastrar(Paciente objAtualizado)
        {
            //objAtualizado.DataNasc <= DateTime.Now;

            ctx.Pacientes.Add(objAtualizado);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Pacientes.Remove(ctx.Pacientes.FirstOrDefault(u => u.IdPaciente == id));
            ctx.SaveChanges();
        }

        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
