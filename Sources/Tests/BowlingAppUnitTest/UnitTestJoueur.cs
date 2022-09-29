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

        [Theory]
        [InlineData(false,"Augustin","Augustinn")]
        [InlineData(true,"Amir","Amir")]
        [InlineData(false,"Amir","")]
        [InlineData(false,"Amir",null)]
        [InlineData(false,null,null)]
        [InlineData(false,null,"")]
        [InlineData(false,"",null)]
        [InlineData(false,"","")]
        [InlineData(false,"f2","f2")]

        public void  TestContructeur(bool isValid, string expectedPseudo, String pseudo )
        {
            if (!isValid)
            {
                Assert.Throws<ArgumentException>(
                    () => new Joueur(pseudo)
                    );
                return;

                Joueur j = new Joueur(pseudo);
                Assert.Equal(pseudo, j.Pseudo);
            }
        }
    }
}
