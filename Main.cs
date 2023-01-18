using System;

public class MainProgram {

    static void Main(string[] args) {
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

public class Guerriero : Unidade {

    public Guerriero(int ataque) : base(ataque) { }

}

public class Arqueiro : Unidade {

    public Arqueiro(int ataque) : base(ataque) { }

}
