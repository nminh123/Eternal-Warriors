using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int maxHealth;
    private int health;

    private void Start()
    {
        health = maxHealth;
    }
    public void Damage(int damage)
    {
        health -= damage;   
    }
}
