using UnityEngine;
using TMPro; // TextMeshPro 사용을 위해 필요

public class Q10SCRIPTS : MonoBehaviour
{
    public TextMeshPro countText;   // "Count : 0"이 표시될 텍스트
    public TextMeshPro finishText;  // "시험 끝!!!!!!"이 표시될 텍스트

    private int count = 0; // 숫자를 저장할 변수

    void Start()
    {
        // 1. 게임 시작 시 카운트 글자 보이기
        UpdateCountText();

        // 2. 시험 끝 텍스트는 처음에 안 보이게 설정
        if (finishText != null)
        {
            finishText.gameObject.SetActive(false);
        }
    }

    // 3. 큐브를 마우스로 클릭했을 때 실행
    private void OnMouseDown()
    {
        // 카운트가 5 미만일 때만 증가
        if (count < 5)
        {
            count++;
            UpdateCountText();

            // 4. 카운트가 5가 되면 시험 끝 텍스트 보이기
            if (count == 5)
            {
                if (finishText != null)
                {
                    finishText.gameObject.SetActive(true);
                }
            }
        }
    }

    // 텍스트를 업데이트해주는 도우미 함수
    void UpdateCountText()
    {
        if (countText != null)
        {
            countText.text = "Count : " + count;
        }
    }
}