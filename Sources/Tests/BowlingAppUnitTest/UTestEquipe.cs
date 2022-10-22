using System;
using System.Collections.Generic;
using BowlingLib.Model; 
using Xunit;

namespace Test.BowlingAppUnitTest
{
    public class UnitTestEquipe
    {

        public static IEnumerable<object[]> Data_AddJoueurToEquipe()
        {
            yield return new object[]
            {
                true,
                new Joueur[]
                {
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania"),
                    new Joueur("Cornelle")
                },
                new Equipe("ABRMC",
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania")),
                    new Joueur("Cornelle")
            };

            yield return new object[]
            {
                false,
                 new Joueur[]
                {
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania")
                },
                new Equipe("ABRMC",
                    new Joueur("Alys"),
                    new Joueur("Bénita"),
                    new Joueur("Regis"),
                    new Joueur("Mania")),
                    new Joueur("Mania")
            };
        }


        [Theory]
        [MemberData(nameof(Data_AddJoueurToEquipe))]
        public void Test_AddJoueurToEquipe(bool expectedResult,
                                          Joueur[] expectedJoueurs,
                                          Equipe equipe,
                                          Joueur joueur)
        {
             
            bool result = equipe.AjouterJoueur(joueur);
            Assert.Equal(expectedResult, result);
            Assert.Equal(expectedJoueurs.Length, equipe.GetJoueurs().Count);
            Assert.All(expectedJoueurs, j => equipe.Joueurs.Contains(j));
        }


        [Theory]
        [MemberData(nameof(TestData.Data_AddJoueurToEquipe), MemberType=typeof(TestData))]
        public void Test_AddJoueursToEquipe(int expectedResult,
                                   Joueur[] expectedJoueurs,
                                   Joueur[] expectedAddedJoueurs,
                                   Equipe equipe,
                                   params Joueur[] joueursToAdd)
        {
            var addedJoueurs = equipe.AjouterJoueurs(joueursToAdd);
            Assert.Equal(expectedResult, addedJoueurs.Count);

            Assert.All(expectedAddedJoueurs, a => addedJoueurs.Contains(a));

            Assert.Equal(expectedJoueurs.Length, equipe.Joueurs.Count);
            Assert.All(expectedJoueurs, a => equipe.Joueurs.Contains(a));
        }


    }
}
