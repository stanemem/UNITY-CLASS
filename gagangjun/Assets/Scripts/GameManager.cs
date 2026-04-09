using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject cube;
    public GameObject touchToStart;
    public TextMeshProUGUI scoreText;
    public int score;
    float _time;
    bool isStart = false;
    bool isReady = true;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        StartCoroutine("tts");
        touchToStart.SetActive(false);



    }
    IEnumerator tts()
    {
        while (true)
        {
            Debug.Log("작동");
            touchToStart.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            touchToStart.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }

    }
    void MakeCube()
    {
        Instantiate(cube, new Vector2(0, 0), Quaternion.identity);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("누름");
            StopCoroutine("tts");
            touchToStart.SetActive(false);
            isStart = true;
        }
        
        if (isStart && isReady)
        {
            InvokeRepeating("MakeCube", 1f, 1f);
            isReady = false;
        }
        
        
        
    }
}