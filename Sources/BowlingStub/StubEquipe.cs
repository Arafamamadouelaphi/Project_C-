using BowlingLib.Model;
using System;

public class StubEquipe
{
	private List<Equipe> listEquipes = new List<Equipe>();
	public StubEquipe()
	{
	}

	public List<Equipe> ListEquipes(int n = 10, int j = 2)
	{
		for (int i = 0; i < n; i++)
		{
			listEquipes.Add(new Equipe("Equipe " + i + 1));

			for(int k = 0; k < j; k++)
            {
				listEquipes.ElementAt(i).AjouterJoueur(new Joueur("Joueur " + i + 1 + "-" + k + 1));

			}
		}
        return listEquipes;
    }

}
