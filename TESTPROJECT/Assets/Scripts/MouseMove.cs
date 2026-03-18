using TMPro;
using UnityEngine;

public class MouseMove : MonoBehaviour
{

    int Damage;
    public TextMeshPro countText;
    float time;
    public float AttDelay;
    public float AttPower;
    void Start()
    {
        Debug.Log("hi");
    }

    
    void Update()
    {
        
    }
    private void OnMouseOver()
    {
        time = time + Time.deltaTime;
        if(time >= 2)
        {
            Damage = Damage + 1;
            time = 0;
        }
        
        countText.text = "COUNT : " + Damage.ToString();

    }

}
