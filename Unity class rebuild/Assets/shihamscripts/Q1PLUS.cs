using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Q1PLUS : MonoBehaviour
{
    int count;
    public TextMeshPro CCOUNTL;


    private void OnCollisionEnter(Collision collision)//콜라이전 -트리거X
                                                      //TRIGGER - 트리거O
    {

    if (collision.collider.CompareTag("Q1PLUS")) count += 1;
        CCOUNTL.text = "Score: " + count.ToString();
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
