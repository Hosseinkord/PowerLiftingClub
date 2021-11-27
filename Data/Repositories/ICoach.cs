using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ICoach:IDisposable
    {
        IEnumerable<Coach> GetAllCoach();
        Coach GetCoachById(int coachId);
        bool InsertCoach(Coach coach);
        bool UpdateCoach(Coach coach);
        bool DeleteCoach(Coach coach);
        bool DeleteCoach(int coachId);
        void Save();
    }
}
