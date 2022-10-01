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
        [InlineData(true,false,"Augustin","Augustinn",false)]
        [InlineData(true,true,"Amir","Amir",true)]
        [InlineData(false,false,"Amir","",false)]
        [InlineData(false,false,"Amir",null,false)]
        [InlineData(false,false,null,null,true)]
        [InlineData(false,false,null,"",false)]
        [InlineData(false,false,"",null,false)]
        [InlineData(false,false,"","",true)]
        [InlineData(false,false,"f2","f2",true)]

        public void  TestContructeur(bool isFormated,bool isValid, string expectedPseudo, String pseudo, bool isEqual )
        {
            if (!isValid && !isFormated)
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
