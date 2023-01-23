/*
 * Author : Jonatan Gonzalez Troyano
 * 
 * Fecha : 17/01/2023
 * 
 * Email : jonatan.zakarot@gmail.com
 * 
 * Github user : Gontrojon
 * 
 * */

using System;
using System.Collections.Generic;

public class MainProgram
{



    static void Main(string[] args)
    {
        // Creacion das listas
        List<Unidade> equipoVermello = new List<Unidade>();
        List<Unidade> equipoAzul = new List<Unidade>();

        Random rand = new Random();

        // Incluense a cada equipo as seguintes unidades: 2 Aldeans 0 de ataque, 1 Gerreiro 10 de ataque, 1 Arqueiro 5 de ataque.

        equipoVermello.Add(new Aldean(0));
        equipoVermello.Add(new Aldean(0));
        equipoVermello.Add(new Guerreiro(10));
        equipoVermello.Add(new Arqueiro(5));

        equipoAzul.Add(new Aldean(0));
        equipoAzul.Add(new Aldean(0));
        equipoAzul.Add(new Guerreiro(10));
        equipoAzul.Add(new Arqueiro(5));

        // variable temporal para a condicion de victoria.
        bool victoria = false;

        // variables para saber quen ataca e quen defende
        int atacante, defensor;

        // varibale que controla os turnos: true = vermello, false = azul. Considerase que sempre empezan os vermellos polo momento
        int turno = rand.Next(2);

        // variable que controla que o defensor asignado estea vivo
        bool defensorvivo = false;

        // variable que controla o numero de mortos de cada equipo para asignar unha victoria
        int mortosEquipoVermello = 0, mortosEquipoAzul = 0;


        do
        {

            if (turno == 0)
            {

                // asignacion aleatoria do membro que vai atacar
                atacante = rand.Next(0, equipoVermello.Count);
                //asignacion aleatoria do membro que vai defender
                defensor = rand.Next(0, equipoAzul.Count);

                // calculo de dano unicamiente se o atacante ten vida
                if (equipoVermello[atacante].Vida > 0)
                {
                    // Ataca o equipo Vermello
                    Console.Write("Ataca o equipo vermello \n");

                    //bucle que controla que o defensor esta vivo para poder defender
                    while (!defensorvivo)
                    {
                        // comprobacion de que el defensor estea vivo
                        if (equipoAzul[defensor].Vida > 0)
                        {
                            // se xa hai un defensor vivo saimos do bucle
                            defensorvivo = true;
                        }
                        else
                        {
                            //se asigna un novo defensor aleatorio
                            defensor = rand.Next(0, equipoVermello.Count);
                        }
                    }
                    // ponse a variable outra vez na posicion de que non hay defensor para a seguinte volta
                    defensorvivo = false;

                    // Calculo do dano
                    equipoAzul[defensor].Vida -= equipoVermello[atacante].Ataque;

                    // saida por consola do que ataca
                    Console.Write(equipoVermello[atacante].Info() + "\n");
                    // saida por consola do que recive dano
                    Console.Write(equipoAzul[defensor].Info() + "\n");
                }

            }
            else
            {

                // asignacion aleatoria do membro que vai atacar
                atacante = rand.Next(0, equipoAzul.Count);
                //asignacion aleatoria do membro que vai defender
                defensor = rand.Next(0, equipoVermello.Count);

                // calculo de dano unicamiente se o atacante ten vida
                if (equipoAzul[atacante].Vida > 0)
                {
                    // Atacara o equipo Azul
                    Console.Write("Ataca o equipo Azul \n");

                    //bucle que controla que o defensor esta vivo para poder defender
                    while (!defensorvivo)
                    {
                        // comprobacion de que el defensor estea vivo
                        if (equipoVermello[defensor].Vida > 0)
                        {
                            // se xa hai un defensor vivo saimos do bucle
                            defensorvivo = true;
                        }
                        else
                        {
                            //se asigna un novo defensor aleatorio
                            defensor = rand.Next(0, equipoVermello.Count);
                        }
                    }
                    // ponse a variable outra vez na posicion de que non hay defensor para a seguinte volta
                    defensorvivo = false;

                    // Calculo do dano
                    equipoVermello[defensor].Vida -= equipoAzul[atacante].Ataque;

                    // saida por consola do que ataca
                    Console.Write(equipoAzul[atacante].Info() + "\n");
                    // saida por consola do que recive dano
                    Console.Write(equipoVermello[defensor].Info() + "\n");
                }
            }

            // Asignase un novo turno
            turno = rand.Next(2);

            // se contavilizan os mortos do equipo vermello
            foreach (Unidade u in equipoVermello)
            {
                // comprobacion de que a unidade esta morta
                if (u.Vida <= 0)
                {
                    // sumase 1
                    mortosEquipoVermello++;
                }
            }


            // se contavilizan os mortos do equipo azul
            foreach (Unidade u in equipoAzul)
            {
                // comprobacion de que a unidade esta morta
                if (u.Vida <= 0)
                {
                    // sumase 1
                    mortosEquipoAzul++;
                }
            }

            // se non quedan membros vivos na lista do equipo se acaba o xogo
            if (mortosEquipoVermello == equipoVermello.Count || mortosEquipoAzul == equipoAzul.Count)
            {
                // Xa hai gañador saimos do bucle de xogo
                victoria = true;
            }
            else
            {
                // reset da conta de mortos para a seguinte volta
                mortosEquipoAzul = 0;
                mortosEquipoVermello = 0;
            }

        } while (!victoria);

        // comprobacion de que equipo e ganador
        if (mortosEquipoAzul == 4)
        {
            // mensaxe de que o equipo vermello e o ganador
            Console.Write("O equipo Vermello e o ganador" + "\n");
        }
        else
        {
            // mensaxe de que o equipo azul e o ganador
            Console.Write("O equipo Azul e o ganador" + "\n");
        }
    }
}

public abstract class Unidade
{

    protected int vida = 20;
    protected int ataque;
    public int Vida
    {
        get { return vida; }
        set { vida = value; }
    }
    public int Ataque
    {
        get { return ataque; }
    }

    public Unidade(int ataque)
    {
        this.ataque = ataque;
    }

    public virtual string Info()
    {
        return $"Quedanme {vida} puntos de vida";
    }
}

public class Aldean : Unidade
{

    public Aldean(int ataque) : base(ataque) { }

    public override string Info()
    {
        return "Son un aldean. Non fago dano. " + base.Info();
    }

}

public class Guerreiro : Unidade
{

    public Guerreiro(int ataque) : base(ataque) { }

    public override string Info()
    {
        return $"Son un guerreiro. Fago {ataque} puntos de dano. " + base.Info();
    }

}

public class Arqueiro : Unidade
{

    public Arqueiro(int ataque) : base(ataque) { }

    public override string Info()
    {
        return $"Son un arqueiro. Fago {ataque} puntos de dano. " + base.Info();
    }

}
