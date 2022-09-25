using System;

public class StubJoueur
{
private	List<Joueur> listJoueurs = new List<Joueur>();
	public StubJoueur()
	{
	}

	public List<Joueur> ListJoueurs(int n = 10)
    {
		for (int i = 0; i < n; i++)
        {
				listJoueurs.Add(new Joueur() { Pseudo = "Joueur "+i+1 });
		}
    }

}
