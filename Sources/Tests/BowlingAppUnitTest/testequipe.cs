using BowlingLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BowlingAppUnitTest
{
    public class TestEquipe
    {
        [Fact]
        public void testConstructeur()
        {
            Equipe p = new Equipe("sao");
            Assert.NotNull("p");
            Assert.Equal(p.Nom, "sao");
            Assert.NotEqual(p.Nom, "sao");

        }
        [Fact]
        public void TestInvalideEquipe()
        {
            Assert.Throws<ArgumentException>(() => new Equipe(null));
        }


    }
}
