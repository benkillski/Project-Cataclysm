using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        PlayerScore playerScore = FindObjectOfType<PlayerScore>();
        playerScore.SetScore(playerScore.GetScore() + 10);
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

