using BowlingLib.Model;
using Business;
using System;

namespace BowlingStub
{
    public class StubJoueur : IDataManager<Joueur>

    {
        private List<Joueur> listJoueurs = new List<Joueur>();


        public bool Add(Joueur data)
        {
            if (data != null)
            {
                listJoueurs.Add(data);
                return true;
            }
            return false;
        }

        public bool Delete(Joueur data)
        {
            if (data != null)
            {
                listJoueurs.Remove(data);
                return true;
            }
            return false;
        }

        public IEnumerable<Joueur> GetAll()
        {
            return listJoueurs;
        }

        public IEnumerable<Joueur> GetAll(int n = 10, int j = 0)
        {
            for (int i = 0; i < n; i++)
            {
                Add(new Joueur("Joueur " + i + 1));
            }
            return listJoueurs;
        }

        public Joueur GetDataWithId(int id)
        {
            throw new NotImplementedException();
        }

        public Joueur GetDataWithName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Joueur data)
        {
            if (data != null)
            {

                int index = listJoueurs.FindIndex(x => x.Id == data.Id);
                listJoueurs[index] = data;
                return true;
            }
            return false;
        }

    }
}
