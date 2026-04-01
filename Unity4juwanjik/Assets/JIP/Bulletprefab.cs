using UnityEngine;

public class Bulletprefab : MonoBehaviour
{
    public float bulletspeed = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * bulletspeed * Time.deltaTime);
    }

}
