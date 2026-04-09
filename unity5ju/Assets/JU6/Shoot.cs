using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{
    private float speed;
    private int score;
    private bool goUp;

    public GameObject canvasUI;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        score = 0;
        speed = 0;
        if (canvasUI != null) canvasUI.SetActive(false);
    }

    void Update()
    {
        // 스페이스바를 누르는 동안 속도 증가 및 상승 상태 활성화
        if (Input.GetKey(KeyCode.Space))
        {
            speed += 0.1f;
            goUp = true;
        }

        // 상승 상태일 때 위로 이동
        if (goUp)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }

        // 특정 높이 이상 올라가면 정지 및 결과창 표시
        if (transform.position.y > 6f)
        {
            speed = 0;
            goUp = false; // 계속 상승하는 것을 방지
            if (canvasUI != null)
            {
                canvasUI.SetActive(true);
                scoreText.text = "Score: " + score.ToString();
            }
        }
    } // Update 함수 끝

    // Update 함수 밖에 있어야 함
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        score += 1;
    }

    // 버튼 클릭 이벤트 등에 연결
    public void Restart(string JU6)
    {
        // 변수 JU6이 아닌, 매개변수로 받은 sceneName이나 실제 씬 이름 문자열을 넣어야 합니다.
        SceneManager.LoadScene(JU6);
    }
}