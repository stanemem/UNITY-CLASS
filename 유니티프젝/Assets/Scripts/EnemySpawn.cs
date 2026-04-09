// ================================================================
// [EnemySpawn.cs] 적 스폰(생성) 스크립트
// ================================================================
// 역할: 일정 시간 간격으로 플레이어 주변 랜덤한 위치에 적을 생성한다.
//
// [핵심 개념]
//  - Instantiate   : 프리팹(미리 만들어둔 오브젝트 설계도)을 게임 월드에 복사(생성)한다.
//  - Prefab(프리팹) : 반복 생성할 오브젝트의 '원본 템플릿'. Inspector에서 연결.
//  - Random.insideUnitCircle : 반지름 1인 원 안의 랜덤한 2D 점을 반환한다.
//  - .normalized   : 원의 테두리(반지름 정확히 1) 위의 점으로 만들기 위해 크기를 1로 정규화.
//  - Quaternion.identity : 회전 없음(기본 회전). 0, 0, 0, 1과 동일.
// ================================================================

using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // ── Inspector 공개 변수 ──
    public GameObject enemyPrefab;    // 생성할 적의 프리팹. Inspector에서 드래그하여 연결.
    public float spawnInterval = 1.5f; // 적 생성 간격 (초). 작을수록 더 자주 생성.
    public float spawnRadius = 8f;     // 플레이어로부터 적이 생성되는 거리 (반지름)
                                       // 초보자 Tip: 너무 작으면 적이 플레이어 바로 옆에 생겨 즉사 위험.

    // ── 내부 전용 변수 ──
    private Transform player; // 플레이어 위치 참조
    private float timer;      // 마지막 스폰 이후 경과 시간을 측정하는 타이머

    // ---------------------------------------------------------------
    // Start() : 시작 시 플레이어 오브젝트를 찾아 참조를 저장한다.
    // ---------------------------------------------------------------
    void Start()
    {
        // "Player" 태그로 플레이어 오브젝트를 씬에서 찾는다.
        // 초보자 Tip: Player 오브젝트의 태그가 "Player"여야 한다.
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
            player = target.transform;
    }

    // ---------------------------------------------------------------
    // Update() : 매 프레임 타이머를 증가시키고, 간격이 되면 적을 생성한다.
    // ---------------------------------------------------------------
    void Update()
    {
        // 플레이어가 없으면 스폰 중단 (null 체크)
        if (player == null) return;

        // 타이머에 이전 프레임 시간을 누적한다.
        // Time.deltaTime: 이전 프레임과 현재 프레임 사이의 시간 간격
        timer += Time.deltaTime;

        // 누적 시간이 spawnInterval을 넘으면 적을 생성한다.
        if (timer >= spawnInterval)
        {
            timer = 0f;  // 타이머 초기화 (다음 스폰을 위해 리셋)
            SpawnEnemy(); // 적 생성 메서드 호출
        }
    }

    // ---------------------------------------------------------------
    // SpawnEnemy() : 플레이어 주변 랜덤 위치에 적 프리팹을 생성한다.
    // ---------------------------------------------------------------
    void SpawnEnemy()
    {
        // Random.insideUnitCircle : 반지름 1인 원 내부의 랜덤한 Vector2 점을 반환한다.
        // .normalized : 크기를 1로 만들어 원의 테두리(외곽) 위의 점으로 변환한다.
        // 초보자 Tip: normalized 없이 쓰면 원 내부 어딘가에서 생성 (거리가 제각각).
        //             normalized 사용 시 항상 정확히 spawnRadius 거리에서 생성.
        Vector2 randomDir = Random.insideUnitCircle.normalized;

        // 플레이어 위치 + (랜덤 방향 × 반지름) = 최종 스폰 위치
        // new Vector3(x, y, 0) : 2D 게임이므로 z 값은 0으로 고정
        Vector3 spawnPos = player.position + new Vector3(randomDir.x, randomDir.y, 0) * spawnRadius;

        // Instantiate(원본, 위치, 회전) : 프리팹을 해당 위치와 회전으로 씬에 복사·생성한다.
        // Quaternion.identity : 회전 없음 (기본 방향 그대로)
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}
