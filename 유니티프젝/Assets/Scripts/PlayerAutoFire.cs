using UnityEngine;

public class PlayerAutoFire : MonoBehaviour
{
    [Header("Fire")]
    public GameObject bulletPrefab;
    public Transform FirePoint;
    public float fireInterval = 0.3f;

    [Header("Sound")]
    public AudioSource audioSource;
    public AudioClip fireClip;

    [Header("Auto Aim")]
    public float aimRange = 25f;

    private float fireTimer = 0f;

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            Transform target = FindClosestEnemy();

            if (target != null)
            {
                fireTimer = 0f;

                Vector2 dir = ((Vector2)target.position - (Vector2)FirePoint.position).normalized;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0f, 0f, angle);

                GameObject newBullet = Instantiate(bulletPrefab, FirePoint.position, rotation);

                Bullet bullet = newBullet.GetComponent<Bullet>();
                if (bullet != null)
                {
                    bullet.SetDirection(dir);
                }

                if (audioSource != null && fireClip != null)
                {
                    audioSource.PlayOneShot(fireClip);
                }
            }
        }
    }

    Transform FindClosestEnemy()
    {
        // 태그가 "Enemy"인 모든 오브젝트를 찾는다
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        Transform bestTarget = null;
        float bestDistance = float.MaxValue;

        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Vector2.Distance(FirePoint.position, enemies[i].transform.position);

            // 사정거리 안에 있는 것만
            if (distance <= aimRange && distance < bestDistance)
            {
                bestDistance = distance;
                bestTarget = enemies[i].transform;
            }
        }

        return bestTarget;
    }
}
