using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Pecas.Models
{
    public class Cliente
    {
        public long ClienteId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "O CPF deve estar no formato 000.000.000-00")]
        public string CPF { get; set; }

        [RegularExpression(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}[\s-]?\d{4}$", ErrorMessage = "O número de telefone não é válido.")]
        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        public long Telefone { get; set; }

        [EmailAddress(ErrorMessage = "O Email deve ser um endereço de email válido.")]
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }
    }

}
