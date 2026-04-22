using TMPro;
using UnityEngine;

public class minuscube : MonoBehaviour
{
    public pluscube targetCube;

    public TextMeshPro scoretext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnMouseDown()
        
    {
        targetCube.score -= 1;
        
        scoretext.text = "score: " + targetCube.score.ToString();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
