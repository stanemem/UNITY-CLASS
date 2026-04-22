using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gyoarrow : MonoBehaviour
{
    bool isFire = false;
    bool isStart = true;
    Vector3 startpos;
    int score;
    int count;
    public TextMeshPro counttext;
    public TextMeshPro scoretext;
    public GameObject restartBtn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        restartBtn.SetActive(false);
        startpos = transform.position;
        count = 10;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counttext.text = "Count: " + count.ToString();
        if (!isStart) return;
        scoretext.text ="Score: " + score.ToString();
        if (isFire) transform.Translate(Vector3.right * 8 * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space)) isFire = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("12")) score += 12;
        if (other.CompareTag("10")) score += 10;
        if (other.CompareTag("6")) score += 8;
        if (other.CompareTag("4")) score += 4;
        if (other.CompareTag("1")) score += 1;

        count -= 1;

        transform.position = startpos;
        isFire = false;
        if (count == 0) gameover();
    }

    void gameover()
    {
        isStart = false;
        restartBtn.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene("arrowgame");
    }
}
