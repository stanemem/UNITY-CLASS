// ================================================================
// [GameManager.cs] 게임 전체 흐름 관리 스크립트
// ================================================================
// 역할: 게임 시작 전 화면(터치 UI 깜빡임)을 보여주고,
//       마우스 클릭 시 게임을 시작(플레이어·적 활성화)하는 흐름을 제어한다.
//
// [핵심 개념]
//  - Awake()        : Start()보다 먼저 실행된다. 가장 이른 초기화에 사용.
//  - Coroutine(코루틴): 실행을 여러 프레임에 걸쳐 나눌 수 있는 특별한 함수.
//                      yield return으로 '잠깐 멈추고 나중에 재개'할 수 있다.
//  - IEnumerator    : 코루틴 함수의 반환 타입. StartCoroutine()으로 실행한다.
//  - SetActive(bool): 게임 오브젝트를 활성화(true)/비활성화(false)한다.
//  - TextMeshPro    : Unity UI Text보다 깔끔한 텍스트 렌더링을 제공하는 에셋.
// ================================================================

using UnityEngine;
using UnityEngine.UI;       // UI 관련 클래스 사용
using TMPro;                // TextMeshPro 사용을 위한 네임스페이스
using System.Collections;  // IEnumerator(코루틴) 사용을 위한 네임스페이스

public class GameManager : MonoBehaviour
{
    // ── Inspector 공개 변수 ──
    // 초보자 Tip: 아래 변수들은 모두 Inspector에서 직접 드래그하여 연결해야 작동한다.
    public GameObject Enemy;       // 적 스폰 관련 게임 오브젝트 (게임 시작 전까지 비활성화)
    public GameObject Player;      // 플레이어 게임 오브젝트 (게임 시작 전까지 비활성화)
                                   // Inspector에서 Player 오브젝트가 잘 연결되어 있는지 확인!
    public GameObject TouchToStart; // "터치하여 시작" UI 오브젝트 (깜빡이며 안내)
    public TextMeshProUGUI ScoreText; // 점수 텍스트 UI (TextMeshPro 컴포넌트)
    public int score = 0;           // 현재 점수

    // ── 내부 상태 변수 ──
    private bool isGameStarted = false; // 게임이 시작되었는지 여부를 추적하는 플래그(flag)

    // ---------------------------------------------------------------
    // Awake() : Start()보다 먼저, 씬이 로드될 때 가장 먼저 실행된다.
    // 초보자 Tip: 다른 오브젝트의 Start가 실행되기 전에 필요한 초기 설정을 여기서 한다.
    // ---------------------------------------------------------------
    void Awake()
    {
        // 게임 시작 전에는 적과 플레이어를 숨겨둔다.
        // SetActive(false) : 게임 오브젝트와 그 자식 오브젝트 전체를 비활성화
        if (Enemy != null) Enemy.SetActive(false);
        if (Player != null) Player.SetActive(false); // null 체크 후 비활성화

        // "터치하여 시작" UI를 먼저 활성화한 다음 ...
        if (TouchToStart != null) TouchToStart.SetActive(true);

        // ... 코루틴 tts를 시작한다. (문자열로 코루틴 이름을 전달하면 StopCoroutine으로 멈출 수 있다)
        StartCoroutine("tts");

        // 코루틴이 시작되면 tts 내부에서 깜빡임을 직접 제어하므로 여기서는 일단 꺼둔다.
        // 초보자 Tip: StartCoroutine은 비동기로 실행되므로, 이 SetActive(false)는
        //             tts 코루틴 내부의 첫 SetActive(false)와 거의 동시에 작동한다.
        TouchToStart.SetActive(false);
    }

    // ---------------------------------------------------------------
    // tts() : "터치하여 시작" 문구를 0.5초 간격으로 깜빡이게 하는 코루틴
    // 코루틴(Coroutine): 일반 함수와 달리 중간에 실행을 멈추고 나중에 재개할 수 있다.
    // ---------------------------------------------------------------
    IEnumerator tts()
    {
        // while(true) : 무한 반복 루프. StopCoroutine이 호출될 때까지 계속 실행된다.
        while (true)
        {
            Debug.Log("작동"); // 콘솔에 로그 출력 (디버그용. 빌드 시에도 실행되지만 보이지 않음)

            // UI 숨기기
            TouchToStart.SetActive(false);

            // yield return new WaitForSeconds(t) : t초 동안 실행을 일시 중단하고 이후 재개한다.
            // 초보자 Tip: 일반 함수에서는 불가능한 '기다리기'를 코루틴에서는 쉽게 구현할 수 있다.
            yield return new WaitForSeconds(0.5f);

            // UI 보이기
            TouchToStart.SetActive(true);

            // 다시 0.5초 대기
            yield return new WaitForSeconds(0.5f);

            // → while(true)로 돌아가 다시 반복 (깜빡임 효과 완성)
        }
    }

    // ---------------------------------------------------------------
    // Update() : 매 프레임 마우스 클릭 입력을 감지한다.
    // ---------------------------------------------------------------
    void Update()
    {
        // 아직 게임이 시작 안 됐을 때 && 마우스 왼쪽 버튼(0번)을 클릭하면
        // Input.GetMouseButtonDown(0) : 마우스 왼쪽 버튼이 눌린 첫 프레임에만 true
        if (!isGameStarted && Input.GetMouseButtonDown(0))
        {
            // 게임 시작 시퀀스 코루틴을 실행한다.
            StartCoroutine(StartGameSequence());
        }
    }

    // ---------------------------------------------------------------
    // StartGameSequence() : 클릭 후 실제 게임을 시작하는 코루틴
    // 약간의 딜레이 후 적·플레이어를 활성화한다.
    // ---------------------------------------------------------------
    IEnumerator StartGameSequence()
    {
        // 게임 시작 플래그를 true로 설정해 Update에서 중복 실행을 방지한다.
        isGameStarted = true;

        // 깜빡임 코루틴을 중단한다. (문자열로 시작한 코루틴은 문자열로 멈출 수 있다)
        StopCoroutine("tts");

        // "터치하여 시작" UI를 숨긴다.
        if (TouchToStart != null) TouchToStart.SetActive(false);

        // 1초 대기 (약간의 연출 딜레이)
        yield return new WaitForSeconds(1f);

        // 적과 플레이어를 활성화한다. (이제 게임이 실제로 시작됨)
        if (Enemy != null) Enemy.SetActive(true);
        if (Player != null) Player.SetActive(true);

        // 점수 텍스트 UI를 활성화한다.
        if (ScoreText != null) ScoreText.gameObject.SetActive(true);
    }
}
