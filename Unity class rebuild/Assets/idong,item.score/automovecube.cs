using TMPro;
using UnityEngine;

public class automovecube : MonoBehaviour
{
    public GameObject player;
    public TextMeshPro SCORE; // 3D TextMeshPro용 (UI용이라면 TextMeshProUGUI로 변경)
    public GameObject Movecube; // jojong 스크립트가 붙어있는 오브젝트
    public float moveSpeed = 10f;

    private bool isHover = false;

    private void OnMouseEnter()
    {
        isHover = true;
        Debug.Log(gameObject.name + " 진입!");

        
            // 1. jojong 스크립트를 가져와서 변수 값을 읽어옵니다.
            int currentScore = Movecube.GetComponent<jojong>().score;
        currentScore += 5;
            // 2. 가져온 값을 텍스트에 적용합니다.
            SCORE.text = "Score: " + currentScore.ToString();
        
    }

    private void OnMouseExit()
    {
        isHover = false;
    }

    void Update()
    {
        if (isHover && player != null)
        {
            Vector3 targetPos = new Vector3(transform.position.x, player.transform.position.y, player.transform.position.z);
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, moveSpeed * Time.deltaTime);
        }
    }
}