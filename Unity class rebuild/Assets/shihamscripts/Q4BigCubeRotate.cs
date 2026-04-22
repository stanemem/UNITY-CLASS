using UnityEngine;

public class Q4BigCubeRotate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public bool isRotating = false;
    public float rotateSpeed = 100f;

    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0, 5, rotateSpeed * Time.deltaTime);
        }
    }
}
