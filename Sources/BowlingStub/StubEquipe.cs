using BowlingLib.Model;
using Business;
using System;

namespace BowlingStub
{
    public class StubEquipe : IDataManager<Equipe>
    {
        private List<Equipe> listEquipes = new List<Equipe>();
        public int nbrJ = 10,nbrE = 2;
        public StubEquipe()
        {
            
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

        public void Load()
        {
            for (int i = 0; i < nbrE; i++)
            {
                this.Add(new Equipe("Equipe " + i + 1));

                for (int k = 0; k < nbrJ; k++)
                {
                    listEquipes.ElementAt(i).AjouterJoueur(new Joueur("Joueur " + i + 1 + "-" + k + 1));

                }
            }
        }
        

        public IEnumerable<Equipe> GetAll()
        {
            Load();
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
        

        public Equipe GetDataWithName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Equipe> GetAllWithDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}