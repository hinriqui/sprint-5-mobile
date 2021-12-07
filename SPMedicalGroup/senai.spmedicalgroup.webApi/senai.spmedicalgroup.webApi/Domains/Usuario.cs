using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmedicalgroup.webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public string Email { get; set; }
        public string TipoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario TipoUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
