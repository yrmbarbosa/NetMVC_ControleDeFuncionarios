using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App_ControleDeFuncionarios.Models
{
    public class Funcionario
    {

        [Key]
        public int Id { get; set; }

        [DisplayName("Mátricula")]
        [Required(ErrorMessage = "É obrigatório informar {0}")]
        public int Matricula { get; set; }

        [Required(ErrorMessage = "É obrigatório informar {0}")]
        [MaxLength(50, ErrorMessage = "No máximo 50 caracteres")]
        public string Nome { get; set; }

        [MaxLength(50, ErrorMessage = "No máximo 50 caracteres")]
        public string Sobrenome { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "É obrigatório informar {0}")]
        [EmailAddress(ErrorMessage = "{0} em formato inválido")]
        public string Email { get; set; }

        public bool Ativo { get; set; }

        [DisplayName("Data de admissão")]
        [Required(ErrorMessage = "É obrigatório informar {0}")]
        public DateTime DataAdmissao { get; set; }

        [DisplayName("Data de demissão")]
        public DateTime? DataDemissao { get; set; }

    }
}