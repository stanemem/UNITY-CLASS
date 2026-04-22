using UnityEngine;
using TMPro; // 텍스트를 제어하기 위해 꼭 필요합니다.

public class UISCRIPTS : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 화면에 보이는 점수 텍스트 연결용
    private int currentScore = 0;    // 실제 점수 숫자

    // 버튼을 눌렀을 때 실행될 함수들 (public이어야 버튼에서 보입니다)
    public void PlusScore()
    {
        currentScore += 1;
        UpdateUI();
    }

    public void MinusScore()
    {
        currentScore -= 1;
        UpdateUI();
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateUI();
    }

    // 숫자를 텍스트로 바꿔주는 함수
    void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
}