using System;
using BowlingLib.Model;
using Xunit;

namespace Test.BowlingAppUnitTest
{
    public class UnitTestJoueur
    {
        [Fact]
        public void TestConstructeur()
        {
            Joueur j = new Joueur("Paul");
            Assert.NotNull(j);
            Assert.Equal(j.Pseudo, "Paul");
            Assert.NotEqual(j.Pseudo, "joel");
        }

        [Fact]
        public void TestInvalidJoueur()
        {
            Assert.Throws<ArgumentException>(() => new Joueur(null));
        }
    }
}
