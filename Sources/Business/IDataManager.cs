using BowlingLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    /// <summary>
    /// Interface d'abstraction pour les donné
    /// </summary>
    /// <typeparam name="Data"></typeparam>
    public interface IDataManager<Data>
    {
        bool Add(Data data);
        bool Delete(Data data);
        bool Update(Data data);
        Data GetDataWithName(string name);
        IEnumerable<Data> GetAll();
    }
}
