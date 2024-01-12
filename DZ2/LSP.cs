using System;
class Program {
  public class AutoSMotorom {
      public virtual void UpaliAuto(){
          Console.WriteLine("Auto upaljen");
      }
  }
  
  public class AutoBezMotora : AutoSMotorom {
      public override void UpaliAuto() {
          Console.WriteLine("Auto se ne moze upaliti");
      }
  }
  
  static void Main() {
      AutoBezMotora auto = new AutoBezMotora();
      auto.UpaliAuto();
  }
}

//Ovdje klasa AutpBezMotora nasljeđuje klasu AutoSMotorom, ali zamjena AutoSMotorom objektom s AutoBezMotora objektom rezultira neocekivano ponasanje
//Problem je sto podklasa AutoBezMotora mijenja ponasanje naslijeđene metode UpaliAuto iznad onoga sto se ocekuje od njene nadklase
//To krsi LSP jer podklasa ne moze biti potpuno zamjenjiva za svoju nadklasu bez narusavanja ispravnosti programa
