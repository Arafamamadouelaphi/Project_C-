using BowlingLib.Model;
using BowlingLib.Interface;

namespace BowlingStub
{
    public class StubPartie:IDataManager<Partie> 
    {
        private List<Partie> listParties = new List<Partie>();
       
        public void Add(Partie data)
        {
            listParties.Add(data);
        }

        public void Delete(Partie data)
        {
            listParties.Remove(data);
        }

        public IEnumerable<Partie> GetAll()
        {
            return listParties;
        }

        public IEnumerable<Partie> GetAll(int n=10, int j=0)
        {
            for (int i = 0; i < n; i++)
            {
                listParties.Add(new Partie(new Joueur("Joueur " + i + 1)));
            }
            return listParties;
        }

        public void Update(Partie data)
        {
            int index = listParties.FindIndex(x => x.Id == data.Id);
            listParties[index] = data;
        }
        
    }
}