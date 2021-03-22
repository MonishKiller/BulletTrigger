using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private int destroyedEnemy;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private Text enemyCount;
    [SerializeField] private Text level;
    [SerializeField] private int level1;
    private void Start() {
        level.text = "LEVEL :" + level1;

    }
    public void DestroyedEnemy()
    {
        destroyedEnemy--;
        if (destroyedEnemy <= 0)
        {
            levelManager.LoadnextScene();
        }

    }
    private void Update()
    {
        enemyCount.text = "Enemy_Alive : " + destroyedEnemy;
    }
}
