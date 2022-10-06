using BowlingLib.Model;
using BowlingStub;
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
            Assert.Single(manager.joueurManager.GetAll());
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
            Assert.Single(manager.partieManager.GetAll());
        }

        //Test de la méthode AddEquipe
        //[Fact]

        //public void TestAddEquipe() //Test de la méthode AddEquipe
        //{
        //    //Arrange
        //    Equipe equipe = new Equipe("Equipe 1");
        //    Manager manager = new Manager(new StubEquipe());

        //    //Act
        //    manager.AddEquipe(equipe);

        //    //Assert
        //    Assert.Single(manager.equipeManager.GetAll());
        //}


    }
}
