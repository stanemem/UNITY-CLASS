using UnityEngine;

public class CUBEMOOVE : MonoBehaviour
{
    // 1. 변수 선언: 처음에는 움직이지 않도록 false로 시작합니다.
    public bool isStart = false;

    public void MoveCube()
    {
        // 2. 함수가 호출되면 true로 바꿔서 움직이게 만듭니다.
        isStart = true;
    }

    void Start()
    {
    }

    void Update()
    {
        // 3. isStart가 true일 때만 왼쪽으로 이동합니다.
        if (isStart)
        {
            transform.Translate(Vector2.left * 1 * Time.deltaTime);
        }
    }
}