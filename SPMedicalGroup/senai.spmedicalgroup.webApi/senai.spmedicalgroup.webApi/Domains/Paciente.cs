using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmedicalgroup.webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdPaciente { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string Tel { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }

        public virtual Usuario EmailNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
