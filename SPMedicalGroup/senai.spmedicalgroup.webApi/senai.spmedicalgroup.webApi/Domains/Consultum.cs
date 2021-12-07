using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.spmedicalgroup.webApi.Domains
{
    public partial class Consultum
    {
        public int IdConsulta { get; set; }

        [Required(ErrorMessage = "Médico é requerido para consulta!")]
        public int? IdMedico { get; set; }
        [Required(ErrorMessage = "Paciente é requerido para consulta!")]
        public int? IdPaciente { get; set; }
        [Required(ErrorMessage = "Situação é requerida para consulta!")]
        public string Situacao { get; set; }
        [Required(ErrorMessage = "Valor é requerido para consulta!")]
        public decimal Valor { get; set; }
        [Required(ErrorMessage = "Data é requerida para consulta!")]
        public DateTime DataConsulta { get; set; }
        public string Descricao { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual Situacao SituacaoNavigation { get; set; }
    }
}
