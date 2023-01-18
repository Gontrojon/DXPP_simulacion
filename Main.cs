using System;
using System.Collections.Generic;

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

public class MainProgram {

    // Creacion das listas
    private static List<Unidade> equipoRoxo;
    private static List<Unidade> equipoAzul;

    static void Main(string[] args) {
        // inicializacion das listas
        equipoRoxo = new List<Unidade>();
        equipoAzul = new List<Unidade>();

        // Añadese a cada equipo as seguintes unidades: 2 Aldeans 0 de ataque, 1 Gerreiro 10 de ataque, 1 Arqueiro 5 de ataque.

        equipoRoxo.Add(new Aldean(0));
        equipoRoxo.Add(new Aldean(0));
        equipoRoxo.Add(new Guerreiro(10));
        equipoRoxo.Add(new Arqueiro(5));

        equipoAzul.Add(new Aldean(0));
        equipoAzul.Add(new Aldean(0));
        equipoAzul.Add(new Guerreiro(10));
        equipoAzul.Add(new Arqueiro(5));

        // Una vez implementado o bucle de xogo esta liña mostrara a info das unidades
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
        return $"Quédanme {vida} puntos de vida";
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
