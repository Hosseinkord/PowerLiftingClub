using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public  interface IClub:IDisposable
    {
        IEnumerable<Club> GetAllClub();
        Club GetClubById(string clubId);
        bool InsertClub(Club club);
        bool UpdateClub(Club club);
        bool DeleteClub(Club club);
        bool DeleteClub(string clubId);
        void Save();
    }
}
