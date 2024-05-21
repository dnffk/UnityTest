using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour //파일의 이름과 클래스 이름은 반드시 같아야 합니다.
{
    // Start is called before the first frame update
    void Start()
    {
        //초기화
        Debug.Log("Hello World!!");
        //한 번만 호출
    }

    // Update is called once per frame
    void Update()
    {
        //실시간 호출
        Debug.Log("Update!!");
        
    }
}
