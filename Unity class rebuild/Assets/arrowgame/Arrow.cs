using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float speed = 10f; // 화살 속도
    private bool flying = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            flying = true;
        }

        if (flying)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
