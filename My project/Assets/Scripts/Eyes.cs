using UnityEngine;

public class Eyes : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�
    public float lookSpeed = 2f; // ���� ȸ�� �ӵ�

    float verticalLookRotation = 0f;
    Transform playerBody;

    void Start()
    {
        playerBody = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // �̵� �Է� ó��
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        playerBody.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // ���콺 �Է� ó��
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // ���� ���� ȸ��
        verticalLookRotation += mouseY * lookSpeed;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        transform.localEulerAngles = new Vector3(-verticalLookRotation, 0f, 0f);

        // ���� ���� ȸ��
        playerBody.Rotate(Vector3.up * mouseX * lookSpeed);
    }
}
