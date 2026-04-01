using TMPro;
using UnityEngine;

public class TextEx : MonoBehaviour
{
    public TextMeshPro textMeshPro;
    public TextMesh textMesh;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshPro.text = "TEXTMESHPRO";
        textMesh.text = "TEXTMESH";
        textMesh.fontSize = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
