using UnityEngine;

public class Player : MonoBehaviour   // Player 클래스
{
    public float speed;               // float 자료형 변수
    public GameObject item;           // GameObject 객체를 가리키는 참조 변수
    public GameObject item2;
    public GameObject Downhwa;
    public GameObject Wehwa;// GameObject 객체를 가리키는 참조 변수

    void Start()                      // Start() : Player 클래스의 인스턴스 메서드
    {
        transform.position = Vector3.zero;
        // transform : 이 Player 객체가 가지고 있는 Transform 객체
        // position : Transform 객체의 위치 값
        // Vector3.zero : (0, 0, 0) 값을 가지는 Vector3
    }

    void Update()                     // Update() : Player 클래스의 인스턴스 메서드
    {
        if (Input.GetKey(KeyCode.LeftArrow))   // Input.GetKey() : Input 클래스의 static 메서드
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        // transform : Player 객체의 Transform 객체
        // Translate() : Transform 객체의 인스턴스 메서드

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        // Translate() : Transform 객체의 인스턴스 메서드

        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        // Translate() : Transform 객체의 인스턴스 메서드

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        // Translate() : Transform 객체의 인스턴스 메서드

        // if (Vector3.Distance(transform.position, item.transform.position) < 1f)
        // {
        //     item.SetActive(false);
        // }
        // item : GameObject 객체
        // item.transform : item 객체가 가진 Transform 객체
        // SetActive(false) : GameObject 객체의 인스턴스 메서드
    }
}