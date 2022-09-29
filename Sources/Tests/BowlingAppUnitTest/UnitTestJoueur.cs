using System;
using BowlingLib.Model;
using Xunit;

namespace Test.BowlingAppUnitTest
{
    public class UnitTestJoueur
    {
        Joueur j = new Joueur("Paul");
        [Fact]
        public void TestConstructeur()
        {            
            Assert.NotNull(j);
            Assert.Equal( "Paul",j.Pseudo);
            Assert.NotEqual("joel",j.Pseudo );
        }

        [Fact]
        public void TestInvalidJoueur()
        {
            Assert.Throws<ArgumentException>(() => new Joueur(null));
        }

        [Theory]
       // [InlineData(false,"Augustin","Augustinn")]
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
                Assert.Equal(expectedPseudo, j.Pseudo);
            }

        }
    }
}
