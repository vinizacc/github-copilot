using System;
using System.ComponentModel.Design.Serialization;
using System.Formats.Asn1;

class Program
{
    static void Main()
    {
        string[] bMesa = iniciaBaralho();
        string[] bExibicao = iniciaBaralho();
        List<int> maoJogador = new List<int>();
        List<int> maoMesa = new List<int>();
        List<List<int>> maosNoJogo = new List<List<int>>{maoJogador, maoMesa};
        int rodada = 1;
        bool rodadaAtiva = true;
        bool jogoAtivo = true;

        //Começo de jogo

        Console.WriteLine("\nBem vindo ao jogo de Blackjack!");
        Console.WriteLine("\nInicio de jogo");
        Console.WriteLine("Deseja jogar? (s/n)");
        string jogar = Console.ReadLine() ?? string.Empty;


        if (jogar == "n")
        {
            jogoAtivo = false;
            rodadaAtiva = false;
        }

        do
        {
            while (rodadaAtiva)
            {
                Console.WriteLine($"Rodada :{rodada}");

                //Gera primeira carta do jogador e mesa
                int c = geradorDeCartas(bMesa);
                int cM = geradorDeCartas(bMesa);
                maoJogador.Add(c);
                maoMesa.Add(cM);
                bMesa = tiraCartaDaMesa(bMesa, c);
                bMesa = tiraCartaDaMesa(bMesa, cM);

                //Gera a segunda carta do jogador e mesa 
                c = geradorDeCartas(bMesa);
                cM = geradorDeCartas(bMesa);
                maoJogador.Add(c);
                maoMesa.Add(cM);
                bMesa = tiraCartaDaMesa(bMesa, c);
                bMesa = tiraCartaDaMesa(bMesa, cM);

                exibeMaoJogador(bExibicao, maoJogador);
                exibeMaoMesa(bExibicao, maoMesa);
                
                maosNoJogo.Add(maoJogador);
                maosNoJogo.Add(maoMesa);
                Console.Clear();
                Console.WriteLine("Maos no jogo 1: " + maosNoJogo[0][0]);
                Console.WriteLine("Maos no jogo 1: " + maosNoJogo[0][1]);
                Console.WriteLine("Maos no jogo 2: " + maosNoJogo[1][0]);
                Console.WriteLine("Maos no jogo 2: " + maosNoJogo[1][1]);

                Console.WriteLine("Quer carta? (s/n)111");
                string continuar = Console.ReadLine() ?? string.Empty;


                //Faça enquanto jogador querer parar
                while (continuar == "s")
                {
                    int estadoJ = verificarEstadoJogo(somaCartas(maoJogador));

                    if(comparaETraduzEstadoJogo(estadoJ) == "")
                    {
                        c = geradorDeCartas(bMesa);
                        cM = geradorDeCartas(bMesa);
                        maoJogador.Add(c);
                        maoMesa.Add(cM);
                        bMesa = tiraCartaDaMesa(bMesa, c);
                        bMesa = tiraCartaDaMesa(bMesa, cM);

                        exibeMaoJogador(bExibicao, maoJogador);
                        exibeMaoMesa(bExibicao, maoMesa);
                    }
                    else{
                        Console.WriteLine();
                    }

                    Console.WriteLine("Quer carta? (s/n)222");
                    continuar = Console.ReadLine() ?? string.Empty;

                    //Perguntar se jogador quer carta
                    //Verificar se a mão dele e ver se a mesa quer carta
                    //Vericar quem está ganhando

                }

                Console.WriteLine("\n--------------------------");
            }

            if (jogar != "n")
            {
                Console.WriteLine("Deseja jogar novamente? (s/n)");
                string jogarMaisUma = Console.ReadLine() ?? string.Empty;
                if (jogarMaisUma == "s")
                {
                    //Reinicia as variaveis
                    rodadaAtiva = true;
                    rodada++;
                    maoJogador.Clear();
                    maoMesa.Clear();
                    bMesa = iniciaBaralho();
                }
                else
                {
                    jogoAtivo = false;
                }
            }
        } while (jogoAtivo);





    }

