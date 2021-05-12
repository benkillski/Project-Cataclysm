using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public EnemyTypes enemyType;
    [SerializeField] int health;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public int GetHeath()
    {
        return health;
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }
}

