using Eternal_Warriors._Scripts;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Hero
{
    public string heroName;
    public int attack;
    public int defense;
    public int superPower;
    [JsonIgnore]
    public Sprite heroImage;
}

[System.Serializable]
public class HeroCollection
{
    public List<Hero> heroes;
}

public class HeroUIManager : MonoBehaviour
{
    private int currentHeroIndex = 0;
    private HeroCollection heroes = new HeroCollection { heroes = new List<Hero>() };

    public TextMeshProUGUI heroNameText;
    public Image heroImage;
    public Image attackBtn;
    public Image defenseBtn;
    public Image superPowerBtn;

    private void Start()
    {
        if (heroes.heroes == null || heroes.heroes.Count == 0)
        {
            heroes.heroes = new List<Hero>
            {
                new Hero
                {
                    heroName = "kiem",
                    attack = 0,
                    defense = 0,
                    superPower = 0
                },
                new Hero
                {
                heroName = "cung",
                attack = 0,
                defense = 0,
                superPower = 0
                },
                new Hero
                {
                    heroName = "voi", 
                    attack = 0, 
                    defense = 0, 
                    superPower = 0
                }
            };
        }
        UpdateHeroUI();
        GameManager.instance.Potential = 20;
    }
    public void UpdateHeroUI()
    {
        Hero currentHero = heroes.heroes[currentHeroIndex];

        heroNameText.text = currentHero.heroName;
        heroImage.sprite = currentHero.heroImage;   
        attackBtn.fillAmount = currentHero.attack/100f;
        defenseBtn.fillAmount = currentHero.defense/100f;
        superPowerBtn.fillAmount = currentHero.superPower/100f;
    }
    public void UpgradeAttack()
    {
        Hero currentHero = heroes.heroes[currentHeroIndex];
        if (currentHero.attack >= 100) return;
        currentHero.attack += 10;
        GameManager.instance.RemovePotinal(1, 10);
        UpdateHeroUI();
    }
    public void UpgradeDefense()
    {
        Hero currentHero = heroes.heroes[currentHeroIndex];
        if (currentHero.defense >= 100) return;
        currentHero.defense += 10;
        GameManager.instance.RemovePotinal(1, 10);
        UpdateHeroUI();
    }
    public void UpgradeSuperPower()
    {
        Hero currentHero = heroes.heroes[currentHeroIndex];
        if (currentHero.superPower >= 100) return;
        currentHero.superPower += 10;
        GameManager.instance.RemovePotinal(1, 10);
        UpdateHeroUI();
    }
    public void NextHero()
    {
        if (heroes.heroes == null || heroes.heroes.Count == 0) return;
        currentHeroIndex = (currentHeroIndex + 1) % heroes.heroes.Count;
        UpdateHeroUI();
    }
    public void PreviousHero()
    {
        if (heroes.heroes == null || heroes.heroes.Count == 0) return;
        currentHeroIndex = (currentHeroIndex - 1 + heroes.heroes.Count) % heroes.heroes.Count;
        UpdateHeroUI();
    }
}