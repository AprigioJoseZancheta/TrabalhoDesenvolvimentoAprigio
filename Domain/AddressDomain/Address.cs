
using System;
using Domain.CandidateDomain;
using Infrastructure;

namespace Domain.AddressDomain
{
    public class Address : IObjectValidation
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Cp { get; set; }

        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(City))
                throw new Exception("Cidade Inválida");
            if (string.IsNullOrEmpty(Cp))
                throw new Exception("Cp Inválido");
            if (string.IsNullOrEmpty(Neighborhood))
                throw new Exception("Bairro Inválido");
            if (string.IsNullOrEmpty(State))
                throw new Exception("Estado Inválido");
            if (string.IsNullOrEmpty(Street))
                throw new Exception("Rua Inválida");
            if (CandidateId == 0)
            {
                throw new Exception();
            }
            throw new Exception();
        }
    }
}
