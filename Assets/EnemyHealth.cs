using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;

    public int health;
    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0)
        {
            enemyManager.DestroyedEnemy();
            Destroy(this.gameObject);
        }
        }
}
