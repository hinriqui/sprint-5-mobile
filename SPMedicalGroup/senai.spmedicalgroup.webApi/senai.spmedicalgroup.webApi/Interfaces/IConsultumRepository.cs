using senai.spmedicalgroup.webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Interfaces
{
    interface IConsultumRepository
    {
        /// <summary>
        /// Retorna todos os objetos cadastrados
        /// </summary>
        /// <returns>Uma lista de objetos</returns>
        List<Consultum> ListarTodos();

        /// <summary>
        /// Retorna todos as cadastradas cadastrados com o id do médico
        /// </summary>
        /// <param name="id">Id médico</param>
        /// <returns>Lista de consultas</returns>
        List<Consultum> ListarPorMed(int id);

        /// <summary>
        /// Retorna todos as cadastradas cadastrados com o id do paciente
        /// </summary>
        /// <param name="id">Id paciente</param>
        /// <returns>Lista de consultas</returns>
        List<Consultum> ListarPorPac(int id);

        /// <summary>
        /// Retorna o objeto com respectivo id
        /// </summary>
        /// <param name="id">Id do objeto</param>
        /// <returns>O objeto com respectivo id</returns>
        Consultum BuscarPorId(int id);

        /// <summary>
        /// Deleta o objeto com respectivo id
        /// </summary>
        /// <param name="id">Id do objeto</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza o objeto com respectivo id
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="objAtualizado">Objeto atualizado</param>
        void Atualizar(int id, Consultum objAtualizado);

        /// <summary>
        /// Cadastra um novo objeto
        /// </summary>
        /// <param name="objAtualizado">Novo objeto</param>
        void Cadastrar(Consultum objAtualizado);
    }
}
