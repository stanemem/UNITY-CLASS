// ================================================================
// [PlayerMove.cs] 플레이어 이동 스크립트
// ================================================================
// 역할: 키보드 입력(WASD 또는 방향키)을 받아 플레이어를 2D 공간에서 이동시킨다.
//
// [핵심 개념]
//  - MonoBehaviour : 유니티에서 게임 오브젝트에 붙이는 모든 스크립트의 기본 클래스.
//                    Start(), Update() 등 유니티 생명주기 함수를 사용할 수 있게 해준다.
//  - Rigidbody2D   : 2D 물리 엔진을 담당하는 컴포넌트.
//                    직접 transform.position을 바꾸는 대신 velocity(속도)를 이용하면
//                    물리 충돌 처리가 정확해진다.
//  - FixedUpdate   : 물리 연산은 반드시 FixedUpdate에서 처리해야 한다.
//                    Update는 프레임마다 호출(속도 불규칙), FixedUpdate는 고정 시간 간격으로 호출.
// ================================================================

using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // [Inspector 노출 변수]
    // public 변수는 유니티 에디터 Inspector 창에서 직접 값을 바꿀 수 있다.
    // 초보자 Tip: 숫자를 크게 하면 빠르게, 작게 하면 느리게 움직인다.
    public float moveSpeed = 5f;  // 플레이어 이동 속도 (단위: 유니티 월드 거리/초)

    // [private 변수 - 내부 전용]
    // private 변수는 이 스크립트 안에서만 사용한다. Inspector에 노출되지 않는다.
    private Rigidbody2D rb;        // 물리 컴포넌트 참조 (Start에서 가져옴)
    private Vector2 moveInput;     // 현재 프레임의 이동 방향 벡터 (x: 좌우, y: 상하)

    // ---------------------------------------------------------------
    // Start() : 게임 오브젝트가 처음 활성화될 때 딱 한 번 실행된다.
    // 초보자 Tip: 변수 초기화나 다른 컴포넌트 가져오기는 주로 Start에서 한다.
    // ---------------------------------------------------------------
    void Start()
    {
        // GetComponent<T>() : 이 게임 오브젝트에 붙어 있는 T 타입 컴포넌트를 가져온다.
        // Rigidbody2D가 없으면 null이 반환되고 이후 코드에서 에러가 난다.
        // → Inspector에서 Rigidbody2D 컴포넌트가 붙어 있는지 반드시 확인!
        rb = GetComponent<Rigidbody2D>();
    }

    // ---------------------------------------------------------------
    // Update() : 매 프레임마다 실행된다. (보통 1초에 60번 이상)
    // 입력 감지처럼 빠른 반응이 필요한 처리는 여기서 한다.
    // ---------------------------------------------------------------
    void Update()
    {
        // Input.GetAxisRaw("Horizontal") : 좌우 키 입력을 -1, 0, 1 중 하나로 반환.
        //   왼쪽(A 또는 ←) → -1,  오른쪽(D 또는 →) → +1,  입력 없음 → 0
        // GetAxis와 달리 GetAxisRaw는 부드러운 보간(가속/감속)이 없어서 즉각 반응한다.
        moveInput.x = Input.GetAxisRaw("Horizontal");

        // Input.GetAxisRaw("Vertical") : 상하 키 입력을 -1, 0, 1 중 하나로 반환.
        //   아래(S 또는 ↓) → -1,  위(W 또는 ↑) → +1
        moveInput.y = Input.GetAxisRaw("Vertical");

        // normalized : 벡터의 크기를 1로 만들어 준다. (방향만 남김)
        // 초보자 Tip: 대각선 이동 시 x와 y가 동시에 입력되면 벡터 크기가 √2 ≈ 1.41이 된다.
        //             그대로 두면 대각선 이동이 상하/좌우보다 약 41% 빠르게 된다.
        //             normalized로 크기를 1로 고정하면 모든 방향의 속도가 같아진다.
        moveInput = moveInput.normalized;
    }

    // ---------------------------------------------------------------
    // FixedUpdate() : 물리 엔진과 동기화된 고정 시간 간격으로 실행된다.
    // 기본값: 0.02초 간격 (초당 50회). 물리 관련 코드는 반드시 여기서!
    // ---------------------------------------------------------------
    void FixedUpdate()
    {
        // Rigidbody2D.linearVelocity : 오브젝트의 현재 속도 벡터를 직접 설정한다.
        // (moveInput 방향) × (moveSpeed 크기) = 최종 이동 속도 벡터
        // 초보자 Tip: velocity를 매 FixedUpdate에서 새로 덮어쓰는 방식이므로
        //             관성 없이 즉각 멈추고 즉각 움직인다.
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
