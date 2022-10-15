using BowlingLib.Model;
using Business;
using System;

namespace BowlingStub
{
    public class StubEquipe : IDataManager<Equipe>
    {
        private List<Equipe> listEquipes = new List<Equipe>();
        public StubEquipe()
        {
            //listEquipes.Add(new Equipe("Equipe 1", new Joueur("Joueur 1"), new Joueur("Joueur 2")));
            //listEquipes.Add(new Equipe("Equipe 2", new Joueur("Joueur 3"), new Joueur("Joueur 4")));
            //listEquipes.Add(new Equipe("Equipe 3", new Joueur("Joueur 5"), new Joueur("Joueur 6")));
        }

        public bool Add(Equipe data)
        {
            if (data != null)
            {
                listEquipes.Add(data);
                return true;
            }
            return false;
        }

        public bool Delete(Equipe data)
        {
            if (data != null)
            {
                listEquipes.Remove(data);
                return true;
            }
            return false;
        }

        public IEnumerable<Equipe> GetAll(int n = 10, int j = 2)
        {
            for (int i = 0; i < n; i++)
            {
                this.Add(new Equipe("Equipe " + i + 1));

                for (int k = 0; k < j; k++)
                {
                    listEquipes.ElementAt(i).AjouterJoueur(new Joueur("Joueur " + i + 1 + "-" + k + 1));

                }
            }
            return listEquipes;
        }

        public IEnumerable<Equipe> GetAll()
        {
            return listEquipes;
        }


        //mise à jour d'une équipe
        public bool Update(Equipe data)
        {
            if (data != null)
            {
                int index = listEquipes.FindIndex(x => x.Id == data.Id);
                listEquipes[index] = data;
                return true;
            }
            return false;


        }

        public Equipe GetDataWithId(int id)
        {
            throw new NotImplementedException();
        }

        public Equipe GetDataWithName(string name)
        {
            throw new NotImplementedException();
        }
    }
}