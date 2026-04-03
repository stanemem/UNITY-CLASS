using UnityEngine;

public class AK47 : MonoBehaviour
{
    public GameObject bullet;      // 복사해서 쏠 총알 프리팹
    public Transform firepoint;    // 총알이 나타날 위치 (총구)

    // [핵심 1] 다음 발사까지 기다려야 하는 시간 간격 (0.1초면 1초에 10발)
    public float fireRate = 0.1f;

    // [핵심 2] 다음에 발사 가능한 '시각'을 저장할 변수 (메모장 같은 역할)
    private float nextFireTime = 0f;

    void Update()
    {
        // Input.GetMouseButton(0) : 좌클릭을 '누르고 있는 동안' 매 프레임 체크
        // Time.time : 게임이 시작된 후 지금까지 흐른 총 시간 (예: 10.5초)

        // "지금 마우스를 누르고 있고, 현재 시간이 발사 예정 시간보다 지났니?"
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot(); // 총알 생성 함수 실행

            // [핵심 3] 발사 후, 다음 발사 가능 시간을 업데이트함
            // '현재 시간'에 '연사 간격'을 더해서 미래의 특정 시점을 예약하는 것
            // 예: 현재 10.0초라면 10.0 + 0.1 = 10.1초가 되어야 다음 발사 가능
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // 준비된 총알(bullet)을 총구(firepoint) 위치와 방향에 맞춰 복제(생성)함
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}