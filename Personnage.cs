using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J_RPG
{
     public class Personnage
    {
        private List<Item> _ListeItem;
        public List<Item> ListeItem
        {
            get { return _ListeItem; }
            set { _ListeItem = value; }
        }


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
            get { return _attaque + GetBonus(Stats.attaque); }
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
            return "\nSes caracteristiques sont les suivantes : \nAttaque : " + Attaque + "\nDéfense : " + Defense + "\nPuissance magique : " + Magie + "\nRésistance magique : " + Resistance + "\nVitesse d'attaque : " + Vitesse + "\nPoint de vie maximum : " + PvMax + "\r\n";        }

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
            _ListeItem = new List<Item>();
        }



        public void DessinerPersonnage(string s)
        {
            switch (s)
            {
                #region DessinMage
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
                    break;
                #endregion
                #region DessinChevalier
                case "chevalier":
                    string DessinChevalier = @"                                       `-:-:-+/-.-`                              
                                   :ohNMMN+mhoyshhsm++:-                         
                                -sNMNmdhhyoysosyosssymhhms:                      
                              :dMNmhyyyyyysssysssssysssyyddh/                    
                            .hMNdyyyyyyyyyyyyyyyyyyyyyyyyydNMd-                  
                           /NMmhyyyyyyyyyyyyyyyyyyyyyyyyyyyymMN+                 
                          +MMdyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyydMM+                
                         -NMdyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyydMM:               
                         hMNyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyymMd               
                        .MMdyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyhMM-              
                      .ymMMdhhddmmddhyyyyyyyyyyyyyyyyyyyyyyyyyyyMM/              
                      +NmhhdhddmMMmNMdyyyyyyyyyyyyyyyyyyyyyyyysymm/              
                  `-/osdshoo+sshdNo+dshsyyyyyyyyyyyyyyyyyyyyyy+oyh/              
              `-+hmNNNsyyo+y+y/yosoddsssyyyyyyyyyyyyyyyyyyyyyy/sds-              
            .+hNNNmhhyssssssssssoysosyddyhyyyyyyyyyyyyyyyyyyyyssdd/              
          .omNdo:/shhysssysssssyssssys/-:ohhyyyyyyyyyyyyyyyyyyssNN/              
        `+mMh/-----:sdyyyyyyyyyyyyhdo------+hhyyyyyyyyyyyyyyyyyyMM/              
       `yMm+---------/dhyyyyyyyyyhd/---------odhyyyyyyyyyyyyyyyyMM/              
      .dMd:-----------/myyyyyyyyym:-----------/dhyyyyyyyyyyyyyyyMM/              
     `dMd--------------ydyyyyyyymo-------------:dhyyyyyyyyyyyyyyMM/              
     sMm:--------------/myyyyyyyN---------------:myyyyyyyyyyyyyyMM/              
    .MM+---------------:NmmmmmmdN----------------sdyyyyyyyyyyyyyMMo        ``    
    oMN---------------smmddmmdddmdo--------------:NyyyyyyyyyyyyydMN+`    -yNNd/  
    ydy--------------hmdmmhyyyhmmdms------.-..----myyyyyysyyyyyyydNMNhyhmMNmmMN  
    /ys.`.........../NmmmNyooohNmmmN:-----........sooyoos:soyyyyyyyhddmmdhyydMN  
    sh/-`..........-sdyNNMoooosMNNydy:----`.......os/o+os:+oyyyyyyyyyyyyyyyymMd  
    ymy--.-----.-/yy+odNNmoooooNNNhoohy+--.-----.-hssyssysysyyyyyyyyyyyyyyyhMM+  
   `hMs------:oshdmsooNNNdooooomNNmoohNmds+:------yysysyssyyyyyyyyyyyyyyyyymMd   
  /mMm//+osyhysyNNMsooMNMyooooohNNNooyMNMssyhyoo/:/dhyyyyyyyyyyyyyyyyyyyyymMm.   
 +MNyhyysmNNhoodNNNooyMNNoooooosMNMsooMNNhoomNNdsyhhydyyyyyyyyyyyyyyyyyyhNMd.    
 mMyyyooommmyoodmmhooydhhhdmmddhhhdsoodmmhooymmmooohohhyyyyyyyyyyyyyyyhmMNo`     
 hMdydhhhhhhhhhhhddddmmmmdmNNMmdmmmmddddhhhhhhhhhhhdsmyyyyyyyyyyyyyhdmMNy.       
 .hMmNddmNNNmdmNNNmdmNNNddmMNMdddMNNmdmNNNmdmNNNddmNmhyyyyyyyyhhddNMNdo.         
  `sMMdddMNNNdmMNMmdmMNMmdmMNMddmMNMmdmNNMddNNNNddmMMMNNNNNNNNNNmdy/.`           
   :MMmddNNNNddMNNNddMNNmdmMNMddNNNMddNNNNddMNNmddNMN:://+++/:-..`               
    dMNddmmmmmdNNNNddNddhyhNdMddNNNNdyNNNmdmmmmmddNMy                            
    hMmyyyyhhdmmNNNddNyhssyy+dssydyyyoyymmmdhhyyyyNMs                            
  .oNMmyyyyyyyyhhdmmdmhhhsoNsmoyyhsyyssoyyyyyyyyyyNMm+.                          
 `mMNdhyyyyyyyyyyyhdmmddddhmddhmdddhdysssyyyyyyyyyhdNMd                          
 `dMNdhyyyyyyyyyyyyyyhdmdmdmmNdmmmdyysyyyyyyyyyyyyhdNMh                          
  `/dNNmhyyyyyyyyyyyyyyhmmmNNNmmdhyyyyyyyyyyyyyyhmNNh/`                          
     :yNMmhyyyyyyyyyyyyyhddyyyddhyyyyyyyyyyyyydmMNs-                             
       .omMNdhyyyyyyyyyhd+/////omyyyyyyyyyyhdNMm+.                               
         `/dNNmhyyyyyyyds///////hdyyyyyyyhmNNh/`                                 
            :yNMmhyyyyyms///////ydyyyyydNMNs-                                    
              .omMNdhyyms///////ydyyhdNMm+.                                      
                `/dNNmhms///////ydhmMNh:                                         
                   -sNMMs///////yMMmo.                                           
                     .MMdyyyyyyymMN`                                             
                     `hhhhhhhhhhhhy                                               
                                                                                 ";
                    Console.WriteLine(DessinChevalier);
                    break;
                #endregion
                #region DessinAssassin
                case "assassin":
                    string dessinAssassin = @"                               .--::::::://///:`                                 
                          -/shmNMMMMMMMMMMMMMMMMNmhyo/-                          
                     -/sdNMMMMNNNNNNmmmmmmmmmmmmNNNNMMMNh+-                      
                `/sdNMMMNNNNNNNNNNNNNNNNNNNNNmmmmmmdmmNNMMMmy/.                  
              /yNMMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmmmmmmmNNMMNd/                
           -sNMMMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmmmmmmmmNNMMm/              
        `+dMMMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmmmmmmmmmmNMMd:            
      .sNMMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmmmmmmmmmmmmNMMd-          
     +NMMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmmmmmmmmmmmmmmMMNo         
   .hMMMNNNNNMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmmmmmmmmmmmmmmNMMh`       
  -NMMMNNNNMMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmmmmmmNNNmmmNMMm.      
 -NMMNNNNNMMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmNMMN:     
 dMMNNNNMMMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmNMMN:    
 NMMNNNMMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmNMMd    
 oMMMNNMMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmdmNMM/   
  +mMMMMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmMMm`  
    `MMMNNNMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmNMM+  
    oMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNMMMMMMMMMMMMNNNNNNNNNNNNNNNNNmmNMMh  
   :MMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNMMMMMMMMNNNNNNMMMMNNNNNNNNNNNNNNNNNmmmMMm  
   dMMNNNNNNNNNNNNNNNNNNNNNNNNNNNNMMMMNdhyo++///////+oyhmMMMNNNNNNNNNNNNNNmmMMM. 
  :MMNNNNNNNNNNNMMNNNNNNNNNNNNNMMMNdy+////////////////////shNMMNNNNNNNNNNNmmNMM: 
  dMMNNNNNNMMNNNNNNNNNNNNNNNMMMMNy+//////////////////////////ohNMMNNNNNNNNmmNMM+ 
 /MMMNNNNNMMMNNNNNNNNNNNNNMMMNNNMMNdyo/////////::::::::://////+sNMMMNNNNNNNmNMM: 
 oMMNNNNNNNNNNNNNNNNNNNNMMMMNmmmmmNNNMNdy+-...............-+hmMMNNNMMMNNNNNmNMM. 
 sMMNNNNNNNNNNNNNNNNNNMMMmNMNNNNNNNNmmNNNMNds+yddh/.oddysdNMNNNNNNNMMMMNNNNmMMm  
 dMMNNNNNNNNNNNNNNNNMMMms/mMNNNNMMMMNNNNNNNNNNNNMM+/MMNNNNNNNNNNNNNMMMMMMNNmMMy  
 NMMNNNNNNNNNNNNNNNMMNy///sNMMMd+:/oydNMMMNNNNNNMN.-NMNNNNMMMNmyNMMMMMMMMMNNMN:  
 yMMNNNNNNNNNNNNNNMMd+/////+yNMo  ````.hsodhmNMMd:../dMMdyo//ys:NMMMMNMMMMMMMs   
 `mMMNNMMMNNNNNNNMMd/////////oNMo`     +h+-`:mMs.....-mMs``  .omMNMMMMMMMMMMh    
  /MMMNNNNNNNNNNNMMMy/////////:yNNs/-`  `-+hMm/......--hMd+/+hMm+hMMMMNMMMMd`    
   .dMMNNNNNNNNNNMMMMd+///////..-+ymNMNNMMNh/......::h:.:shdmmdo+NMMMNMMMMs      
    `yMMMNNNNNNNNNNNMMNy+////:..--:/+syys/..........+o-.........oMMMMMMMm/       
      /mMMMNNNNNNNNNNMMMNh+//:.-::::-.............../+o+/-.....sMMMMMMmo`        
        :yNMMMNNNNNNNNNNMMMmy/...................-+o/:--....:sNMMMMMm/`          
           :yNMMMMNNNNNNNNMMMMds/:..................-yNy-+ymMMMMmy+.             
              :+yNMMMMMMMNNNMMMMMMNmhs+/:--.....--:/osmNMMMMmy+.                 
                  .:oyNMMMNNMMMMMMMMMMMMMMMMMMMMMMMMMMMMNy/.                     
                     .dddhhhhddddddddddddddddddddddhhhddd:                        ";
                    Console.WriteLine(dessinAssassin);
                    break;
                #endregion
                #region DessinArcher
                case "archer":
                    string dessinArcher = @"                                                                                 
                                              s                                  
                                              ds                                 
                                             `dm:                                
                                           `++:dd:                               
                                          +o`  odmo                              
                                        /o.     sddh`                            
              `.-.                    /s.        +mhd/                           
           `/osydddo                :s-           -dddh.                         
                `/hmy   :oyo-     -s:               smdmo`                       
                  :mMysmmmmmNs` -s/                  :mddd:                      
                  +NmNNNmmmmmmms/      `              .dmhmy`                    
                   hNmmmNNNNNNNdo:.    y+/o- `          ymhdd.                   
       `.-`         :NMdmmmNmmmNNNNmy`/dhhdhhy+--        ymhdm-                  
 .ysoo+::-/:/:/o++/:ohd-/yd//+sm:-.` :mNNNmmhyso`         ddhdm.                 
 s+:/:.```..-dNhs+++mdoos:oy+h/y.   `mmmmmmmmdm-          -Nhhhh                 
 `sd/.::-...NNNN/..-:sms-./o+s:Nysyyooosdmdmmmd            dmhhdo   -.           
   .sy+/oyhdNMMm..---::/odhhddmNNNmyyssssmmmmmo///////::::-hNdddN.```+do+/:`     
      ...``:sy+od::://ydoss//+mNM:--::::///+++sdhmNmmsoooosyddmddddmmhm+++shdhs- 
             `+mNMhyhmMmhsNNmmmNN....o........./mMMNhs+/-..y:.yo--y.:yyo+++/-.   
               oNmNmmNNNoMNmmmmmMh:.ydo-.....-.MNNN:./mMMhy.o.:+-/y-.            
               -MmNNmmNNMNNNmmmmmNMNMmMMdyyosyomMNm..hMMNo:.y/+/:/h              
                oMmNNmmNNmmmNNmmmmNNmmMNmNo   .+ydNhohmhdhy-h:.-:y/              
                 /MNNNmmNmhhhdNmNNNmmNNmmh        `..`    mmhdso+:               
                  NNmmNmmNdhhdNMmmmmmMmmm`               -Mdmmmh                 
                  -dNmmNNmNNNmmmNNmmMNmN-                omhhhm.                 
                    /mmmmNmmNNmmmNNmNMNo                `mdhhm-                  
                     `dNmmNNmmNNNmNNmNN                 ymhdm-                   
                      `dNmmmmNNmmNNNMNN:               smhdd.                    
                        hNNNNmNNNNNNmNN`             `hmhdy`                     
                        `ymNm/:/mmNds.-h-           -ddhm+                       
                           .:/:::-`    `y+         omddh.                        
                                         /y`     `hmdm+                          
                                          .h-   .mdmh.                           
                                            so `mdm+                             
                                             :yymm-                              
                                              :Mm.                               
                                              +M-                                
                                              +y                                 
                                                                                  ";
                    Console.WriteLine(dessinArcher);
                    break;
                #endregion
                #region DessinPretre
                case "pretre":
                    string dessinPretre = @"                            -:+osyhhddmNNNNmddhhyso+:.                           
                      `:oydmmmmmmmmmmmmmmmmmmmmmmmmmmmmdy+:`                     
                   :odmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmho-                  
                .smNNdhhyssoso++//////////////////+++osossyhdNNm+-.`             
         `-/oydmmmmmm          ..`              ..          /mmmmmmmm+///-`      
     `///:` hmmmmmmmm        .o- s:           .y``s-        /mmmmmmmN.   .://.   
   -+:`     hmmmmmmmm      `-..dd/...       `-.:hd-.-`      /mmmmmmmN.       /o` 
  +/.`      hmmmmmmmm       .:y/-s+.`       `.:h--h/`       /mmmmmmmN.      :--y 
 `s..o`     hmmmmmmmm          :`.             `--`         /mmmmmmmN.    `-o+-h 
 `s/y-.`    hmmmmmmmm                                       /mmmmmmmN.    `-oh+o 
  y:os.     hmmmmmmmm                                       /mmmmmmmN.     `+/h- 
  o//.      hmmmmmmmm                                       /mmmmmmmN.     `-:h  
  +/-`      hmmmmmmmm                                       /mmmmmmmN.     `.:s  
  -o-`      hmmmmmmmm                                       /mmmmmmmN.     `.+/  
   y-.`     hmmmmmmmm                                       /mmmmmmmN.    `.-y.  
   o/.`     hmmmmmmmm                                       /mmmmmmmN.    `.-h   
   -s-`     hmmmmmmmm    `.-::/++/++oooooooo++++++//:-.`    /mmmmmmmN.   ``./s   
    h:.`    hmmmmmmmm++ossso+++++///::::::::::::::///+oosoo+yNmmmmmmN.   `.-o/   
    s/.`    hmmNmhso+//::-...````..--:::/.......---------::::/+syhmmN.   `.-h`   
    :o-`  `/hd+-...`````````````````````o-......//::://///::////+::+so+.``.:h    
   :sy:.:oo+/`````````.--///+++o+oh:`://-....:doo++++///::-.`````-//--:os/-/y    
 -s:`s/s+--+``.o++++oo+/:--------:+y//:::::::/y---------://+oo+o+++.//---+ysso/  
:s```ss-..+```.h----:/+o++++++oy+:-```````````:/+so++/+++oo+/:---+o``//---:m:`:y`
h.```:/..-/```:y+//:--`   `--.  ---```````````---  ---`    `--://o/```o----s.``:s
d`````o..+.````-:       .ydddddo` `:.```````.:` `sdddddy.       ::````/:---o````d
s:````o..o```````::     yddddddd:   -:`````/.   odddddddo     -:.``````o---+```.h
`y:```/:.+`````````:-`  -ydddddo` --:.`````.:-. `sdddddy.  `-:.````````o--+.```y-
  /o:`-/.o```````````-----:+o/:---`````````````---:++/-.----```````````o--o``:s. 
    -++o.+.``````````````````````````````````````````..````````````````s--s+o-   
      `+.-+`````````````````````````.:////:.``````````````````````````.o--+      
      `o..o```````````````````````+/-``````-/+````````````````````````:/-::      
      `+..::`````````````````````:.``````````.:```````````````````````+:-+`      
      ./...o`````````````````````.-:::::::::-`````````````````````````o--+       
      -/...o`````````````````-::/:----------:///:.````````````````````o-+.       
      -/...:/`````````````.:/:-------------------://`````````````````:/-+        
      `+...-o```````````-//-------------------------//.`````````````.o-+.        
       +-...:/`````````//-://:::::::::::::::::::://:--//```````````.o--+         
       `+..../:``````.+-//ydddddddddddmmmmmmmmmNNNNMm+-:+.````````:+--o`         
        ::..--//````-+--+``omMMMMMMMMMMMMMMMMMMMMMMh:.o--o.`````:+:--:/          
         /:-----//--o---+:```:oymNMmdhhddmmmNMNds+.`-+----o-:://-----o           
          /:-------:------//:-````.-::::/::-..``.://:------:--------o`           
           :/----------------:///::::::::::::///:--------------::--+.            
            .+-----------------------------------------------::---+`             
              -/-------------:-----/----:----:-----/------------//`              
                -//----------:-----/----:----:-----/----------//.                
                  `-::/------/-----/----:----/-----/-----//::-`                  
                       +:----/-----:----:----/-----/----+:                       
                        -/:--:---------------:-----:-://`                        
                          .:::////////////////////:::.                           
";
                    Console.WriteLine(dessinPretre);
                    break;
                #endregion
                #region DessinChaman
                case "chaman":
                    string dessinChaman = @"                                                                                 
               `                                                                 
             -:`    `                               -.                           
            //     `o/`                              /:                          
           -o-      -+o/.                    `-:-    -o-                         
          `+o+:---::/+ooo+::...``         `-/ooo-...-+oo-          ..            
          .-/ooooo+++ooooooo+::::.```-:::/oooooooooo+oo/- .....``.``.            
              ```-:-/+//://++//::.`..-.-::+++++-..:/.``   .-+ss:.. .-.           
                  ` `  :--`/-//:-.``.```-:oy/     `       `/dddh+-` `-           
                      `-:-:/..++//-.` .`.ohhs              .ydddds:....          
                      .-++/-.sdddd/-.` ``.+yy               -:+ooo:..`.          
                      `:ooo:.oso+/-.....-..-/               / :/-...-..`         
                      `+oo+//::---::://+:-......`           :-++:...-..          
                   `-+oooo////:::::::ohhy:-::-....`        .-:/+.`..-.`          
                 `/shyooo+////oyysss+syss+oyy.   ```        `+:/   `:`           
                .+syyyooo+////oyhhys/------oh//+            -/::   `-`           
              `-/+oooooooo+/-``.:+:........sdddh`         ``/+++`  ...           
           `-/++/:-+ooo+o+ooo+::::--:......-:::.      `  .::://+/`               
        ``:++oooo+:-osoo+o++++oo++///.:--.::-         o/:/:/+//y/`               
       .:o+/+/+oo+++yyoooooooo+++++oo+//o/ooo-   ``--:ohyyssyo+s:                
      `ssyssyo+:shhhhsoo++oo--.---:+hyyssooooo:////o+//syhysy++/`                
      .////++++`:yhhhsoo+++:.-------sssoooooo+oyo//+o//+sysoo:`                  
      :++++++++` :shhhsso++-.......:/-.`-:+o+/+sy+//++////oo+                    
      -++++++++`  `/hhhysoo/--..-.-.      `.///oys/////.`/oo.                    
      `//++++oo:.   -hhsooo+++++++o--        `--:/.```  -oo/                     
       /yyyhsyos:    +ysooooo+++++ooo:                 `+o+`                     
       :o++s/::::.  .ohsysysy+//-:+ys+.                /++:                      
         .:::/:/+/-/osyysyhyhoo+/ooyhso.              .+//                       
         `:::s/:y//ssyyhhyyoyys+oosyyyhh-             +//-                       
        -o+:os./y-`:/+oyoys+ohyooysy+hddh            :+:/                        
        .-``.`        :o/s/-ossooosyooyhd`          `+//.                        
                ``-/+/oo/+sooooooooyooosh.          /+::                         
               `ssyoooo+/:yssssossyyooo+.          -o//`                         
               :+syyss//--:``ooyyyyyyo:           `++:-                          
               //+/++:-       `++++++             :+::                           
               +++++/          :+++++-           `o+/.                           
               //+++/          `////++`          /o/-                            
              `oososs/          .osossso/       .o+/`                            
               `-:::/:.          ``-:::/:.       ```                             
                                                                                 
                                                                                 
";
                    Console.WriteLine(dessinChaman);
                    break;
                #endregion
                #region DessinGuerrier
                case "guerrier":
                    string dessinGuerrier = @"               ``                                               ``               
               ````                                           ````               
               ``````                                       ``````               
               ```++.```                                 ```.++``                
                ``oNmo-```                             ```-omNo``                
                ``+Nhymy:```                         ```:ymyhN+``                
               ```/Nh .smh/.```                   ```./hms. hN/```               
             ```:ymNd   `yNh.``                   ``.hNy`   dNmy:```             
           `.`:hNNh+s`  .mN+``                     ``+Nm.  `s+hNNh:`.`           
         ``./hmNh/`     hNh.``                     ``.hNh     `/yNNh/.``         
       ``.+dNNy-`      oNN:``                       ``:NNo      `-ymNh/.``       
     ``.+dNms-        :NNs```         ``````        ```sNN:        -smNd+.```    
  ```.+dNdo.         .mNm.``     ````.-/+/-.````     ``.mNm.         .odNd+.```  
  ```-yNNo`          /mNmo-``````-/ohdmmdmmdho/-``````-omNm/          `oNNy-```  
    ``./dNh:          ./ymmy/.-+ymNNNy:-.-:yNNNmh+-./ymmy/.          :hNd/.``    
      ``.omNy-           ./ymdmNmdhmN:`````:NmhdmNmdmy/.           -yNm+.``      
        ``-smms.           :mNmhyyydN:`````:NdyyyhmNm:           .smms-``        
         ```:yNm+`       `ommhyyyyydN:`````:Ndyyyyyhmmo`       `+mNy:```         
           ``./dNd/`    -hmhyyyyyyyhN:`````:Nhyyyyyyyhmh-    `/dNd/.``           
             ``.+dNh- `+mmyyyyyyyyyhN:`````:Nhyyyyyyyyymm+` -yNd+.``             
               ``-smmyyNdyyyyyyyyyyyN-`````-NyyyyyyyyyyydNysmms-``               
                ```oNNmNdhyyyyyyyyyyN-`````-NyyyyyyyyyyhhNmNNo```                
                ``-mNs+sh+yhdhyyyyyhN.`````-Nhyyyyyhddh+sy/oNm-``                
               ``.hNN.o.N``/sdmdddddN/-----+Ndddddmdy/``h:+:mNh.``               
            ```./yNNN++/h`:y--+h::/+oshdmdhso+/:-h/.+s+`so+/NNNy/.```            
          ``.-odmdoydmds-`y/ .+y+```.s+:-/os.```:h `o:h`.odmdyodmdo-.``          
        ``./ymmy/--.-/ydy++h:++h.```+y   .+y+```.h//+ys+ydy/----/ymmy/.``        
        ``+NNo-.-..-.--:dmyhmdy/-...-h/-/++h-...-/ydmdymd:---...-.-oNN+``        
        ``/NN:--.----:smdy/-:/ydmmdhhhmmdmNhhhdmmdy+:-/yhms:-.-----:NN/``        
        ``-NN/::-.-:smNNNNNNhs/-:+ohhhhhhhhhhho+:-/shmNNNNNms:-.-::/NN-``        
        ``.NNoy:.-ohydNmhmNNNNNmho:-`./s:s/.`-:ohmNNNNNmhmNmyho-.:yoNN.``        
        ``.mNsN:.--.-/NmmhhhmNNNNNNd+dNNNNNd+dNNNNNNmhhhmmN/-.---:NsNm.``        
        ``.dNNN:---:smdhNNNNdddmNNNNNNNNyNNNNNNNNmdddNNNNhdms:---:NNNd.``        
      ``./dNds/--/smd+..+mNNNNNNmmmNNds:`:sdNNNmmmNNNNNm+`.+dms+--/sdNd/.``      
    ```:hmyN:+ydNNNs.````.osssshNNmNN/`````/NNmNNhsssso.````.yNNNdy+:Nymh:```    
  ```-yNs--hNmhs/-+dh:```````-+o/-.dy```````yd.-/o+-```````:yd/-/shmNh--oNy-```  
```.sNdm----dy-----/dNh:`.```.```./N/```````/N/````.`````:yNd/---.-yd----mdNs.```
``:Nd/.sd---:mhohhyo+NNNmy-````-+ymN+```````oNmy+.````-ymNNN+oyhhohm:..-ms./dN:``
``/No-..ydsyhyo/-.--/NNNh.`./sdNNh:.o+`````+o./hNNds/.`.hNNN/--.-/oyhyody.--oN/``
``/No-.-.ym:--..---.oNNh:ohNNdysN-```..```..```-NsydNNho:hNNo-.--..-.:my---.oN/``
``/Ns..---hd-..:+shmNNNmdho/----/hy:`````````:yh+----/shdmNNNmhs+:---dh--..-sN/``
``/NN+...--ddssNNNNNNh+:------.:.-/ydo-...-ody:--:.--..---+hNNNNNmysdd---.-+NN/``
``/Nymo+sss+:-yNNNNNo--...-:y-/y.-.--odNNNdo--..-y/-y:-....-oNNNNNy-:+sss+omyN/``
``/Ns/my---..sNNNNN+--.--.omh+mmyyyyyssyyyssyyyyymm+hmo-.-.-.+NNNNNs..---ym/sN/``
``/Ns.:mo/oydNNNNm/---.--yNNmo/:.````       ````.:/omNNy-..---/mNNNNdyo/om/.sN/``
``/Ny+shhs+/NNNNm/--..--yNmy/-.`    `..---..`    `.-/ymNy--...-/mNNNN/+shds+yN/``
``/Ndo/----yNNNd:-.----yNds/.`.:+shddhhyyyhhddhs+:.`./sdNy-.----:dNNNy-.--/odN/``
``/Ny.--.-+NNNh-.-.--.oN+``:ohhys+:--://///:--:+syhho:``+No..-..--hNNN+--.-.sN/``
``/Ny.:+ssmNNy---.:/-:md:sys+:--:/shdhyNNmyhdhs+:.-:+sys:hm:-/:----yNNmss+:.yN/``
``/Ndys+:oNNs--.-:h-.hNmo:-..:odmNNm/-.mNm.-/mNNmdo:..-:omNh.-h:----sNNo:+sydN/``
``/Nh--.-mNy::o-:do:/NmNo/:+yys+NNm/.--yNy---+mNN/shy+::oNNN/-od:-+--smm-.--hN/``
``/Nh-/odmy/:sh/md:-yNNmNmdo////Nm+/-//omo-//:+dN://+oymmNmNy/:dd:do-/+dds/-hN/``
``:mmdmNNd++hmddNs-:mNNmdo+-.//+m+:/-:::m/://::/mo:://:sdNNNm/:sNhmmho-dNNmdmm:``
```:dNNNNm/:NNNNm++oNNms---..--//---.---+-------:/-------smNNo+/NNNNN:-NNNNNd:```
  ``.sNNNN+-mNNNo:mmNd/-.--------.--------------------...-/mNNm:oNNNm-+NNNNs.``  
   ``./mNNh.dNNy-dNNh:--..-------------------------------.-:hNNd-yNNd.hNNm/```   
     ``-yNm-yNh-hNNy-.-..---------------------------------.--yNNh-hNy-NNy-``     
      ``.om+od-yNNy--.----------------..----------------.--..-yNNy-do+m+.``      
       ```:o::oNNh-.-.-.-------------.-------------------.-----hNNo::o:``        
         ``...ohmh/---o..---.-:--.--..-.o.--.--.--:------.o---/hmdo...``         
            ```.:ymh+so-----.-s--.---.-.m...-..-.-s-------os+hmy:.```            
               ```:ymNy:.----.h+-.-..---N-.--...-+h.-----:yNmy:```               
                 ```:ymms:--.-my.-.----+N+-.-....ym..--:smmy:```                 
                   ```:ymmy/-:Nm.-.-...sNs-.---..mN:-/ymmy:```                   
                     ```-smNhyNN/---...hNh..---./NNyhNms:```                     
                       ```-odNNNs-.-.-.mNm..----sNNNmo-```                       
                         ```.+dNms:-..:NNN:.--:smNd+.```                         
                            ``./hmNy/-+NNN+-/yNmh/.``                            
                              ```:smNdhNNNhdNms:```                              
                                ```.+dNNNNNd+.```                                
                                   ``./ymy/```                                   
                                     ```.```                                     
                                       ```                                       ";
                    Console.WriteLine(dessinGuerrier);
                    break;
                    #endregion
            }
        }

        public void Attaquer()
        {
        }

        public void PrendrePotion()
        {
        }

        public void Deplacement(char s)
        {
            switch (s)
            {
                case 'z':
                    Console.SetCursorPosition(Console.CursorLeft, (Console.CursorTop-1));
                    break;
                case 's':
                    Console.SetCursorPosition(Console.CursorLeft, (Console.CursorTop + 1));
                    break;
                case 'q':
                    Console.SetCursorPosition((Console.CursorLeft - 1),Console.CursorTop);
                    break;
                case 'd':
                    Console.SetCursorPosition((Console.CursorLeft + 1),Console.CursorTop);
                    break;
            }
        }

        private int GetBonus(Stats nomCarac)
        {
            int bonus = 0;
            foreach (Item item in _ListeItem)
            {
                if (item.NomStat == nomCarac)
                {
                    bonus += item.Bonus;
                }
            }

            return bonus;
        }

    }
}
