using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

//Vectro3.forward 앞쪽으로, Vector3(0.0f, 0.0f, 1.0f) 와 같은 의미
//Vectro3.back 뒤쪽으로, Vector3(0.0f, 0.0f, -1.0f) 와 같은 의미
//Vectro3.left 왼쪽으로, Vector3(-1.0f, 0.0f, 0.0f) 와 같은 의미
//Vectro3.right 오른쪽으로, Vector3(1.0f, 0.0f, 0.0f) 와 같은 의미
//Vectro3.up 위쪽으로, Vector3(0.0f, 1.0f, 0.0f) 와 같은 의미
//Vectro3.down 아래쪽으로, Vector3(0.0f, -1.0f, 0.0f) 와 같은 의미
//Vectro3.zero 모두 0으로, Vector3(0.0f, 0.0f, 0.0f) 와 같은 의미



public class jojong : MonoBehaviour
{
    public int score;
    public TextMeshPro SCORE;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ITEM"))
        {
            // 2. 점수 증가
            score += 10;
            Debug.Log("아이템 획득! 현재 점수: " + score);

            

            // 3. 아이템 오브젝트 삭제 (화면에서 사라짐)
            Destroy(other.gameObject);
            SCORE.text = "Score: " + score.ToString();
            
            // 4. (선택) 효과음 재생이나 파티클 실행 로직 추가 가능
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey (KeyCode.A))
        {
            transform.Translate(Vector3.left* 3 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 3 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * 3 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * 3 * Time.deltaTime);
        }
        
    }
}
