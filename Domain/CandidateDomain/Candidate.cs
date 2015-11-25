using Domain.InterviewDomain;
using Infrastructure;
using System;
using System.Collections.Generic;

namespace Domain.CandidateDomain
{
    public class Candidate : IObjectValidation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public List<Interview> Interviews { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new Exception("Nome Inválido");
            if (string.IsNullOrEmpty(Cpf))
                throw new Exception("Cpf Inválido");
            if (string.IsNullOrEmpty(Phone))
                throw new Exception("Telefone Inválido");
            if (Interviews == null)
            {
                throw new Exception();
            }
            throw new Exception();
        }
    }
}
