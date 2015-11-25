using Domain.CandidateDomain;
using Domain.InterviewDomain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebService.Data
{
    public class WSInterviewRepository
    {
        private Candidate _candidate = new Candidate();
        private List<Interview> _interviews;

        public WSInterviewRepository()
        {
            _interviews = new List<Interview>
            {
                new Interview
                {
                    Id = 1,
                    Local = "Nddigital",
                    Comment = "kkkkkkkkk",
                    DataInterview = DateTime.Now,
                    Candidate = new Candidate
                    {
                        Id = 1,
                        Name = "Aprígio",
                        Cpf = "2113222211",
                        Phone = "32234598"
                    }
                },
                new Interview
                {
                    Id = 2,
                    Local = "Nddigital",
                    Comment = "kkkkkkkkk",
                    DataInterview = DateTime.Now,
                    Candidate = new Candidate
                    {
                        Id = 2,
                        Name = "Ricardo",
                        Cpf = "5556655566",
                        Phone = "32265984"
                    }
                },
                new Interview
                {
                    Id = 3,
                    Local = "Prefeitura de Lages",
                    Comment = "kkkkkkkkk",
                    DataInterview = DateTime.Now,
                    Candidate = new Candidate
                    {
                        Id = 3,
                        Name = "Rúbia",
                        Cpf = "99988877",
                        Phone = "32275678"
                    }
                },
                new Interview
                {
                    Id = 4,
                    Local = "Posto de Saúde",
                    Comment = "kkkkkkkkk",
                    DataInterview = DateTime.Now,
                    Candidate = new Candidate
                    {
                        Id = 4,
                        Name = "Adriana",
                        Cpf = "032225698",
                        Phone = "32212714"
                    }
                },
                new Interview
                {
                    Id = 5,
                    Local = "Sesc",
                    Comment = "kkkkkkkkk",
                    DataInterview = DateTime.Now,
                    Candidate = new Candidate
                    {
                        Id = 5,
                        Name = "Mateus",
                        Cpf = "032556987",
                        Phone = "32222222"
                    }
                },
                new Interview
                {
                    Id = 6,
                    Local = "Santa Rosa",
                    Comment = "kkkkkkkkk",
                    DataInterview = DateTime.Now,
                    Candidate = new Candidate
                    {
                        Id = 6,
                        Name = "Carolina",
                        Cpf = "032697777",
                        Phone = "32223344"
                    }
                }
            };
        }

        public List<Interview> GetAll()
        {
            return _interviews.ToList();
        }

        public Interview Get(int id)
        {
            return _interviews.FirstOrDefault(interview => interview.Id == id);
        }

        public void Delete(int id)
        {
            Interview interviewDelete = _interviews.FirstOrDefault(interview => interview.Id == id);
            _interviews.Remove(interviewDelete);
        }

        public void Add(Interview interview, int id, string local, DateTime date)
        {
            _interviews.Add(interview);
        }
    }
}
