using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class cubeclick : MonoBehaviour
{
    public int plus;
    public int minus;
    public TextMesh tm;
    public TextMeshPro tmp;
    public GameObject Wehwa;
    public GameObject Downhwa;

    int score = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tm.text = "Score : " + score.ToString();
        tmp.text = "Score : " + score.ToString();
    }
    public void OnMouseDown()
    {



        plus++;
        minus--;
        tm.text = "Score : " + plus.ToString();
        tmp.text = "Score : " + minus.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
    

