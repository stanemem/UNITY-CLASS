using UnityEngine;

public class PlayerAutoFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireInterval = 0.3f;

    public AudioSource audioSource;
    public AudioClip fireClip;

    private float fireTimer = 0f;

    void Update()
    {
        AutoFire();
    }

    void AutoFire()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireInterval)
        {
            fireTimer = 0f;
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            if (audioSource != null && fireClip != null)
            {
                audioSource.PlayOneShot(fireClip);
            }
        }
    }
}