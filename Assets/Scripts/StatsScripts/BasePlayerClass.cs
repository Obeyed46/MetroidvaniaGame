using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerClass
{

    private string playerName;
    private int playerLevel;
    private BaseClass playerClass;

    private int health, stamina, mana, strenght, skill, knowledge;


    public string PlayerName
    {
        get { return playerName; }
        set { playerName = value; }

    }

    public int PlayerLevel
    {
        get { return playerLevel; }
        set { playerLevel = value; }

    }

    public BaseClass PlayerClass
    {
        get { return playerClass; }
        set { playerClass = value; }

    }

    public int Health
    {
        get { return health; }
        set { health = value; }

    }

    public int Stamina
    {
        get { return stamina; }
        set { stamina = value; }

    }

    public int Mana
    {
        get { return mana; }
        set { mana = value; }

    }


    public int Strenght
    {
        get { return strenght; }
        set { strenght = value; }

    }

    public int Skill
    {
        get { return skill; }
        set { skill = value; }

    }

    public int Knowledge
    {
        get { return knowledge; }
        set { knowledge = value; }

    }

}
