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

 

    }
}
