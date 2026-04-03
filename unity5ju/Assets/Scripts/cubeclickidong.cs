using UnityEngine;

public class cubeclickidong : MonoBehaviour
{
    public GameObject Player;
    private void OnMouseDown()
    {
        Player.transform.Translate(new Vector3(5, 3, 4));
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
