using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RiderApp.Models;

namespace RiderApp.Controllers
{
    public class RiderController : Controller
    {
        RiderDataAcessLayer objRider = new RiderDataAcessLayer();
       
        [HttpGet]
        [Route("api/Rider/Index")]
        public IEnumerable<Rider> Index()
        {
            return objRider.GetAllRiders();
        }
        [Route("api/Rider/GetRiders")]
        public IEnumerable<RiderJobData> GetRiders()
        {
            return objRider.GetAllRiderJobs();
        }
        [HttpPost]
        [Route("api/Rider/Create")]
        public int Create(Rider Rider)
        {
            IEnumerable<Rider> allRiders = objRider.GetAllRiders();
            if (allRiders.Count() > 0)
            {
                int maxid = allRiders.Max(o => o.Id);
                Rider.Id = maxid + 1;
            }
            else
            {
                Rider.Id = 1;
            }
            Rider.StartDate = DateTime.Now;

            return objRider.AddRider(Rider);
        }
        [HttpGet]
        [Route("api/Rider/Details/{id}")]
        public Rider Details(int id)
        {
            return objRider.GetRiderData(id);
        }
        [HttpPut]
        [Route("api/Rider/Edit")]
        public int Edit(Rider Rider)
        {
            return objRider.UpdateRider(Rider);
        }
        [HttpDelete]
        [Route("api/Rider/Delete/{id}")]
        public int Delete(int id)
        {
            return objRider.DeleteRider(id);
        }
    }
}
