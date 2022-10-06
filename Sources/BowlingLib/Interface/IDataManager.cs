using BowlingLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingLib.Interface
{
    public interface IDataManager<Data>
    {
        void Add(Data data);
        void Delete(Data data);
        void Update(Data data);
        IEnumerable<Data> GetAll();
        IEnumerable<Data> GetAll(int n, int j);
    }
}
