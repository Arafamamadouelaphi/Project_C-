using BowlingLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IPartieDbDataManager : IDataManager<Partie>
    {
        IEnumerable<Partie> GetAllWithDate(DateTime date);
    }
}
