using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    public int maxHealth;
    private int health;

    [SerializeField] public Image healthImage;
    private float targetFillAmount;
    private float updateSpeed = 1f;
    public bool isLive { get; private set; }

    protected void Start()
    {
        health = maxHealth;
        isLive = true;
    }
    protected void Update()
    {
        if (healthImage.fillAmount != targetFillAmount)
        {
            healthImage.fillAmount = Mathf.MoveTowards(healthImage.fillAmount, targetFillAmount, updateSpeed * Time.deltaTime);
        }
        this.SetHealth(health, maxHealth);
        this.CheckDeah();
    }
    public virtual void Damage(int damage)
    {
        health -= damage;   
    }
    public virtual void CheckDeah()
    {
        if(health <= 0)
            isLive = false;
    }
    public void SetHealth(int currentHealth, int maxHealth)
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthUI(currentHealth, maxHealth);
    }
    public void UpdateHealthUI(int currentHealth, int MaxHealth)
    {
        targetFillAmount = (float)currentHealth / MaxHealth;

    }
}
