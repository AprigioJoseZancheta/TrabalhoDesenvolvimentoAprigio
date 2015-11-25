using System;
using System.Globalization;
using Domain.InterviewDomain;
using System.Collections.Generic;
using System.Web.Services;
using WebService.Data;

namespace WSInterview
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        private readonly WSInterviewRepository _interviewRepository;
        public WebService1()
        {
           _interviewRepository = new WSInterviewRepository();
        }

        [WebMethod(Description = "retorna uma lista de entervistas")]
        public List<Interview> GetInterviewAll()
        {
            return _interviewRepository.GetAll();
        }

        [WebMethod(Description = "retorna uma entervista da lista pelo identificador único")]
        public Interview Get(int id)
        {
            return _interviewRepository.Get(id);
        }

        [WebMethod(Description = "deleta uma entervista da lista pelo identificador único")]
        public void Delete(int id)
        {
            Interview interview = _interviewRepository.Get(id);
            _interviewRepository.Delete(interview.Id);
        }

        [WebMethod(Description = "add uma nova entervista da lista")]
        public void Add(int id, string local, string date)
        {
            date = DateTime.Now.ToString();
            var convertDate = Convert.ToDateTime(date).ToString("yy-mm-dd");
            DateTime dt = DateTime.ParseExact(convertDate, "yy-mm-dd", CultureInfo.InvariantCulture);

            Interview interview = new Interview()
            {
                Id = id,
                Local = local,
                DataInterview = dt
            };
            
            _interviewRepository.Add(interview, id, local, dt);
        }
    }
}
