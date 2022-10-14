using BowlingLib.Model;
using BowlingLib.Interface;
using System;

namespace BowlingStub
{
    public class StubJoueur : IDataManager<Joueur>

    {
        private List<Joueur> listJoueurs = new List<Joueur>();


        public void Add(Joueur data)
        {
            listJoueurs.Add(data);
        }

        public void Delete(Joueur data)
        {
            listJoueurs.Remove(data);
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

        public void Update(Joueur data)
        {
            int index = listJoueurs.FindIndex(x => x.Id == data.Id);
            listJoueurs[index] = data;
        }

    }
}
