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

public class MainProgram {



    static void Main(string[] args) {
        // Creacion das listas
        List<Unidade> equipoVermello = new List<Unidade>();
        List<Unidade> equipoAzul  = new List<Unidade>();

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
        bool vitoria = false;

        // variables para saber quen ataca e quen defende
        int atacante, defensor;

        // varibale que controla os turnos: true = vermello, false = azul. Considerase que sempre empezan os vermellos polo momento
        int  turno = rand.Next(0,2);


        do {

            if (turno == 0) { 
            

                turno = rand.Next(0, 2);
            }
            else
            {
                // Atacara o equipo Azul

                turno = rand.Next(0, 2);
            }


            if (equipoAzul.Count == 0 || equipoVermello.Count == 0) {
                vitoria = true;
            }

            // temporalmente cerramos o bucle na primeria execucion
            vitoria = true;
            
        } while (!vitoria);





        // Una vez implementado o bucle de xogo esta li�a mostrara a info das unidades
        Console.Write("Ola mundo!");
    }
}

public abstract class Unidade {

    protected int vida = 20;
    protected int ataque;
    public int Vida { get; set; }

    public Unidade (int ataque) {
        this.ataque = ataque;
    }

    public virtual string Info() {
        return $"Qu�danme {vida} puntos de vida";
    }
}

public class Aldean : Unidade {

    public Aldean(int ataque) : base(ataque) { }

}

public class Guerreiro : Unidade {

    public Guerreiro(int ataque) : base(ataque) { }

}

public class Arqueiro : Unidade {

    public Arqueiro(int ataque) : base(ataque) { }

}
