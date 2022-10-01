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
        [InlineData(false,"Augustin","Augustinn",false)]
        [InlineData(true,"Amir","Amir",true)]
        [InlineData(false,"Amir","",false)]
        [InlineData(false,"Amir",null)]
        [InlineData(false,null,null,true)]
        [InlineData(false,null,"",false)]
        [InlineData(false,"",null,false)]
        [InlineData(false,"","",true)]
        [InlineData(false,"f2","f2",true)]

        public void  TestContructeur(bool isValid, string expectedPseudo, String pseudo, bool isEqual )
        {
            if (!isValid)
            {            
                Assert.Throws<ArgumentException>(
                    () => new Joueur(pseudo)
                    );
                return;
            }

                Joueur j = new Joueur(pseudo);

                
            if(!isEqual){
                Assert.NotEqual(expectedPseudo, j.Pseudo);

            }else{
                Assert.Equal(expectedPseudo, j.Pseudo);

            }
            

        }
    }
}
