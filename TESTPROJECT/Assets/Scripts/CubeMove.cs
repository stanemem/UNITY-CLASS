using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeMove : MonoBehaviour
{

    float speed = 3.0f;
    float RndX;
    float RndY;
    float RndXpos;
    float RndYpos;
    int StartPos;

    float cubHp;
    public TextMeshPro hpText;
    public Image hp;

    void Start()
    {
        cubHp = 200f;
        hpText.text = cubHp.ToString();
        StartPos = Random.Range(0, 4);
        switch (StartPos)
        {
            case 0: // xÁÂÇ¥ (9)

                RndYpos = Random.Range(-6f, 6f);
                transform.position = new Vector2(9, RndYpos);

                RndX = Random.Range(-1f, -0.1f);
                if (RndYpos > 0) RndY = Random.Range(-1f, 0f);
                else RndY = Random.Range(1f, 0f);

                    break;
            case 1: // xÁÂÇ¥ (-9)
                RndYpos = Random.Range(-6f, 6f);
                transform.position = new Vector2(-9, RndYpos);

                RndX = Random.Range(1f, 0.1f);
                if (RndYpos > 0) RndY = Random.Range(-1f, 0f);
                else RndY = Random.Range(1f, 0f);

                break;
            case 2: // yÁÂÇ¥ (7)
                RndXpos = Random.Range(-6f, 6f);
                transform.position = new Vector2(RndXpos, 7);

                RndY = Random.Range(-1f, 0.1f);
                if (RndXpos > 0) RndX = Random.Range(-1f, 0f);
                else RndX = Random.Range(1f, 0f);

                break;
            case 3: // yÁÂÇ¥ (-7)

                RndXpos = Random.Range(-6f, 6f);
                transform.position = new Vector2(RndXpos, -7);

                RndY = Random.Range(1f, 0.1f);
                if (RndXpos > 0) RndX = Random.Range(-1f, 0f);
                else RndX = Random.Range(1f, 0f);

                break;
        }

        
        
    }


    void Update()
    {

        transform.Translate(new Vector2(RndX, RndY) * speed * Time.deltaTime);

    }
        
    private void OnTriggerExit(Collider other) //ÄÝ¶óÀÌ´õ ¹Û³ª°¡¸é »èÁ¦
    {
        if (other.CompareTag("Box")) Destroy(this.gameObject);                               
    }
    private void OnMouseOver()
    {
        Debug.Log("agag");
        //if (hpText == null || hp == null) return;

        cubHp -= 1;
        hpText.text = cubHp.ToString();
        hp.fillAmount = cubHp / 200f;

        if (cubHp <= 0)
        {
            GameManager.instance.score += 1;
            Destroy(gameObject);
        }
    }



}
