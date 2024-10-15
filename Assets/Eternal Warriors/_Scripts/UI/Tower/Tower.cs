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

    protected void Start()
    {
        health = maxHealth;
    }
    protected void Update()
    {
        if (healthImage.fillAmount != targetFillAmount)
        {
            healthImage.fillAmount = Mathf.MoveTowards(healthImage.fillAmount, targetFillAmount, updateSpeed * Time.deltaTime);
        }
        SetHealth(health, maxHealth);
    }
    public virtual void Damage(int damage)
    {
        health -= damage;   
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
