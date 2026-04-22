using UnityEngine;

public class Q5CUBE : MonoBehaviour
{
    // 큐브들을 리스트(배열)로 관리하면 코드가 훨씬 간결해집니다.
    public GameObject[] missCubes;

    // 현재 몇 번째 큐브를 끌지 기억하는 번호 (0부터 시작)
    private int currentIndex = 0;

    private void OnMouseDown()
    {
        // 1. 아직 끌 큐브가 남아있는지 확인 (배열 길이를 넘지 않았는지)
        if (currentIndex < missCubes.Length)
        {
            // 2. 현재 번호의 큐브를 비활성화(false) 함
            if (missCubes[currentIndex] != null)
            {
                missCubes[currentIndex].SetActive(false);
                Debug.Log(currentIndex + "번 큐브가 사라졌습니다.");
            }

            // 3. 다음 클릭 때는 다음 큐브를 꺼야 하므로 번호를 1 증가시킴
            currentIndex++;
        }
        else
        {
            Debug.Log("더 이상 사라질 큐브가 없습니다!");
        }
    }
}