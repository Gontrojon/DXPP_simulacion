/*
 * Author : Jonatan Gonzalez Troyano, Luis Pena
 * 
 * Fecha : 17/01/2023
 * 
 * Email : jonatan.zakarot@gmail.com, 3lr3n4ci0@gmail.com
 * 
 * Github user : Gontrojon, desvidrealuis
 * 
 * */

using System;
using System.Collections.Generic;

public class MainProgram {

    // creacion da variable para asignar randoms
    static Random rand = new Random();
    static void Main(string[] args) {
        // Creacion das listas
        List<Unidade> equipoVermello = new List<Unidade>();
        List<Unidade> equipoAzul = new List<Unidade>();

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

        // variable que controla o numero de mortos de cada equipo para asignar unha victoria
        int mortosEquipoVermello = 0, mortosEquipoAzul = 0;

        // varibale que controla os turnos: true = vermello, false = azul. Considerase que sempre empezan os vermellos polo momento
        int turno = rand.Next(2);

        // bucle de xogo
        do {
            // comprobacion de turnos
            if (turno == 0) {
                // Ataca o equipo Vermello
                Console.Write("Ataca o equipo vermello \n");
                // Chamada o metodo que fai o combate pasando como primeiro parametro o atacante e como segundo o defensor
                // a maiores este metodo devolve true se morreu o defensor
                if (Combate(equipoVermello, equipoAzul)) {
                    // sumase un o contador de mortos do equipo contrario
                    mortosEquipoAzul++;
                }
            }
            else {
                // Atacara o equipo Azul
                Console.Write("Ataca o equipo Azul \n");
                // Chamada o metodo que fai o combate pasando como primeiro parametro o atacante e como segundo o defensor
                // a maiores este metodo devolve true se morreu o defensor
                if (Combate(equipoAzul, equipoVermello)) {
                    // sumase un o contador de mortos do equipo contrario
                    mortosEquipoVermello++;
                }  
            }
            // Asignase un novo turno
            turno = rand.Next(2);
            
            // se non quedan membros vivos na lista do equipo se acaba o xogo
            if (mortosEquipoVermello == equipoVermello.Count || mortosEquipoAzul == equipoAzul.Count) {
                // Xa hai ganhador saimos do bucle de xogo
                victoria = true;
            }
        } while (!victoria);

        // comprobacion de que equipo e ganador
        if (mortosEquipoAzul == equipoAzul.Count) {
            // mensaxe de que o equipo vermello e o ganador
            Console.Write("O equipo Vermello e o ganador" + "\n");
        }
        else if (mortosEquipoVermello == equipoVermello.Count) {
            // mensaxe de que o equipo azul e o ganador
            Console.Write("O equipo Azul e o ganador" + "\n");
        }
    }

    public static bool Combate( List<Unidade> ataque, List<Unidade> defensa) {
        // asignacion aleatoria do membro que vai atacar
        int atacante = rand.Next(0, ataque.Count);
        //asignacion aleatoria do membro que vai defender
        int defensor = rand.Next(0, defensa.Count);

        // calculo de dano unicamiente se o atacante ten vida
        if (ataque[atacante].Vida > 0) {
            
            //bucle que controla que o defensor esta vivo para poder defender
            while (!(defensa[defensor].Vida > 0)) {
                //se asigna un novo defensor aleatorio
                defensor = rand.Next(0, ataque.Count);
            }

            // Calculo do dano
            defensa[defensor].Vida -= ataque[atacante].Ataque;

            // saida por consola do que ataca
            Console.Write(ataque[atacante].Info() + "\n");
            // saida por consola do que recive dano
            Console.Write(defensa[defensor].Info() + "\n");

            // se comproba se o defensor morreu para indicalo no return
            if (defensa[defensor].Vida <= 0) {
                // devolvemos true se morreu
                return true;
            } else {
                // devolvemos false se non morreu
                return false;
            }
        }
        else {
            // mensaxe de que non se realizou ataque
            Console.Write("Non se realizou ataque porque o atacante non ten vida \n");

            // como non atacou naide devolvese false, xa que ningen morreu
            return false;
        }
    }
}

public abstract class Unidade {

    protected int vida = 20;
    protected int ataque;
    public int Vida {
        get { return vida; }
        set { vida = value; }
    }
    public int Ataque {
        get { return ataque; }
    }

    public Unidade(int ataque) {
        this.ataque = ataque;
    }

    public virtual string Info() {
        return $"Quedanme {vida} puntos de vida";
    }
}

public class Aldean : Unidade {

    public Aldean(int ataque) : base(ataque) { }

    public override string Info() {
        return "Son un aldean. Non fago dano. " + base.Info();
    }
}

public class Guerreiro : Unidade {

    public Guerreiro(int ataque) : base(ataque) { }

    public override string Info() {
        return $"Son un guerreiro. Fago {ataque} puntos de dano. " + base.Info();
    }
}

public class Arqueiro : Unidade {

    public Arqueiro(int ataque) : base(ataque) { }

    public override string Info() {
        return $"Son un arqueiro. Fago {ataque} puntos de dano. " + base.Info();
    }
}
