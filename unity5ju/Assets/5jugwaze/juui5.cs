using UnityEngine;

public class Juui5 : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 3f;
    public GameObject startbutton;
    public GameObject gameoverText;

    private Vector3 moveDir = Vector3.zero;
    private bool isMoving = false;

    // 1. 게임 시작 (버튼 연결용)
    public void GameStart()
    {
        if (startbutton != null) startbutton.SetActive(false);
        if (gameoverText != null) gameoverText.SetActive(false);

        StartMoving(Vector3.up); // 처음엔 위로 시작
    }

    void Update()
    {
        if (!isMoving) return;

        // 설정된 방향(moveDir)으로 지속 이동
        transform.Translate(moveDir * moveSpeed * Time.deltaTime);

        // 왼쪽으로 이동 중일 때 화면 밖(-7)으로 나가면 정지 (예시 로직)
        if (moveDir == Vector3.left && transform.position.x < -7f)
        {
            StopMoving();
        }
    }

    public void StartMoving(Vector3 dir)
    {
        moveDir = dir.normalized;
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
        moveDir = Vector3.zero;
        if (gameoverText != null) gameoverText.SetActive(true);
    }

    // 2. 트리거 충돌 시 방향 전환 (조건부 발동)
    private void OnTriggerEnter(Collider other)
    {
        if (!isMoving) return; // 게임 중이 아닐 땐 무시

        // 태그에 따라 이동 방향(moveDir)만 교체
        switch (other.tag)
        {
            case "RTCbue":
                moveDir = Vector3.right;
                break; // switch문에는 break가 필수입니다!
            case "LTCbue":
                moveDir = Vector3.left;
                break;
            case "RDCbue":
                moveDir = Vector3.down;
                break;
            case "Cbue":
                moveDir = Vector3.right;
                break;
        }
    }
}