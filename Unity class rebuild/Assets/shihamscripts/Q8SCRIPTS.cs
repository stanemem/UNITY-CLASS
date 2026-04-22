using UnityEngine;
using UnityEngine.SceneManagement; // 씬 재시작을 위해 필요합니다.

public class Q8SCRIPTS : MonoBehaviour
{
    public float speed = 5.0f; // 이동 속도

    void Start()
    {
        // 1. 시작 위치 설정 (-9, 0, 0)
        transform.position = new Vector3(-9, 0, 0);
    }

    void Update()
    {
        // 2. 자동으로 오른쪽(Right)으로 이동
        // Vector3.right는 (1, 0, 0)과 같습니다.
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // 3. 화면 밖으로 나가면(X 좌표가 일정 수치 이상이면) 씬 재시작
        // 보통 화면 오른쪽 끝 X 좌표는 10~15 정도입니다.
        if (transform.position.x > 15.0f)
        {
            // 현재 활성화된 씬의 이름을 가져와서 다시 로드합니다.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}