using BowlingEF.Context;
using BowlingLib.Model;
using BowlingMaping;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingApp
{
    public class JOuerEFtest
    {
         static void bobo(string[] args)
        {
            Joueur j = new Joueur("ps1");
            Joueur j1 = new Joueur("ps2");
            Joueur j3 = new Joueur("ps3");
            IDataManager<Joueur> joueurDataManager = new JoueurDbDataManager();
            IDataManager<Equipe> equipeDataManager = new EquipeDbDataManager();
            IDataManager<Partie> partieDataManager = new PartieDbDataManager();
            Manager manager = new Manager(equipeDataManager,partieDataManager, joueurDataManager);

            Partie p = new Partie(j);

            for(int i = 0; i < 10; i++)
            {
                Frame frame=new Frame(i+1);
                Console.WriteLine("Entrer les quilles tombés");
                frame.Lancer1 = new Lancer(int.Parse(Console.ReadLine()));
                Console.WriteLine("Entrer les quilles tombés");
                frame.Lancer2 = new Lancer(int.Parse(Console.ReadLine()));
                p.AddFrame(frame);
            }
            manager.AddPartie(p);
            




        }
       
        
    }
}
