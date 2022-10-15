using BowlingLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IDataManager<Data>
    {
        bool Add(Data data);
        bool Delete(Data data);
        bool Update(Data data);
        Data GetDataWithId(int id);
        Data GetDataWithName(string name);
        IEnumerable<Data> GetAll();
        IEnumerable<Data> GetAll(int n, int j);
    }
}
