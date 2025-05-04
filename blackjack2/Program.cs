using System;

class Program{
    static void Main()
    {   
        string[]Bmesa = ["A","2","3","4","5","6","7","8","9","10","J","Q","K"];
        System.Console.WriteLine("Bem vindo ao BlackJack!");
        System.Console.WriteLine("Você jogará contra a máquina!");
        System.Console.WriteLine("Suas primeiras cartas são: ");
        Random r = new Random();
        int carta1 = r.Next(0,12);
        int carta2 = r.Next(0,12);
        if(Bmesa[carta1] != "0"){
            if(Bmesa[carta2] != "0"){
                System.Console.WriteLine($"Primeira carta: {Bmesa[carta1]}, Segunda carta: {Bmesa[carta2]}");
            }
            Bmesa[carta1] = "0";
            Bmesa[carta2] = "0";
        }
        System.Console.WriteLine("Deseja mais uma carta? (s/n)");
        string continuar = Console.ReadLine();
        while(continuar == "s"){
            Random ra = new Random();
            int carta3 = ra.Next(0,12);

            if(Bmesa[carta3] != "0"){
                if((carta1 + carta2 + carta3) > 21){
                    Console.WriteLine("Você perdeu!");
                    break;
                }
                else if((carta1 + carta1 + carta3) == 21){
                    Console.WriteLine("Você ganhou!");
                    break;
                }
                else{

                    System.Console.WriteLine($"Primeira carta: {Bmesa[carta1]}, Segunda carta: {Bmesa[carta2]}, Terceira carta: {Bmesa[carta3]}");
                    System.Console.WriteLine("Deseja mais uma carta? (s/n)");
                    continuar = Console.ReadLine();
                }
            }
        }
    }
}