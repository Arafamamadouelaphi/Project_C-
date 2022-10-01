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
    public class UTPartie
    {
        //le cas ou le joueur ne fait que des strikes
        [Fact]
        public void TestGetScore()
        {
            //Arrange
            StubPartie stubPartie = new StubPartie();
            List<Partie> listParties = stubPartie.ListParties();
            Partie partie = listParties[0];
            partie.AddFrame(new Frame(1));
            partie.AddFrame(new Frame(2));
            partie.AddFrame(new Frame(3));
            partie.AddFrame(new Frame(4));
            partie.AddFrame(new Frame(5));
            partie.AddFrame(new Frame(6));
            partie.AddFrame(new Frame(7));
            partie.AddFrame(new Frame(8));
            partie.AddFrame(new Frame(9));
            partie.AddFrame(new Frame(10));
            partie.AddFrame(new Frame(11));

            for (int i = 0; i < partie.Frames.Count; i++)
            {
                partie.Frames[i].Lancer(10);
            }

            //Act
            int? score = partie.GetScore();

            //Assert
            Assert.Equal(300, score);
        }

        //le cas ou le joueur fait que des spares

        [Fact]

        public void TestGetScore2()
        {
            //Arrange
            StubPartie stubPartie = new StubPartie();
            List<Partie> listParties = stubPartie.ListParties();
            Partie partie = listParties[0];
            partie.AddFrame(new Frame(1));
            partie.AddFrame(new Frame(2));
            partie.AddFrame(new Frame(3));
            partie.AddFrame(new Frame(4));
            partie.AddFrame(new Frame(5));
            partie.AddFrame(new Frame(6));
            partie.AddFrame(new Frame(7));
            partie.AddFrame(new Frame(8));
            partie.AddFrame(new Frame(9));
            partie.AddFrame(new Frame(10)); 

            for (int i = 0; i < partie.Frames.Count; i++)
            {
                partie.Frames[i].Lancer(5);
                partie.Frames[i].Lancer(5);
                
            }

            //Act
            int? score = partie.GetScore();

            //Assert
            Assert.Equal(150, score);
        }

        //le cas ou le joueur fait que des spares et des strikes

        [Fact]

        public void TestGetScore3()
        {
            //Arrange
            StubPartie stubPartie = new StubPartie();
            List<Partie> listParties = stubPartie.ListParties();
            Partie partie = listParties[0];
            partie.AddFrame(new Frame(1));
            partie.AddFrame(new Frame(2));
            partie.AddFrame(new Frame(3));
            partie.AddFrame(new Frame(4));
            partie.AddFrame(new Frame(5));
            partie.AddFrame(new Frame(6));
            partie.AddFrame(new Frame(7));
            partie.AddFrame(new Frame(8));
            partie.AddFrame(new Frame(9));
            partie.AddFrame(new Frame(10));

            for (int i = 0; i < partie.Frames.Count; i++)
            {
                if (i % 2 == 0)
                {
                    partie.Frames[i].Lancer(10);
                }
                else
                {
                    partie.Frames[i].Lancer(5);
                    partie.Frames[i].Lancer(5);
                }
            }

            //Act
            int? score = partie.GetScore();

            //Assert
            Assert.Equal(200, score);
        }
    }
}