using JetBrains.Annotations;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Test Scene");
    }

    public void changeScene()
    {
       
        SceneManager.LoadScene("Test Scene");
        
    }
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
