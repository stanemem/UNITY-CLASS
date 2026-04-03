using System.Net.Sockets;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CubeCLICK : MonoBehaviour
{

    public int score;
    public TextMeshPro ScoreText;

    public void Plus()
    {
        score += 1;
    }
    public void Minus()
    {
        score -= 1;
    }
    public void Reset()
    {
        score = 0;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       ScoreText.text = "score:" + score.ToString();
    }
}

