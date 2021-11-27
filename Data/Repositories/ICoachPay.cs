using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface ICoachPay:IDisposable
    {
        IEnumerable<CoachPay> GetAllCoachPay();
        CoachPay GetCoachPayById(int coachPayId);
        bool InsertCoachPay(CoachPay coachPay);
        bool UpdateCoachPay(CoachPay coachPay);
        bool DeleteCoachPay(CoachPay coachPay);
        bool DeleteCoachPay(int coachPayId);
        void Save();
    }
}
