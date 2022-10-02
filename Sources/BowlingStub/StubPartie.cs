using BowlingLib.Model;

namespace BowlingStub
{
    public class StubPartie
    {
        List<Partie> listParties = new List<Partie>();
        public StubPartie()
        {
            

        }

        //Fonction permettant de créer une partie pour chaque joueur
        public List<Partie> ListParties(int n = 10)
        {
            for (int i = 0; i < n; i++)
            {
                listParties.Add(new Partie(new Joueur("Joueur " + i + 1)));
            }
            return listParties;
        }
        
        

        
    }
}