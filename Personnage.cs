using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
    abstract public class Personnage
    {
        private string _nom;
        public string Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        private int _pvMax;
        public int PvMax
        {
            get { return _pvMax; }
            set { _pvMax = value; }
        }

        private int _pv;
        public int PV
        {
            get { return _pv; }
            set { _pv = value; }
        }

        private int _attaque;
        public int Attaque
        {
            get { return _attaque; }
            set { _attaque = value; }
        }

        private int _defense;
        public int Defense
        {
            get { return _defense; }
            set { _defense = value; }
        }

        private int _magie;
        public int Magie
        {
            get { return _magie; }
            set { _magie = value; }
        }

        private int _resistance;
        public int Resistance
        {
            get { return _resistance; }
            set { _resistance = value; }
        }

        private int _vitesse;
        public int Vitesse
        {
            get { return _vitesse; }
            set { _vitesse = value; }
        }


        public override string ToString()
        {
            return "\nSes caracteristiques sont les suivantes : \nAttaque : " + Attaque + "\nDéfense : " + Defense + "\nPuissance magique : " + Magie + "\nRésistance magique : " + Resistance + "\nVitesse d'attaque : " + Vitesse + "\n Point de vie maximum : " + PvMax + "\r\n";        }

        public Personnage(string nom)
        {
            _nom = nom;
            _pvMax = 50;
            _pv = 50;
            _attaque = 10;
            _defense = 10;
            _magie = 10;
            _resistance = 10;
            _vitesse = 10;
        }



        public void DessinerPersonnage(string s)
        {
            switch (s)
            {
                case "mage":
                    string DessinMage = @"                                   `.-:/oooo+:-..`                                
                               `-+ydNMMNNNMMMNmhs/-`                             
                              -+mNdhsoosssssyhmNMMmy/-`                          
                             -/NmoooosyyyyysooooydNMNy+-`                        
                            -+mhoooooosyyysoooooososhNNdo:.  `.:-`      `        
                           -/NNoooosssyyyyyyssooo+hsosdMMms:-+hNd+-              
                          ./mNoooosssyyyyyyysssooosNNdyshNMNmNdymN+-             
                         ./mMs+oooossyyyyyyyssooooohMMMNhsydhydNhmN+-            
                        `:hMd+ooooossyyyyyyyssoooooodMMMMMdymMNymNMNo-           
                        :sMN++oooossssyyysssssssssoosNMyymMMMh/-/yMMMs:`         
                       ./NMs+ooooosssyyyyyyysssyyhmNNNMN/:+y+-` `-/ymNd+:.`      
                      `:hMm++osssyyyyyyyyyyyyyyysssoshNMh:`.`      ..---...`     
                      -+MMo+oossyyyyyyyyyyyyyyyyyssoooyMM+-                      
                  `.-:odMNhdmNNmmmmmddddhddddmmmmNNmdddNMdo:-.`                  
              .-:oydNMMNmdhyysssyyyyyyyyyyyyyyyyysssyyhdmNMMNdyo:-.              
          .-:ohmMMNmhysooossssssyyyyyyyyyyyyyyyyysssssssoosyhmNMMmho:-.          
      `-:ohmMMNdysoooossssssyyyyyyyyyyyyyyyyyyyyyyyyysssssssooosydNMMmho:-`      
  `.-+ydMMNdyooooooossssssyyyyyyyyyyyyyyyyyyyyyyyyyyyyyssssssoo+++ooydNMMdy+-.`  
`-ohNMMMMNmNNNNNNmmmdyhyysoo+oooooooooooooooooooooooooosyyhyhyhdNNNNNNmNMMMMNho:`
:sMMNMMMMMMMMMMNNNNNMNNNMMMMNdhhhhdddddddddddddhhhhdNMMMMNmhdmmmNNMMMMMMMMMMNMMs:
:yMMyMMMMMMMNMMNmmmNM::+Nmo/+so+/::+oydMMMdyo/::/+os+/omN+::MNmmmNMMNMMMMMMMyMMy:
./NMmymMMMMNNNmmmmmMy:::ym/:/odMMmyyhdsysysdhyhNMMdo/:/my:::yMmmmmmNNNMMMMmymMN/.
 ./dMMdhdmNmNNNmmmMm::-:hN/:/sdy+::yMMm:::mMMy::ohds/:/Nh:-::mMmmmNNNMMmdydMMd/. 
  `-+hNMMmdhhhdmmMN/:s/sMy/:::::ohNMMMN:::NMMMNho/::::/yMs/s:/NMmmdhhddmNNNh+-`  
    `.:oydNMMMNmmN/:ds:dM/:::::/+o+//sy:::ys//+o+/:::::/Md:sd:/NmmNMMMNdyo:.`    
        `.-/osyNN/-dh::dMo::::::::shhy:::::yhhs::::::::oMd::hd-/NNyso/-.`        
             :sN/-dd::sNMNo:::::/ds:+y:::::y+:sd/:::::oNMNs::dd-/Ns:             
            -oMo-dm::/N/mMNh///+md//hy+/::+yh//dm+///hNMm/N/::hd-+Mo-            
           `:mdoNN::shd-+NNNmhdNNNyo--+sss+--oyNNNdhmNNN+-dhs::NNodm:`           
           ./NdNN/-+hmy-.-ohddhy+-.....-o-.....-+yhddho-.-ymh+-/NmdN/.           
           -//sMo-/m:hN:---..--------:smMms:-------------:Nh:m/-oMs//-           
           `.:mm-/m::/mNs/::--::::+yhyo+/+oyhy+::::--::/sNm/::m/-mm:.`           
            `:myoN+:-::yMdNmdddsyys+/+oosoo+/+syhoyydmNdMy::-:+Noym:`            
             :hdNd-::::yM/-:::m/+ydmhs++/++shmmy+/m:::-/My::::-dNdh:             
             -:/Mo:m---oMs----oMNh/...-----.../yNMo----sMo---m:oM/:-             
              ./Msmm-:h:mN/------.-------------.------/mm:h:-mmsM/.              
              `/NMdm-yM/oMd/s/---------------------/s/dMo/Md-mhMN/`              
               -oy/N+MNd:MMMMs---------------------sMMMM/dNM+N/so-               
                -::yNN+NdMhNNN/+/---------------/+/NNNhMdN+NNy:--                
                  `:ss::sd++/NNMy-:/:-------:/:-yMNN/++ds::ss:`                  
                    .:. `.--:+myNydN/-------/NdyMym+:--.` .:.                    
                             .::dMNMh:-----:hMNMd::-``                           
                               ./y/dMh/:-:/hMm/y/.                               
                                `-./yNNy+yNNy/.-`                                
                                    .:odMdo:.                                    
                                      `-:-`                                      
      
                                                                 ";
                    Console.WriteLine(DessinMage);
                    Console.WriteLine(DessinMage.Length);

                    break;
            }
        }

    }
}
