using UnityEngine;
//Input.GetKeyDown
//: 키를 누르고 있으면 실행
//Input.GetKeyDown
//: 키를 누를때 실행
//Input.GetKeyUp
//: 키를 누른 후 떼는 순간 실행
//Input.GetMouseButton(n)
//: 마우스 버튼을 누르고 있으면 실행
//Input. GetMouseButtonDown(n)
//: 마우스 버튼을 누를때 실행
//Input. GetMouseButtonUp(n)
//: 마우스 버튼을 떼는 순간 실행
//(n) 0,1,2 숫자로 표시
//1 : 마우스 왼쪽버튼,
//2: 마우스 오른쪽 버튼
//3 : 마우스 휠 버튼
//OnMouseDown() : 마우스 클릭 시 실행
//OnMouseDrag() : 오브젝트 드래그 동안 실행
//OnMouseEnter() : 오브젝트에 진입 시 한번 실행
//OnMouseExit() : 오브젝트에서 빠져나갈 때 실행
//OnMouseOver() : 오브젝트 위에 있을 동안 실행
//OnMouseUp() : 마우스 클릭 후 떼는 순간 실행

//차이 전역 감지와 오브젝트 감지

//큐브클릭후 다시나타나게
public class ClickCubeAC : MonoBehaviour
{
    public GameObject missingcube;
    bool isActive = true;

    private void OnMouseDown()
    {
        // 1. 상태 반전
        isActive = !isActive;

        // 2. 적용
        if (missingcube != null)
        {
            missingcube.SetActive(isActive);
        }

        Debug.Log("클릭됨! 현재 상태: " + isActive);
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
