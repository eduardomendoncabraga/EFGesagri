using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFGesAgro.Models
{
    [MetadataType(typeof(PessoMetodo))] 
    public partial class Pessoa {
    }

    public class PessoMetodo
    {
        [Required(ErrorMessage="Nome é obrigatório")]            public string PesNom { get; set; }
        [Required(ErrorMessage = "Tipo deve ser informado")]     public string PesTip { get; set; }
        [Required(ErrorMessage = "CPF/CNPJ deve ser informado")] public string PesCpf { get; set; }
        //[Required(ErrorMessage = "RG deve ser informado")]     public string PesNom { get; set; }
        [Required(ErrorMessage = "Endereço deve ser informado")] public string PesEnd { get; set; }
        [Required(ErrorMessage = "Bairro deve ser informado")]   public string PesBai { get; set; }
        [Required(ErrorMessage = "Nro deve ser informado")]      public string PesNro { get; set; }
        [Required(ErrorMessage = "Cep deve ser informado")]      public string PesCep { get; set; }
        [Required(ErrorMessage = "Estado deve ser informado")]   public string EstCod { get; set; }
        [Required(ErrorMessage = "Cidade deve ser informada")]   public string CidCod { get; set; }
        [Required(ErrorMessage = "Status deve ser informado")]   public string PesSta { get; set; }
        [Required(ErrorMessage = "Email deve ser informado")]    public string PesEmail { get; set; }
        [Required(ErrorMessage = "Senha deve ser informada")]    public string PesUsr { get; set; }      
    }
}