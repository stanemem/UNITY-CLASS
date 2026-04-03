using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    public int power = 500;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rb.linearVelocity = new Vector3(0, 10 ,0);
    }

    private void OnMouseDown()
    {
        rb.AddForce(Vector3.forward * power, ForceMode.Force); // 쉼표로 구분!
        rb.useGravity = true;
    }
}
