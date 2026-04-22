using TMPro;
using UnityEngine;

public class pluscube : MonoBehaviour
{
    public int score;
    public TextMeshPro scoretext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnMouseDown()
    {
        scoretext.text = "score: " + score.ToString();
        score += 1;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
