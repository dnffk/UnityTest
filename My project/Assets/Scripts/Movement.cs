using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 10f; // �̵� �ӵ�
    int count; //���� ������ ����鼭 �ʱ�ȭ �ص� ��
    public TextMeshProUGUI countText; //���� �ؽ�Ʈ�� ���� ���� text���� ����
    public GameObject clearPanel;//�г� ������Ʈ �ҷ�����

    void SetCount()
    {
        countText.text = "Score: " + count.ToString();//�̷��Ը� �ϸ� ������ �߻��Ѵ�
        if(count >= 100)
        {
            clearPanel.SetActive(true);
        }
    }
    void Start()
    {
        count = 0;
        SetCount();
        clearPanel.SetActive(false);//clear.GameObject �� �̷��� ���� ������?
        //�̹�GameObject ����
    }

    void Update()
    {
        // WASD Ű �Է��� �����Ͽ� �̵�
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Debug.Log("h = " + horizontalInput);
        //Debug.Log("v = " + verticalInput);

        //�̵��Ÿ� ����
        horizontalInput = horizontalInput * moveSpeed * Time.deltaTime;
        verticalInput = verticalInput * moveSpeed * Time.deltaTime;

        //���� �̵�
        //Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.right * horizontalInput);
        transform.Translate(Vector3.forward * horizontalInput);
    }

    //�ݹ� �Լ�
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("�浹 ����");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ʈ���� ����!!");
        //Destory(other.gameObject);
        if (other.gameObject.CompareTag("item"))
        {//�������� �������� ���ÿ� ������ �ø���.
            other.gameObject.SetActive(false);
            count = count + 10;//10���� ���� �߰�
            SetCount();
        }
    }

    public void Restart()//��ư�� ������ �Լ��� �ݵ�� public
    {//scene�ҷ�����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
