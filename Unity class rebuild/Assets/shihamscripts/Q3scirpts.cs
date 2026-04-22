using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 버튼 제어를 위해 추가

public class Q3scirpts : MonoBehaviour
{
    private bool is_goal = false;
    private float power = 0f;
    private Rigidbody rb;
    public float POWERPLUS = 1000.0f;
    public TextMeshProUGUI wintext;

    // --- 추가된 변수 ---
    public GameObject restartButton;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (wintext != null)
        {
            wintext.text = "";
        }

        // --- 시작 시 버튼 비활성화 ---
        if (restartButton != null)
        {
            restartButton.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            power += POWERPLUS * Time.deltaTime;
        }

        if (Input.GetMouseButtonUp(0))
        {
            rb.AddForce(new Vector3(power, power, 0));
            power = 0f;
        }

        if (this.transform.position.y < -5.0f)
        {
            SceneManager.LoadScene("basketball");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("goal"))
        {
            is_goal = true;
            wintext.text = "WIN!!!";
            Debug.Log("골인 성공!");

            // --- 골인 시 버튼 활성화 ---
            if (restartButton != null)
            {
                restartButton.SetActive(true);
            }
        }
    }

    // --- 버튼을 눌렀을 때 실행될 함수 ---
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("basketball");
    }

    void OnMouseDown()
    {
        Debug.Log("마우스 눌렀음!");
        GetComponent<Renderer>().material.color = Color.red;
    }

    void OnMouseUp()
    {
        Debug.Log("마우스 뗐음!");
        GetComponent<Renderer>().material.color = Color.white;
    }
}