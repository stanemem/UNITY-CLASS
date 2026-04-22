using TMPro;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed = 3f;
    private Vector3 moveDir = Vector3.up;
    public int sccore = 0;
    public TextMeshPro scoore;

    void Update()
    {
        transform.Translate(moveDir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cuub1"))
        {
            moveDir = Vector3.left;
            Debug.Log("왼쪽으로 90도 꺾음");
            sccore += 1;
            scoore.text = "Score : " + sccore.ToString();

        }
        else if (other.CompareTag("cuub2"))
        {
            moveDir = Vector3.down;
            Debug.Log("아래로 90도 꺾음");
            sccore += 1;
            scoore.text = "Score : " + sccore.ToString();
        }
        else if (other.CompareTag("cuub3"))
        {
            moveDir = Vector3.right;
            Debug.Log("오른쪽으로 90도 꺾음");
            sccore += 1;
            scoore.text = "Score : " + sccore.ToString();
        }
    }
}