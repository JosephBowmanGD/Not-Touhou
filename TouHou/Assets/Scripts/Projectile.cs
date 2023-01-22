using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask solid;
    public float lifeTime;
    public GameObject destroyEffect;
    public int damage;

    private void Start()
    {
        Invoke(nameof(DestroyBullet), lifeTime);
    }

    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance, solid);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<EnemyController>().Damage(damage);
            }
            DestroyBullet();
        }

        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
        GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity) as GameObject;
        Destroy(effect, 2);
    }
}
