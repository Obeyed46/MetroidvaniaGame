using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreatePlayer : MonoBehaviour {

    public static CreatePlayer Instance;
    private BasePlayerClass NewPlayer;
    private string playerName;
    public EquipmentPanel equipPanel;

    public Text HealthText, StaminaText, ManaText, StrenghText, SkillText, KnowledgeText;
    public Text[] Texts1;
    public Text[] Texts2;
    public Text[] Texts3;
    public Text CurrentHealthText, CurrentStaminaText, CurrentManaText;
    public Transform StatsText1, StatsText2;

    public int StatsPoints = 0;
    public Text StatsPointsText, PlayerLevelText;

    public int HealthPoints, StaminaPoints, ManaPoints, Weapon1Dam, Weapon2Dam, Weight, PhysicDEF, FireDEF, EletricDEF, PoisonDEF, Awarness, Persuasion;
    public int WhatEquip;


    //public Item item;

    private void OnValidate()
    {
        Texts1 = StatsText1.GetComponentsInChildren<Text>();
        Texts2 = StatsText2.GetComponentsInChildren<Text>();
    }

    // Use this for initialization
    void Start () {

        NewPlayer = new BasePlayerClass();
        SetKnigthStartingClass();
        UpdateUI();
        DontDestroyOnLoad(this);
       
        

    }

    private void Awake()
    {
        Instance = this;
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 2)
        {
            WhatEquip = 0;
        }
    }



    //Called every frame
    void Update()
    {


        

    }

    public void CreateNewPlayer()
    {
        NewPlayer.PlayerLevel = 1;
        NewPlayer.PlayerName = playerName;

        Character.PlayerLevel = NewPlayer.PlayerLevel;
        Character.PlayerName = NewPlayer.PlayerName;
        Character.PlayerClass = NewPlayer.PlayerClass;

        Character.Health = NewPlayer.Health;
        Character.Stamina = NewPlayer.Stamina;
        Character.Mana = NewPlayer.Mana;
        Character.Strength = NewPlayer.Strenght;
        Character.Skill = NewPlayer.Skill;
        Character.Knowledge = NewPlayer.Knowledge;

    }
	
	public void SetKnigthStartingClass()
    {
        StatsPoints = 0;
        NewPlayer.PlayerClass = new KnightStartingClass();
        NewPlayer.Health = NewPlayer.PlayerClass.Health;
        NewPlayer.Stamina = NewPlayer.PlayerClass.Stamina;
        NewPlayer.Mana = NewPlayer.PlayerClass.Mana;
        NewPlayer.Strenght = NewPlayer.PlayerClass.Strenght;
        NewPlayer.Skill = NewPlayer.PlayerClass.Skill;
        NewPlayer.Knowledge = NewPlayer.PlayerClass.Knowledge;
        NewPlayer.PlayerLevel = 1;
        InventoryManager.Instance.SetKnightItems();
        UpdateUI();
       
    }

    public void SetNomadPirateStartingClass()
    {
        StatsPoints = 0;
        NewPlayer.PlayerClass = new NomadPirateStatingClass();
        NewPlayer.Health = NewPlayer.PlayerClass.Health;
        NewPlayer.Stamina = NewPlayer.PlayerClass.Stamina;
        NewPlayer.Mana = NewPlayer.PlayerClass.Mana;
        NewPlayer.Strenght = NewPlayer.PlayerClass.Strenght;
        NewPlayer.Skill = NewPlayer.PlayerClass.Skill;
        NewPlayer.Knowledge = NewPlayer.PlayerClass.Knowledge;
        NewPlayer.PlayerLevel = 1;
        UpdateUI();
        

    }

    public void SetSicarioStartingClass()
    {
        StatsPoints = 0;
        NewPlayer.PlayerClass = new SicarioStartingClass();
        NewPlayer.Health = NewPlayer.PlayerClass.Health;
        NewPlayer.Stamina = NewPlayer.PlayerClass.Stamina;
        NewPlayer.Mana = NewPlayer.PlayerClass.Mana;
        NewPlayer.Strenght = NewPlayer.PlayerClass.Strenght;
        NewPlayer.Skill = NewPlayer.PlayerClass.Skill;
        NewPlayer.Knowledge = NewPlayer.PlayerClass.Knowledge;
        NewPlayer.PlayerLevel = 1;
        UpdateUI();
        


    }

    public void SetSorcererStartingClass()
    {
        StatsPoints = 0;
        NewPlayer.PlayerClass = new SorcererStartingClass();
        NewPlayer.Health = NewPlayer.PlayerClass.Health;
        NewPlayer.Stamina = NewPlayer.PlayerClass.Stamina;
        NewPlayer.Mana = NewPlayer.PlayerClass.Mana;
        NewPlayer.Strenght = NewPlayer.PlayerClass.Strenght;
        NewPlayer.Skill = NewPlayer.PlayerClass.Skill;
        NewPlayer.Knowledge = NewPlayer.PlayerClass.Knowledge;
        NewPlayer.PlayerLevel = 1;
        UpdateUI();
        

    }

    public void SetLegionaryStartingClass()
    {
        StatsPoints = 0;
        NewPlayer.PlayerClass = new LegionaryStartingClass();
        NewPlayer.Health = NewPlayer.PlayerClass.Health;
        NewPlayer.Stamina = NewPlayer.PlayerClass.Stamina;
        NewPlayer.Mana = NewPlayer.PlayerClass.Mana;
        NewPlayer.Strenght = NewPlayer.PlayerClass.Strenght;
        NewPlayer.Skill = NewPlayer.PlayerClass.Skill;
        NewPlayer.Knowledge = NewPlayer.PlayerClass.Knowledge;
        NewPlayer.PlayerLevel = 1;
        UpdateUI();
        


    }

    

    public void UpdateUI()
    {
        HealthText.text = NewPlayer.Health.ToString();
        StaminaText.text = NewPlayer.Stamina.ToString();
        ManaText.text = NewPlayer.Mana.ToString();
        StrenghText.text = NewPlayer.Strenght.ToString();
        SkillText.text = NewPlayer.Skill.ToString();
        KnowledgeText.text = NewPlayer.Knowledge.ToString();
        StatsPointsText.text = StatsPoints.ToString();
        PlayerLevelText.text = NewPlayer.PlayerLevel.ToString();

        Texts1[0].text = NewPlayer.Health.ToString();
        Texts1[1].text = NewPlayer.Stamina.ToString();
        Texts1[2].text = NewPlayer.Mana.ToString();
        Texts1[3].text = NewPlayer.Strenght.ToString();
        Texts1[4].text = NewPlayer.Skill.ToString();
        Texts1[5].text = NewPlayer.Knowledge.ToString();

        Texts2[0].text = NewPlayer.Health.ToString();
        Texts2[1].text = NewPlayer.Stamina.ToString();
        Texts2[2].text = NewPlayer.Mana.ToString();
        Texts2[3].text = NewPlayer.Strenght.ToString();
        Texts2[4].text = NewPlayer.Skill.ToString();
        Texts2[5].text = NewPlayer.Knowledge.ToString();

        Texts3[0].text = HealthPoints.ToString();
        Texts3[1].text = StaminaPoints.ToString();
        Texts3[2].text = ManaPoints.ToString();
        Texts3[3].text = Weapon1Dam.ToString();
        Texts3[4].text = Weapon2Dam.ToString();
        Texts3[5].text = Weight.ToString();
        Texts3[6].text = PhysicDEF.ToString();
        Texts3[7].text = FireDEF.ToString();
        Texts3[8].text = EletricDEF.ToString();
        Texts3[9].text = PoisonDEF.ToString();
        Texts3[10].text = Awarness.ToString();
        Texts3[11].text = Persuasion.ToString();


    }

    public void SetValues()
    {

        HealthPoints = 64 * NewPlayer.Health;
        StaminaPoints = 52 * NewPlayer.Stamina;
        ManaPoints = 32 * NewPlayer.Mana;
        Awarness = 8 * NewPlayer.Knowledge + 2 * NewPlayer.Strenght;
        Persuasion = 10 * NewPlayer.Knowledge + 2 * NewPlayer.Skill;

    }

    public void SetHandDamage()
    {
        Weapon1Dam = 2 * NewPlayer.Strenght;
    }

    public void SetHealth(int AviablePoints)
    {
        if (NewPlayer.PlayerClass != null)
        {
            if (AviablePoints > 0 && StatsPoints > 0)
            {
                NewPlayer.Health += AviablePoints;
                StatsPoints -= 1;
                UpdateUI();

            }else if(AviablePoints < 0 && NewPlayer.Health < NewPlayer.PlayerClass.Health)
            {
                NewPlayer.Health += AviablePoints;
                StatsPoints += 1;
                UpdateUI();

            }

        }else
        {
            Debug.Log("Class has not been chosen");
        }

    }

    public void SetStamina(int AviablePoints)
    {
        if (NewPlayer.PlayerClass != null)
        {
            if (AviablePoints > 0 && StatsPoints > 0)
            {
                NewPlayer.Stamina += AviablePoints;
                StatsPoints -= 1;
                UpdateUI();

            }
            else if (AviablePoints < 0 && NewPlayer.Stamina < NewPlayer.PlayerClass.Stamina)
            {
                NewPlayer.Stamina += AviablePoints;
                StatsPoints += 1;
                UpdateUI();

            }

        }
        else
        {
            Debug.Log("Class has not been chosen");
        }

    }

    public void SetMana(int AviablePoints)
    {
        if (NewPlayer.PlayerClass != null)
        {
            if (AviablePoints > 0 && StatsPoints > 0)
            {
                NewPlayer.Mana += AviablePoints;
                StatsPoints -= 1;
                UpdateUI();

            }
            else if (AviablePoints < 0 && NewPlayer.Mana < NewPlayer.PlayerClass.Mana)
            {
                NewPlayer.Mana += AviablePoints;
                StatsPoints += 1;
                UpdateUI();

            }

        }
        else
        {
            Debug.Log("Class has not been chosen");
        }

    }

    public void SetStrenght(int AviablePoints)
    {
        if (NewPlayer.PlayerClass != null)
        {
            if (AviablePoints > 0 && StatsPoints > 0)
            {
                NewPlayer.Strenght += AviablePoints;
                StatsPoints -= 1;
                UpdateUI();

            }
            else if (AviablePoints < 0 && NewPlayer.Strenght < NewPlayer.PlayerClass.Strenght)
            {
                NewPlayer.Strenght += AviablePoints;
                StatsPoints += 1;
                UpdateUI();

            }

        }
        else
        {
            Debug.Log("Class has not been chosen");
        }

    }

    public void SetSkill(int AviablePoints)
    {
        if (NewPlayer.PlayerClass != null)
        {
            if (AviablePoints > 0 && StatsPoints > 0)
            {
                NewPlayer.Skill += AviablePoints;
                StatsPoints -= 1;
                UpdateUI();

            }else if(AviablePoints < 0 && NewPlayer.Skill < NewPlayer.PlayerClass.Skill)
            {
                NewPlayer.Skill += AviablePoints;
                StatsPoints += 1;
                UpdateUI();

            }

        }else
        {
            Debug.Log("Class has not been chosen");
        }

    }

    public void SetKnowledge(int AviablePoints)
    {
        if (NewPlayer.PlayerClass != null)
        {
            if (AviablePoints > 0 && StatsPoints > 0)
            {
                NewPlayer.Knowledge += AviablePoints;
                StatsPoints -= 1;
                UpdateUI();

            }
            else if (AviablePoints < 0 && NewPlayer.Knowledge < NewPlayer.PlayerClass.Knowledge)
            {
                NewPlayer.Knowledge += AviablePoints;
                StatsPoints += 1;
                UpdateUI();

            }

        }
        else
        {
            Debug.Log("Class has not been chosen");
        }

    }

}
