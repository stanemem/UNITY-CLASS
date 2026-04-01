using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class Wehwa : MonoBehaviour
{
    public GameObject Player;
    public TextMesh tm;
    public TextMeshPro tmp;


    public void OnMouseOver()
    {
        Player.transform.Translate(Vector3.up * Time.deltaTime);
    }
    private void OnMouseDown()
    {
        // 1. Player 오브젝트에서 cubeclick 스크립트를 찾아옵니다.
        // 'Player'라는 이름의 GameObject가 미리 선언되어 있어야 합니다.
        cubeclick a = Player.GetComponent<cubeclick>();

        if (a != null) // 혹시 모를 에러 방지 (방어적 코드)
        {
            // 2. 'a.plus'라고만 적으면 아무 일도 안 일어납니다. 
            // 가져온 'a'의 변수 값을 현재 스크립트의 변수에 더해줘야 합니다.
            // a에 들어있는 plus 값을 현재 스크립트 plus에 더함
            a.minus += 10;  // a에 들어있는 minus 값을 현재 스크립트 minus에서 뺌
        }

        // 3. UI 텍스트 업데이트

        tmp.text = "Score : " + a.minus.ToString();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
