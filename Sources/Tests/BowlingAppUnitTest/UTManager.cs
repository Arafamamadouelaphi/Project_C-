using BowlingLib.Model;
using BowlingStub;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BowlingAppUnitTest
{
    public class UTManager
    {
        //test de la méthode AddJoueur using MemberData
        [Fact]
        public void TestAddJoueur() //Test de la méthode AddJoueur
        {
            //Arrange
            Joueur joueur = new Joueur("Pierre");
            Manager manager = new Manager(new StubJoueur());

            //Act
            manager.AddJoueur(joueur);

            //Assert
            Assert.Single(manager.JoueurDataManager.GetAll().Result);
        }

        //Test de la méthode AddPartie
        [Fact]
        public void TestAddPartie() //Test de la méthode AddPartie
        {
            //Arrange
            Partie partie = new Partie(new Joueur("Pierre"));
            Manager manager = new Manager(new StubPartie());

            //Act
            manager.AddPartie(partie);

            //Assert
            Assert.Single(manager.PartieDataManager.GetAll().Result);
        }


    }
}
