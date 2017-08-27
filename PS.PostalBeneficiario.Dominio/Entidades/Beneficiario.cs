using System;
using System.Collections.Generic;
using DomainValidation.Validation;
using PS.PostalBeneficiario.Dominio.Validacoes.Beneficiarios;

namespace PS.PostalBeneficiario.Dominio.Entidades
{
    public class Beneficiario
    {

        public Beneficiario()
        {
            BeneficiarioId = Guid.NewGuid();
            Enderecos = new List<Endereco>();
        }

        public Guid BeneficiarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }

        public bool IsValid()
        {
            ValidationResult = new BeneficiarioEstaConsistenteValidacoes().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
