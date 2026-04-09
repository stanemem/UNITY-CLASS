using UnityEngine;
using UnityEngine.SceneManagement;

public class JU62 : MonoBehaviour
{
    public float power;
    public Rigidbody rb;
    public float POWERPLUS = 100.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) power += POWERPLUS * Time.deltaTime;
        if (Input.GetMouseButtonUp(0)) rb.AddForce(new Vector3(power, power, power));
        if (transform.position.y < -6f) SceneManager.LoadScene("JU62");

    }
}
