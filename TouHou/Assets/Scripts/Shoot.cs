using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Bullet Variables")]
    [SerializeField] private GameObject bulletPrefab;
    public GameObject firePoint;
    public GameObject firePoint1;
    public GameObject firePoint2;

    [Header("Score Variables")]
    public TextMeshProUGUI scoreText;
    public int score = 0;

    private float timeBtwShots;
    public float startTime;

    public void Update()
    {
        scoreText.text = "Score: " + score.ToString();

        if (timeBtwShots <= 0)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                ShootBullet();
                timeBtwShots = startTime;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    void ShootBullet()
    {
        if (firePoint.activeSelf == true)
        {
            Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity); 
        }

        if (firePoint1.activeSelf == true)
        {
            Instantiate(bulletPrefab, firePoint1.transform.position, Quaternion.identity);
        }

        if (firePoint2.activeSelf == true)
        {
            Instantiate(bulletPrefab, firePoint2.transform.position, Quaternion.identity);
        }

    }
}
