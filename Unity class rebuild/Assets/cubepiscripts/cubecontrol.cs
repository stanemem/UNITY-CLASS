using UnityEngine;

public class cubecontrol : MonoBehaviour
{
    bool isRight;
    float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = Random.Range(1.0f, 9.0f);
        isRight = Random.Range(0, 2) == 1;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = isRight ? Vector3.right : Vector3.left;
        transform.Translate(dir * speed * Time.deltaTime);

        if (transform.position.x > 7.0f) isRight = false;
        if (transform.position.x < -7.0f) isRight = true;


    }
}
