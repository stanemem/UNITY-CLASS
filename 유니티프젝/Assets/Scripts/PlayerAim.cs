// ================================================================
// [PlayerAim.cs] 플레이어 조준(에임) 스크립트
// ================================================================
// 역할: 마우스 커서 방향으로 플레이어(또는 총구 오브젝트)가 항상 회전하도록 한다.
//       총구가 항상 마우스를 바라보게 하여 조준 방향을 시각적으로 표현한다.
//
// [핵심 개념]
//  - ScreenToWorldPoint : 화면 픽셀 좌표(스크린 좌표)를 게임 월드 좌표로 변환한다.
//                         마우스 위치는 픽셀 좌표이므로 이 변환이 필요하다.
//  - Mathf.Atan2(y, x)  : y/x의 역탄젠트(아크탄젠트)를 라디안으로 반환한다.
//                          벡터가 x축과 이루는 각도를 구할 때 사용하는 수학 함수.
//  - Mathf.Rad2Deg      : 라디안을 도(degree)로 변환하는 상수 (≈ 57.2958)
//  - Quaternion.Euler   : x, y, z 각도(도 단위)로 회전을 표현하는 쿼터니언을 만든다.
//
// [스크린 좌표 vs 월드 좌표]
//  - 스크린 좌표 : 화면의 왼쪽 아래가 (0,0), 오른쪽 위가 (Screen.width, Screen.height)
//  - 월드 좌표   : 유니티 씬 공간의 실제 위치. 카메라 위치/줌에 따라 스크린 좌표와 다름.
// ================================================================

using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    // ── Inspector 공개 변수 ──
    // 조준에 사용할 카메라. 비워두면 Start()에서 메인 카메라를 자동으로 찾는다.
    public Camera mainCamera;

    // ---------------------------------------------------------------
    // Start() : 카메라가 연결되지 않은 경우 메인 카메라를 자동으로 찾는다.
    // ---------------------------------------------------------------
    void Start()
    {
        // mainCamera가 Inspector에서 연결되지 않은 경우(null이면)
        // Camera.main : "MainCamera" 태그가 붙은 카메라를 자동으로 반환한다.
        // 초보자 Tip: 씬에 카메라가 하나라면 보통 Camera.main으로 찾을 수 있다.
        if (mainCamera == null)
            mainCamera = Camera.main;
    }

    // ---------------------------------------------------------------
    // Update() : 매 프레임 마우스 방향으로 오브젝트를 회전시킨다.
    // ---------------------------------------------------------------
    void Update()
    {
        AimToMouse();
    }

    // ---------------------------------------------------------------
    // AimToMouse() : 마우스 위치를 월드 좌표로 변환하고 그 방향으로 회전한다.
    // ---------------------------------------------------------------
    void AimToMouse()
    {
        // Input.mousePosition : 마우스의 현재 스크린(화면 픽셀) 좌표 (Vector3, z=0)
        Vector3 mouseScreenPos = Input.mousePosition;

        // ScreenToWorldPoint : 스크린 픽셀 좌표 → 유니티 월드 좌표 변환
        // 초보자 Tip: 2D 게임에서는 z 값이 카메라와의 거리가 되므로 이후에 z=0으로 고정한다.
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(mouseScreenPos);

        // 2D 게임이므로 z 값을 0으로 강제 설정한다.
        // (ScreenToWorldPoint의 z값이 카메라 위치에 따라 달라질 수 있으므로 보정 필요)
        mouseWorldPos.z = 0f;

        // 이 오브젝트(플레이어 또는 총구)에서 마우스 월드 위치까지의 방향 벡터
        // (목적지) - (현재 위치) = 방향 벡터
        Vector2 direction = mouseWorldPos - transform.position;

        // Atan2(y, x) : 벡터가 x축(오른쪽)과 이루는 각도를 라디안으로 반환
        // Rad2Deg     : 라디안 → 도 변환 (360도 기준으로 변환)
        // 예시) 마우스가 바로 위에 있으면 angle ≈ 90, 오른쪽이면 ≈ 0, 왼쪽이면 ≈ 180
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Quaternion.Euler(x, y, z) : 각도로 회전을 표현
        // 2D 게임이므로 z축만 회전시킨다. (x와 y는 0으로 고정)
        // 계산된 각도만큼 z축으로 회전 → 오브젝트가 마우스 방향을 바라보게 된다.
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
