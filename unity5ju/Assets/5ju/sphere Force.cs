using UnityEngine;

public class sphereForce : MonoBehaviour
{
    public Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(Vector3.up * 4, ForceMode.Acceleration);
    }
}
