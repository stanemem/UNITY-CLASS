using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public TextMeshPro SCORE;
    public TextMeshPro timetext;
    public int score;
    public float time;
    // 닿는 동안 매 프레임 실행됨
    private void OnTriggerStay(Collider other)
    {
        // 점수 아이템 구역에 있는 동안
        if (other.CompareTag("SCORE"))
        {
            // 초당 10점씩 올라가도록 설정 (Time.deltaTime 사용)
            // 정수형(int) score에 더할 때는 소수점 계산을 위해 아래처럼 처리합니다.
            float scoreGain = 10f * Time.deltaTime;

            // 실제 점수에 반영 (소수점을 누적했다가 정수로 변환)
            // 만약 정수형으로 딱딱 떨어지게 하고 싶다면 그냥 score += 1; 을 써도 되지만 매우 빠릅니다.
            score += 1; // 혹은 특정 주기마다 올리는 로직 필요

            time += Time.deltaTime; // 시간은 초 단위로 부드럽게 증가

            // UI 업데이트
            SCORE.text = "Score: " + score.ToString();
            timetext.text = "Time: " + time.ToString("F1"); // 소수점 첫째자리까지 표시
        }

        // 감점 구역에 있는 동안
        if (other.CompareTag("MINUS"))
        {
            score -= 1;
            time += Time.deltaTime;

            SCORE.text = "Score: " + score.ToString();
            timetext.text = "Time: " + time.ToString("F1");
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 3 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 3 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * 3 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * 3 * Time.deltaTime);
        }
    }
}
