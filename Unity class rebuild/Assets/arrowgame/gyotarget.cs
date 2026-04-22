using UnityEngine;

public class gyotarget : MonoBehaviour
{
    private bool isUp = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isUp) transform.Translate(Vector3.up * 3 * Time.deltaTime);
        else transform.Translate(Vector3.down * 3 * Time.deltaTime);

        if(transform.position.y > 3.5) isUp = false;
        if (transform.position.y < -3) isUp = true;
    }
}
