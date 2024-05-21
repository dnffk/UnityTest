using UnityEngine;

public class Eyes : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float lookSpeed = 2f; // 시점 회전 속도

    float verticalLookRotation = 0f;
    Transform playerBody;

    void Start()
    {
        playerBody = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 이동 입력 처리
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        playerBody.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // 마우스 입력 처리
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 수직 시점 회전
        verticalLookRotation += mouseY * lookSpeed;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        transform.localEulerAngles = new Vector3(-verticalLookRotation, 0f, 0f);

        // 수평 시점 회전
        playerBody.Rotate(Vector3.up * mouseX * lookSpeed);
    }
}
