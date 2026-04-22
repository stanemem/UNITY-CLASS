using UnityEngine;

public class Q9SCRIPTS : MonoBehaviour
{
    // 1. 빨간색 큐브와 노란색 큐브를 연결할 변수
    public GameObject redCube;
    public GameObject yellowCube;

    void Update()
    {
        // 2. 키보드 R 키를 누르면 빨간색 큐브 상태를 반전
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (redCube != null)
            {
                // 현재 상태가 true면 false로, false면 true로 바꿉니다.
                bool isActive = redCube.activeSelf;
                redCube.SetActive(!isActive);
            }
        }

        // 3. 키보드 Y 키를 누르면 노란색 큐브 상태를 반전
        if (Input.GetKeyDown(KeyCode.Y))
        {
            if (yellowCube != null)
            {
                // ! 기호를 사용하면 한 줄로 간단하게 쓸 수 있습니다.
                yellowCube.SetActive(!yellowCube.activeSelf);
            }
        }
    }
}