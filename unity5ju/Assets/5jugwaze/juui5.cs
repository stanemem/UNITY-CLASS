using UnityEngine;

public class Juui5 : MonoBehaviour // 숫자로 시작하면 안 돼요!
{
    public GameObject cuub1;
    public GameObject cuub2;
    public GameObject cuub3;
    public GameObject cuub4;
    void Start()
    {
        // 1. 소문자 transform으로 시작
        // 2. 대문자 Translate 함수 사용
        // 3. Vector2.up (0, 1) 대신 3D라면 Vector3.up (0, 1, 0) 권장
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // 부딪힌 상대방(collision)의 태그가 "cuub1" 인지 확인
        if (collision.gameObject.CompareTag("cuub1"))

        {
            transform.Translate(Vector3.left * Time.deltaTime);
            Debug.Log("cuub1과 부딪혔다! 왼쪽으로 꺾습니다.");
             // 상태 변경
        }
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
        
        
        // 여기에 코드를 넣으면 매 프레임마다 움직입니다.
    }

}