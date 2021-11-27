using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class CoachPayRepository:ICoachPay
    {
        private ClubContext db;

        public CoachPayRepository(ClubContext context)
        {
            this.db = context;
        }
        public IEnumerable<CoachPay> GetAllCoachPay()
        {
            return db.CoachPays;
        }

        public CoachPay GetCoachPayById(int coachPayId)
        {
            return db.CoachPays.Find(coachPayId);
        }

        public bool InsertCoachPay(CoachPay coachPay)
        {
            try
            {
                db.CoachPays.Add(coachPay);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateCoachPay(CoachPay coachPay)
        {
            try
            {
                db.Entry(coachPay).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeleteCoachPay(CoachPay coachPay)
        {
            try
            {
                db.Entry(coachPay).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteCoachPay(int coachPayId)
        {
            try
            {
                var coachPay = GetCoachPayById(coachPayId);
                DeleteCoachPay(coachPay);
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
