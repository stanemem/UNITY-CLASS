using UnityEngine;

public class Q7UFO : MonoBehaviour
{
    public float speed = 10.0f;
    public float bouncePower = 15.0f; // 튕겨나가는 힘의 세기
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        // 튕길 때 회전하면서 굴러가지 않게 고정
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        rb.AddForce(movement * speed);
    }

    // --- 부딪히는 순간 강제로 속도를 반사시킴 ---
    private void OnCollisionEnter(Collision collision)
    {
        // 1. 부딪힌 지점의 법선(Normal)을 가져와 반사 방향 계산
        Vector3 reflectDir = Vector3.Reflect(rb.linearVelocity, collision.contacts[0].normal);

        // 2. 반사 방향으로 강한 속도를 부여 (기존 속도 무시하고 bouncePower만큼 튕김)
        rb.linearVelocity = reflectDir.normalized * bouncePower;

        Debug.Log(collision.gameObject.name + "과 강력 충돌!");
    }
}