using UnityEngine;

public class jumpandmove : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    public float jumpForce = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        float mh = Input.GetAxis("Horizontal");
        float mv = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(mh, 0, mv);
        rb.AddForce(movement * speed);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    // --- 여기에 충돌 감지 로직 추가 ---
    private void OnCollisionEnter(Collision collision)
    {
        // CompareTag는 함수이므로 ( )를 사용해야 합니다.
        if (collision.gameObject.CompareTag("leftcubeitem"))
        {
            Debug.Log("Left");
        }
        else if (collision.gameObject.CompareTag("rightcubeitem"))
        {
            Debug.Log("Right");
        }
    }
}