    //Certo
    public static int gerarNumeroAleatorio(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max + 1);
    }

    //Certo
    public static void exibeBaralho(string[] baralhoMesa)
    {
        for (int i = 0; i < 13; i++)
        {
            Console.Write($"[{baralhoMesa[i]}] ");
            Console.WriteLine("\n");
        }
    }

    //Certo
    public static string[] iniciaBaralho()
    {
        string[] baralho = new string[13];

        for (int i = 0; i < 13; i++)
        {
            switch (i)
            {
                case 0: baralho[i] = "ÀS"; break;
                case 1: baralho[i] = "2"; break;
                case 2: baralho[i] = "3"; break;
                case 3: baralho[i] = "4"; break;
                case 4: baralho[i] = "5"; break;
                case 5: baralho[i] = "6"; break;
                case 6: baralho[i] = "7"; break;
                case 7: baralho[i] = "8"; break;
                case 8: baralho[i] = "9"; break;
                case 9: baralho[i] = "10"; break;
                case 10: baralho[i] = "J"; break;
                case 11: baralho[i] = "Q"; break;
                case 12: baralho[i] = "K"; break;
            }
        }

        return baralho;
    }

    //Certo
    public static string[] tiraCartaDaMesa(string[] baralhoMesa, int carta)
    {
        if (baralhoMesa[carta - 1] != "0" && carta - 1 >= 0)
        {
            baralhoMesa[carta - 1] = "0";
        }
        return baralhoMesa;
    }

    //Certo
    public static int geradorDeCartas(string[] baralhoMesa)
    {
        int carta;
        bool cartaValida;
        do
        {
            carta = gerarNumeroAleatorio(1, 13);

            if (baralhoMesa[carta - 1] == "0")
            {
                cartaValida = false;
            }
            else
            {
                cartaValida = true;
            }

        } while (cartaValida == false);

        return carta;
    }

    //Certo
    public static void exibeMaoJogador(string[] bExibicao, List<int> mao)
    {
        string conct = "Jogador: ";
        foreach (var item in mao)
        {
            conct += bExibicao[item - 1] + ", ";
        }

        //Remove a última vírgula e espaço
        if (!string.IsNullOrEmpty(conct))
        {
            conct = conct.Remove(conct.Length - 2);
            Console.WriteLine(conct);
        }
        else
        {
            Console.WriteLine("Mão vazia");
        }
    }

    //Certo
    public static void exibeMaoMesa(string[] bExibicao, List<int> mao)
    {
        string conct = "Mesa: ";
        foreach (var item in mao)
        {
            conct += bExibicao[item - 1] + ", ";
        }

        //Remove a última vírgula e espaço
        if (!string.IsNullOrEmpty(conct))
        {
            conct = conct.Remove(conct.Length - 2);
            Console.WriteLine(conct);
        }
        else
        {
            Console.WriteLine("Mão vazia");
        }
    }

    //Certo
    public static int somaCartas(List<int> mao)
    {
        int somatoria = 0;
        foreach (int item in mao)
        {
            int valor = (item == 11 || item == 12 || item == 13) ? 10 : item;
            somatoria += valor;
        }

        return somatoria;
    }

    //Certo
    public static int exibiSomaCartas(int somatoria)
    {
        Console.WriteLine($"Total: {somatoria}");
        return somatoria;
    }

    public static string estatusJogo(List<int> mJ, List<int> mM)
    {
        if ((somaCartas(mJ) <= 20 && somaCartas(mJ) >= 18) || (somaCartas(mM) <= 19 && somaCartas(mM) >= 16))
        {
            return "mesa-parou";
        }
        else if (somaCartas(mJ) > somaCartas(mM))
        {
            return "jogador-vantagem";
        }
        else if (somaCartas(mJ) < somaCartas(mM))
        {
            return "mesa-vantagem";
        }
        else if (somaCartas(mJ) == 21)
        {
            return "jG";
        }
        else if (somaCartas(mM) == 21)
        {
            return "mG";
        }
        else if(somaCartas(mJ) > 21)
        {
            return "jogador-estourou";
        }
        else if(somaCartas(mM) > 21)
        {
            return "mesa-estourou";
        }
        return "";
    }

    public static int verificarEstadoJogo(int somaMao)
    {
        int estado;

        int determinarEstado(int mao)
        {
            if (mao > 21) return -1; // Estourou
            if (mao == 21) return 0;  // Fez 21, não joga mais
            return 1;  // Ainda pode jogar
        }

        estado = determinarEstado(somaMao);

        return estado;
    }

    public static string comparaETraduzEstadoJogo(int estado)
    {
        //Volta string mostrando texto atual

        if(estado == 0){
            //Jogador ganhou
            return "ganhou!";
        }
        else if(estado == 1){
            //Jogador pode jogar
            return "";
        }
        else if(estado == -1){
            //Jogador estourou
            return "perdeu!";
        }

        return "excessao";
    }
}
