using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject redItem;

    public float health;
    public Vector2 position;

    private void Update()
    {
        if(health <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Vector2 V2SpawnPos = transform.position;
        V2SpawnPos += Vector2.right * position.x * (Random.value - 0.5f);
        V2SpawnPos += Vector2.up * position.y * (Random.value - 0.5f);
        Destroy(this.gameObject);
        Instantiate(redItem, V2SpawnPos, Quaternion.identity);
    }

    public void Damage(float damage)
    {
        health -= damage;
    }
}
