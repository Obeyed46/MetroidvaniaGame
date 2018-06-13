using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsSystem : MonoBehaviour {

    public static StatsSystem Instance;

    public Image HealthBarImage, StaminaBarImage, YellowHealthBar;

    public int CurrentHealht, CurrentStamina, CurrentMana;
    public Text CurrentHealthText, CurrentStaminaText, CurrentManaText;
    float StaminaBarLoss, CurrentStamF, MaxStamF;

    //Comes before start
    void Awake()
    {
        
        Instance = this;
     
       
    }

    // Use this for initialization
    void Start () {

        UpdateUI();

	}
	
	// Update is called once per frame
	void Update () {
        
        if (CurrentHealht < 0)
        {
            CurrentHealht = 0;
        }
        if (CurrentStamina < 0)
        {
            CurrentStamina = 0;

        }
        if(CurrentHealht > CreatePlayer.Instance.HealthPoints)
        {
            CurrentHealht = CreatePlayer.Instance.HealthPoints;
            UpdateUI();
        }
        if(CurrentStamina > CreatePlayer.Instance.StaminaPoints)
        {
            CurrentStamina = CreatePlayer.Instance.StaminaPoints;
        }
        CurrentStaminaText.text = CurrentStamina.ToString();
        CurrentStamF = CurrentStamina;
        MaxStamF = CreatePlayer.Instance.StaminaPoints;
        StaminaBarLoss = CurrentStamF / CreatePlayer.Instance.StaminaPoints;
        StaminaBarImage.transform.localScale = new Vector3(StaminaBarLoss, StaminaBarImage.transform.localScale.y, StaminaBarImage.transform.localScale.z);

        if (YellowHealthBar.transform.localScale.x > HealthBarImage.transform.localScale.x)
        {
            YellowHealthBar.transform.localScale = new Vector3(YellowHealthBar.transform.localScale.x - 0.003f, YellowHealthBar.transform.localScale.y, YellowHealthBar.transform.localScale.z);
        }

        if(HealthBarImage.transform.localScale.x <= 0)
        {
            HealthBarImage.transform.localScale = new Vector3(0, HealthBarImage.transform.localScale.y, HealthBarImage.transform.localScale.z);
            YellowHealthBar.transform.localScale = new Vector3(0, YellowHealthBar.transform.localScale.y, YellowHealthBar.transform.localScale.z);
        }

        if (HealthBarImage.transform.localScale.x > 0.987f)
        {
            HealthBarImage.transform.localScale = new Vector3(0.987f, HealthBarImage.transform.localScale.y, HealthBarImage.transform.localScale.z);
            YellowHealthBar.transform.localScale = new Vector3(0.987f, YellowHealthBar.transform.localScale.y, YellowHealthBar.transform.localScale.z);
        }


    }

    public void UpdateUI()
    {
        CurrentHealthText.text = CurrentHealht.ToString();
        CurrentStaminaText.text = CurrentStamina.ToString();
        CurrentManaText.text = CurrentMana.ToString();

    }

    public void SetValues()
    {
        CurrentHealht = CreatePlayer.Instance.HealthPoints;
        CurrentMana = CreatePlayer.Instance.ManaPoints;
        CurrentStamina = CreatePlayer.Instance.StaminaPoints;
       
    }

    public void TakeDamage(int damage)
    {
        PlayerController.Instance.MyAnim.SetBool("Stagger", true);
        float MaxHealht = CreatePlayer.Instance.HealthPoints;
        float Dam = damage;
        CurrentHealht -= damage;
        HealthBarImage.transform.localScale = new Vector3(HealthBarImage.transform.localScale.x - (Dam/MaxHealht), HealthBarImage.transform.localScale.y, HealthBarImage.transform.localScale.z);
        UpdateUI();
    }

    public void GainHealth(int healthIncrease)
    {
        float MaxHealht = CreatePlayer.Instance.HealthPoints;
        float Dam = healthIncrease;
        CurrentHealht += healthIncrease;
        HealthBarImage.transform.localScale = new Vector3(HealthBarImage.transform.localScale.x + (Dam / MaxHealht), HealthBarImage.transform.localScale.y, HealthBarImage.transform.localScale.z);
        UpdateUI();
    }

    private void OnLevelWasLoaded(int level)
    {
     
        if (level == 2)
        {
            CreatePlayer.Instance.SetValues();
            //CreatePlayer.Instance.SetHandDamage();
            CreatePlayer.Instance.UpdateUI();
            SetValues();
            UpdateUI();
        }
        /*createplayer.UpdateUI();
        SetValues();
        UpdateUI();*/
        Debug.Log(CurrentHealht);
        Debug.Log(CreatePlayer.Instance.HealthPoints);
        Debug.Log(StaminaBarLoss);

    }
}
