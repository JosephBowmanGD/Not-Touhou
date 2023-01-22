using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temps : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int enemySpeed = 2;

    [SerializeField]
    float fTimeIntervals;

    float fTimer = 0f;

    void Start()
    {
        fTimer = fTimeIntervals;
    }

    void Update()
    {
        fTimer -= Time.deltaTime;
        if (fTimer <= 0)
        {
            fTimer = fTimeIntervals;
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as GameObject;
            enemy.AddComponent<Rigidbody2D>().gravityScale = 0;
            enemy.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemySpeed);
            Destroy(enemy, 6);
        }
    }
}
