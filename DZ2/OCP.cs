using System;
using namespace OCP {
    public class Orao {
        public string BrzinaLetenja { get; set; }
    }
    
    public class BrzinaKretanja {
        public void IspisiBrzinuLetenja(Orao orao) {
            Console.WriteLine($"Brzina letenja orla je: {orao.BrzinaLetenja}");
        }
    }
}
//Narusava OCP jer clasa BrzinaKretanja ispisuje samo brzinu letenja orla, a ne bi radilo sa npr. brzinom trcanja psa ili macke ili nesta slicno. 
//Bolje bi po OCP-u bilo da imamo apstrakciju zivotinja sa metodom brzina kretanja koju nasljeđuje svaka zivotinja. 

