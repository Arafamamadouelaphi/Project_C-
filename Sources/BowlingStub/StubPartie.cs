using BowlingLib.Model;
using Business;

namespace BowlingStub
{
    public class StubPartie:IDataManager<Partie> 
    {
        private List<Partie> listParties = new List<Partie>();
       
        public bool Add(Partie data)
        {
            if (data != null)
            {
                listParties.Add(data);
                return true;
            }
            return false;
        }

        public bool Delete(Partie data)
        {
            if (data != null)
            {
                listParties.Remove(data);
                return true;
            }
            return false;
        }

        public IEnumerable<Partie> GetAll()
        {
            return listParties;
        }

        public IEnumerable<Partie> GetAllPartie(int n=10, int j=0)
        {
            for (int i = 0; i < n; i++)
            {
                listParties.Add(new Partie(new Joueur("Joueur " + i + 1)));
            }
            return listParties;
        }
        //GDW?

        public Partie GetDataWithId(int id)
        {
            throw new NotImplementedException();
        }

        public Partie GetDataWithName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Partie data)
        {
            if (data != null)
            {

                int index = listParties.FindIndex(x => x.Id == data.Id);
                listParties[index] = data;
            }
            return false;
        }
        
    }
}