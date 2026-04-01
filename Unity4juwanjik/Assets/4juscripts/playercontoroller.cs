using TMPro;
using UnityEngine;

public class playercontoroller : MonoBehaviour
{
    public TextMeshPro score;
    public TextMeshPro time;
    public int Score;
    public float tiime;
    public GameObject leftcube;
    public GameObject rightcube;
    

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector2.left * 3 * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector2.right * 3 * Time.deltaTime);

    }

    // 1. 처음 닿았을 때 (딱 1번 실행)
    
    

    private void OnTriggerEnter(Collider leftcube)
    {
        Debug.Log(leftcube.name + "에 들어왔습니다!");
        

    }



    // 2. 닿아 있는 동안 (매 프레임 실행)
    private void OnTriggerStay(Collider other)
    {

        tiime += Time.deltaTime;
        time.text = "Time:" + tiime.ToString();
        Debug.Log(other.name + "와 접촉 중...");
        if (tiime > 1.5 && other.CompareTag("leftcube"))
        {

            Score += 1;
            score.text = "score:" + Score.ToString();
        }

        if (tiime > 1.5 && other.CompareTag("rightcube"))
        {

            Score -= 1;
            score.text = "score:" + Score.ToString();
        }
    }

    
    

    // 3. 떨어졌을 때 (딱 1번 실행)
    private void OnTriggerExit(Collider other)
    {
        Score = 0;
        score.text = "score:" + Score.ToString();
        Debug.Log(other.name + "에서 나갔습니다!");
    }
}  
