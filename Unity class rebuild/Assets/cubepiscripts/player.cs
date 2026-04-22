using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
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
        canvasUI.SetActive(false); // UI 숨기기
    }

    void Update()
    {
        // 스페이스바를 누르고 있으면 speed 0.1f만큼 증가
        if (Input.GetKey(KeyCode.Space)) speed += 0.1f;

        // 스페이스바를 떼면 위로 이동 시작
        if (Input.GetKeyUp(KeyCode.Space)) goUp = true;

        if (goUp) transform.Translate(Vector3.up * speed * Time.deltaTime);

        // Y좌표가 6 이상일 경우 게임종료, UI보여주기
        if (transform.position.y > 6)
        {
            speed = 0;
            canvasUI.SetActive(true);
            scoreText.text = "Score : " + score.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
        score += 1; // player가 Cube에 닿으면 Score 추가
    }

    public void RestartBtn(string cubepihagi)
    {
        SceneManager.LoadScene("cubepihagi"); // 버튼 클릭 시 Scene 재시작
    }
}