// ================================================================
// [Bullet.cs] 총알 스크립트
// ================================================================
// 역할: 발사된 총알은 오직 직선으로만 날아간다.
//       자동 조준(유도)은 발사하는 쪽에서 방향을 정해주는 것이지,
//       총알이 비행 중에 방향을 바꾸는 것이 아니다.
// ================================================================

using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Basic")]
    public float speed = 8f;
    public int damage = 1;
    public float lifeTime = 2f;

    [Header("Bounce")]
    public int maxBounceCount = 3;
    private int currentBounceCount = 0;

    private Vector2 moveDir;

    void Start()
    {
        if (moveDir.sqrMagnitude < 0.001f)
        {
            moveDir = transform.right.normalized;
        }

        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // 직선 이동만. 방향 전환 절대 없음.
        transform.position += (Vector3)(moveDir * speed * Time.deltaTime);

        if (moveDir.sqrMagnitude > 0.001f)
        {
            float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    public void SetDirection(Vector3 dir)
    {
        moveDir = dir.normalized;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 normal = collision.contacts[0].normal;
            moveDir = Vector2.Reflect(moveDir, normal).normalized;
            currentBounceCount++;
            transform.position += (Vector3)(moveDir * 0.05f);

            if (currentBounceCount >= maxBounceCount)
            {
                Destroy(gameObject);
            }
            return;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.gameObject.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
