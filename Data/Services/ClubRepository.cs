using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ClubRepository : IClub
    {
        private ClubContext db;

        public ClubRepository(ClubContext context)
        {
            this.db = context;
        }
        public IEnumerable<Club> GetAllClub()
        {
            return db.Clubs;
        }

        public Club GetClubById(string clubId)
        {
            return db.Clubs.Find(clubId);
        }

        public bool InsertClub(Club club)
        {
            try
            {
                db.Clubs.Add(club);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateClub(Club club)
        {
            try
            {
                db.Entry(club).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeleteClub(Club club)
        {
            try
            {
                db.Entry(club).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteClub(string clubId)
        {
            try
            {
                var club = GetClubById(clubId);
                DeleteClub(club);
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
