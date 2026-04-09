// ================================================================
// [EnemyController.cs] 적 행동 제어 스크립트
// ================================================================
// 역할: 적이 플레이어를 향해 자동으로 이동하고,
//       총알에 맞으면 HP를 깎고 HP가 0이 되면 스스로를 파괴한다.
//
// [핵심 개념]
//  - GameObject.FindGameObjectWithTag : 씬 전체에서 해당 태그를 가진 오브젝트를 찾는다.
//                                       단, 매 프레임 호출하면 느리므로 Start에서 한 번만 호출.
//  - Image.fillAmount : UI Image의 채워진 비율(0.0 ~ 1.0). HP 바 표현에 사용.
//  - (player.position - transform.position).normalized : 적 → 플레이어 방향의 단위 벡터.
// ================================================================

using UnityEngine;
using UnityEngine.UI; // Image 컴포넌트를 사용하기 위해 필요한 네임스페이스

public class EnemyController : MonoBehaviour
{
    // ── Inspector 공개 변수 ──
    public float moveSpeed = 2f;  // 적의 이동 속도 (플레이어보다 느리게 설정해야 도망칠 수 있다)
    public int hp = 200;          // 적의 현재 체력 (최대 체력과 별도로 관리하고 싶으면 maxHp 변수 추가 권장)
    public Image hpbar;           // Inspector에서 연결할 UI Image 컴포넌트 (HP 바 이미지)
                                  // 초보자 Tip: Image의 Image Type을 "Filled"로 설정해야 fillAmount가 작동함.

    // ── 내부 전용 변수 ──
    private Transform player;     // 플레이어의 위치 정보를 담고 있는 Transform 참조

    // ---------------------------------------------------------------
    // Start() : 오브젝트 생성 직후 딱 한 번 실행
    // ---------------------------------------------------------------
    void Start()
    {
        // "Player" 태그를 가진 게임 오브젝트를 씬에서 찾는다.
        // 초보자 Tip: Player 오브젝트에 Tag가 "Player"로 설정되어 있어야 한다.
        //             유니티 에디터 상단의 Tag 드롭다운에서 설정 가능.
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
            player = target.transform; // 찾은 오브젝트의 Transform만 저장 (위치 추적에 Transform이면 충분)
    }

    // ---------------------------------------------------------------
    // Update() : 매 프레임 실행. 플레이어 방향으로 이동한다.
    // ---------------------------------------------------------------
    void Update()
    {
        // 플레이어가 없으면 아무 것도 하지 않고 종료 (null 체크로 에러 방지)
        if (player == null) return;

        // 적 → 플레이어 방향 벡터를 계산한다.
        // (목적지 - 현재 위치) = 목적지를 향하는 벡터
        // .normalized : 크기를 1로 만들어 방향만 남김
        Vector3 dir = (player.position - transform.position).normalized;

        // 이동: 현재 위치에서 방향 × 속도 × 프레임 시간만큼 더한다.
        // Time.deltaTime 곱하기: 프레임 수에 관계없이 일정한 속도를 보장한다.
        // 초보자 Tip: Time.deltaTime을 빼먹으면 고사양 PC에서 적이 엄청나게 빨리 움직인다.
        transform.position += dir * moveSpeed * Time.deltaTime;
    }

    // ---------------------------------------------------------------
    // TakeDamage() : Bullet 스크립트에서 호출되는 피해 처리 메서드
    // public이므로 다른 스크립트(Bullet.cs)에서 호출 가능하다.
    // ---------------------------------------------------------------
    public void TakeDamage(int damage)
    {
        // 받은 피해만큼 HP를 감소시킨다.
        hp -= damage;

        // HP 바 UI 업데이트
        // fillAmount 범위: 0.0(완전히 빔) ~ 1.0(완전히 참)
        // hp / 30f : 현재 HP를 30으로 나눠 0~1 범위로 변환.
        // 초보자 주의: 정수 / 정수 = 정수(소수점 버림) 이므로 반드시 30f처럼 float을 사용해야 한다.
        //              예) 15 / 30 = 0 (잘못됨),  15 / 30f = 0.5 (올바름)
        // 주의: 이 코드는 최대 HP가 30일 때만 정확히 작동한다.
        //       최대 HP를 바꾸려면 이 숫자도 함께 바꿔야 한다. (변수 사용 권장)
        hpbar.fillAmount = hp / 30f;

        // HP가 0 이하가 되면 이 게임 오브젝트를 씬에서 제거한다.
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
