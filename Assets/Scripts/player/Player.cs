using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public int mana;
    public int energy;
    public int xp;
    public int level;

    private int attack;
    private int agility;
    private int defense;
    private int endurance;
    private int intelect;
    private int magic;
    void Start()
    {
        //Variaveis de estado do player
        health = 100;
        mana = 100;
        energy = 100;
        xp = 0;
        level = 1;
        //Variaveis de atributos do player
        attack = 0;
        agility = 0;
        defense = 0;
        endurance = 0;
        intelect = 0;
        magic = 0;
    }
}
