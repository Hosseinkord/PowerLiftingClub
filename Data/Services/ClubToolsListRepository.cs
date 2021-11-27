using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ClubToolsListRepository:IClubToolsList
    {
        private ClubContext db;

        public ClubToolsListRepository(ClubContext context)
        {
            this.db = context;
        }
        public IEnumerable<ClubToolsList> GetAllClubToolsList()
        {
            return db.ClubToolsLists;
        }

        public ClubToolsList GetClubToolsListById(int clubToolsListId)
        {
            return db.ClubToolsLists.Find(clubToolsListId);
        }

        public bool InsertClubToolsList(ClubToolsList clubToolsList)
        {
            try
            {
                db.ClubToolsLists.Add(clubToolsList);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool UpdateClubToolsList(ClubToolsList clubToolsList)
        {
            try
            {
                db.Entry(clubToolsList).State = EntityState.Modified;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeleteClubToolsList(ClubToolsList clubToolsList)
        {
            try
            {
                db.Entry(clubToolsList).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool DeleteClubToolsList(int clubToolsListId)
        {
            try
            {
                var clubToolsList = GetClubToolsListById(clubToolsListId);
                DeleteClubToolsList(clubToolsList);
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
