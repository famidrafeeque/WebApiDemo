using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    public class CollegesController : ApiController
    {
        CollegeRepository collegeRepository = new CollegeRepository();
        public IEnumerable<College> Get()
        {
            return collegeRepository.GetColleges();
        }
        public void Post(College college)
        {
            collegeRepository.AddCollege(college);
        }
        public void Put(College college)
        {
            collegeRepository.UpdateCollege(college);
        }
        public void Delete(int collegeId)
        {
            collegeRepository.DeleteCollege(collegeId);
        }
    }
}
