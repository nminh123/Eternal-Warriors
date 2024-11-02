using Eternal_Warriors._Scripts;
using System.Collections.Generic;
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
    public Sprite heroImage;
}
public class HeroUIManager : MonoBehaviour
{
    public List<Hero> heroes;
    private int currentHeroIndex = 0;

    public TextMeshProUGUI heroNameText;
    public Image heroImage;
    public Image attackBtn;
    public Image defenseBtn;
    public Image superPowerBtn;

    private void Start()
    {
        UpdateHeroUI();
        GameManager.instance.Potential = 20;
    }
    public void UpdateHeroUI()
    {
        Hero currentHero = heroes[currentHeroIndex];

        heroNameText.text = currentHero.heroName;
        heroImage.sprite = currentHero.heroImage;   
        attackBtn.fillAmount = currentHero.attack/100f;
        defenseBtn.fillAmount = currentHero.defense/100f;
        superPowerBtn.fillAmount = currentHero.superPower/100f;
    }
    public void UpgradeAttack()
    {
        Hero currentHero = heroes[currentHeroIndex];
        if (currentHero.attack >= 100) return;
        currentHero.attack += 10;
        GameManager.instance.RemovePotinal(1, 10);
        UpdateHeroUI();
    }
    public void UpgradeDefense()
    {
        Hero currentHero = heroes[currentHeroIndex];
        if (currentHero.defense >= 100) return;
        currentHero.defense += 10;
        GameManager.instance.RemovePotinal(1, 10);
        UpdateHeroUI();
    }
    public void UpgradeSuperPower()
    {
        Hero currentHero = heroes[currentHeroIndex];
        if (currentHero.superPower >= 100) return;
        currentHero.superPower += 10;
        GameManager.instance.RemovePotinal(1, 10);
        UpdateHeroUI();
    }
    public void NextHero()
    {
        currentHeroIndex = (currentHeroIndex + 1) % heroes.Count;
        UpdateHeroUI();
    }
    public void PreviousHero()
    {
        currentHeroIndex = (currentHeroIndex - 1 + heroes.Count) % heroes.Count;
        UpdateHeroUI();
    }
}
