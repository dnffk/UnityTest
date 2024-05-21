using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f; // 이동 속도
    int count; //점수 변수를 만들면서 초기화 해도 됨
    public TextMeshProUGUI countText; //점수 텍스트를 위한 변수 text변수 생성
    public GameObject clearPanel;//패널 오브젝트 불러오기

    void SetCount()
    {
        countText.text = "Score: " + count.ToString();//이렇게만 하면 에러가 발생한다
        if(count >= 100)
        {
            clearPanel.SetActive(true);
        }
    }
    void Start()
    {
        count = 0;
        SetCount();
        clearPanel.SetActive(false);//clear.GameObject 왜 이렇게 하지 않을까?
        //이미GameObject 형식
    }

    void Update()
    {
        // WASD 키 입력을 감지하여 이동
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Debug.Log("h = " + horizontalInput);
        //Debug.Log("v = " + verticalInput);

        //이동거리 보정
        horizontalInput = horizontalInput * moveSpeed * Time.deltaTime;
        verticalInput = verticalInput * moveSpeed * Time.deltaTime;

        //실제 이동
        //Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * horizontalInput);
        transform.Translate(Vector3.forward * horizontalInput);
    }

    //콜백 함수
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("충돌 감지");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거 감지!!");
        //Destory(other.gameObject);
        if (other.gameObject.CompareTag("item"))
        {//아이템이 없어짐과 동시에 점수를 올린다.
            other.gameObject.SetActive(false);
            count = count + 10;//10점씩 점수 추가
            SetCount();
        }
    }

    public void Restart()//버튼에 매핑할 함수는 반드시 public
    {//scene불러오기
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
