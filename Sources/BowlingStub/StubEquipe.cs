using BowlingLib.Model;
using BowlingLib.Interface;
using System;

public class StubEquipe:IDataManager<Equipe>
{
    private List<Equipe> listEquipes = new List<Equipe>();
    public StubEquipe()
    {
    }

    public void Add(Equipe data)
    {
        listEquipes.Add(data);
    }

    public void Delete(Equipe data)
    {
        listEquipes.Remove(data);
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
    public void Update(Equipe data)
    {
        int index = listEquipes.FindIndex(x => x.Id == data.Id);
        listEquipes[index] = data;
    }

}
