using TMPro;
using UnityEngine;

public class PController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public TextMeshPro playerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float mh = Input.GetAxis("Horizontal");
        float mv = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(mh, 0, 0);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
