using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    void Update()
    {
        AimToMouse();
    }

    void AimToMouse()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        mouseWorldPos.z = 0f;

        Vector2 direction = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}