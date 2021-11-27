using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IClubToolsList:IDisposable
    {
        IEnumerable<ClubToolsList> GetAllClubToolsList();
        ClubToolsList GetClubToolsListById(int clubToolsListId);
        bool InsertClubToolsList(ClubToolsList clubToolsList);
        bool UpdateClubToolsList(ClubToolsList clubToolsList);
        bool DeleteClubToolsList(ClubToolsList clubToolsList);
        bool DeleteClubToolsList(int clubToolsListId);
        void Save();
    }
}
