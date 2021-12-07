using System;
using System.Collections.Generic;

#nullable disable

namespace senai.spmedicalgroup.webApi.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public string Sigla { get; set; }
        public string TipoUsuario1 { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
