using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiderApp.Models
{
    //public class RiderDataAcessLayer
    //{
    //}
    public class RiderJobData
    {
        public int riderid { get; set; }
        public double avgReviewScore { get; set; }
        public int bestReviewScore { get; set; }
        public string bestReviewComment { get; set; }
    }
    public class RiderDataAcessLayer
    {
        RiderAppContext db = new RiderAppContext();
        public IEnumerable<Rider> GetAllRiders()
        {
            try
            {
                return db.Rider.ToList();
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<RiderJobData> GetAllRiderJobs()
        {
            try
            {
                var riderJob = db.Job.ToList();

                var riderJobs = riderJob.GroupBy(c => c.RiderId)
                    .Select(g => new RiderJobData
                    {
                        riderid = g.Key,
                        bestReviewScore = g.Max(x => x.ReviewScore),
                        avgReviewScore = g.Average(x => x.ReviewScore),
                        bestReviewComment = g.Where(x => x.ReviewScore == g.Max(y => y.ReviewScore)).FirstOrDefault().ReviewComment
                    })
                    .OrderBy(c => c.riderid);
                return riderJobs;
                
            }
            catch
            {
                return null;
            }
        }
        //To Add new employee record     
        public int AddRider(Rider rider)
        {
            try
            {
                db.Rider.Add(rider);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        //To Update the records of a particluar employee    
        public int UpdateRider(Rider rider)
        {
            try
            {
                db.Entry(rider).State = EntityState.Modified;
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        //Get the details of a particular employee    
        public Rider GetRiderData(int id)
        {
            try
            {
                Rider rider = db.Rider.Find(id);
                return rider;
            }
            catch
            {
                return null;
            }
        }
        //To Delete the record of a particular employee    
        public int DeleteRider(int id)
        {
            try
            {
                Rider rider = db.Rider.Find(id);
                var riderJobs = db.Job.Where(o => o.RiderId == id).ToList();

                db.Job.RemoveRange(riderJobs);
                db.Rider.Remove(rider);
                db.SaveChanges();
                return 1;
            }
            catch
            {
                return -1;
            }
        }
        //To Get the list of Cities    
        //public List<TblCities> GetCities()
        //{
        //    List<TblCities> lstCity = new List<TblCities>();
        //    lstCity = (from CityList in db.TblCities select CityList).ToList();
        //    return lstCity;
        //}
    }
}
