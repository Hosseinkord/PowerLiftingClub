using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CoachRepository:ICoach
    {
        private ClubContext db;

        public CoachRepository(ClubContext context)
        {
            this.db = context;
        }
        public IEnumerable<Coach> GetAllCoach()
        {
            return db.Coaches;
        }

        public Coach GetCoachById(int coachId)
        {
            return db.Coaches.Find(coachId);
        }

        public bool InsertCoach(Coach coach)
        {
            try
            {
                db.Coaches.Add(coach);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateCoach(Coach coach)
        {
            try
            {
                db.Entry(coach).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeleteCoach(Coach coach)
        {
            try
            {
                db.Entry(coach).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteCoach(int coachId)
        {
            try
            {
                var coach = GetCoachById(coachId);
                DeleteCoach(coach);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
