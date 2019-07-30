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

        /* MaxRiderId(): checking if any entry present in rider table and
         *      then providing the max id */
        public int MaxRiderId()
        {
            int maxid;
            if (db.Rider.Any())
            {
                maxid = db.Rider.Max(o => o.Id);
                return maxid;
            }
            else
            {
                return 0;
            }
        }

        /* GetAllRiders(): get all riders from db */
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

        /* GetAllRiderJobs(): get all riders with bestreviewscore, bestreviewcomment and
         *      avgReviewscore */
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
        //To Add new Rider record     
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
        //To Update the records of a particluar Rider    
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
        //Get the details of a particular Rider    
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
        /* To Delete the record of a particular Rider. Delete respective rider rows 
            from Job table and then delete the rider from Rider table */
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
    }
}
