using UnityEngine;

public class Q4smallCubeClick : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Q4BigCubeRotate targetBigCube;

    void OnMouseDown()
    {
        targetBigCube.isRotating = !targetBigCube.isRotating;
    }
}
