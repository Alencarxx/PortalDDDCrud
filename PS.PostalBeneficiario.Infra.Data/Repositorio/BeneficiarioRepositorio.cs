using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using Dapper;
using PS.PostalBeneficiario.Dominio.DTO;
using PS.PostalBeneficiario.Dominio.Entidades;
using PS.PostalBeneficiario.Dominio.Interfaces.Repositorio;
using PS.PostalBeneficiario.Infra.Dado.Contexto;

namespace PS.PostalBeneficiario.Infra.Dado.Repositorio
{
    public class BeneficiarioRepositorio : Repositorio<Beneficiario>, IBeneficiarioRepositorio  
    {
        public BeneficiarioRepositorio(PostalBeneficiarioContext context)
            : base(context)
        {

        }

        public Beneficiario ObterPorCpf(string cpf)
        {
            //return Db.Beneficiarios.FirstOrDefault(c => c.CPF == cpf);
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Beneficiario ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public Paged<Beneficiario> ObterTodos(string nome, int pageSize, int pageNumber)
        {
            var cn = Db.Database.Connection;

            var sql = @"SELECT * FROM Beneficiarios " +
                      "WHERE (@Nome IS NULL OR Nome LIKE @Nome + '%') " +
                      "ORDER BY [Nome] " +
                      "OFFSET " + pageSize * (pageNumber - 1) + " ROWS " +
                      "FETCH NEXT " + pageSize + " ROWS ONLY " +
                      " " +
                      "SELECT COUNT(BeneficiarioId) FROM Beneficiarios " +
                      "WHERE (@Nome IS NULL OR Nome LIKE @Nome + '%') ";

            var multi = cn.QueryMultiple(sql, new { Nome = nome });
            var beneficiario = multi.Read<Beneficiario>();
            var total = multi.Read<int>().FirstOrDefault();

            var pagedList = new Paged<Beneficiario>()
            {
                List = beneficiario,
                Count = total
            };

            return pagedList;
        }

        public override Beneficiario ObterPorId(Guid id)
        {
            var cn = Db.Database.Connection;
            var sql = @"SELECT * FROM Beneficiarios c " +
                       "LEFT JOIN Enderecos e " +
                       "ON c.BeneficiarioId = e.BeneficiarioId " +
                       "WHERE c.BeneficiarioId = @sid";

            var beneficiario = new List<Beneficiario>();
            cn.Query<Beneficiario, Endereco, Beneficiario>(sql,
                (c, e) =>
                {
                    beneficiario.Add(c);
                    if (e != null)
                        beneficiario[0].Enderecos.Add(e);

                    return beneficiario.FirstOrDefault();
                }, new { sid = id }, splitOn: "BeneficiarioId, EnderecoId");

            return beneficiario.FirstOrDefault();
        }
    }
}
