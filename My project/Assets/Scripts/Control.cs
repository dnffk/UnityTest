using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void lateUpdate()//�÷��̾ ���� ������ �Ŀ� ī�޶� update�� ȣ��Ǿ�� �Ѵ�
    {
        transform.position = player.transform.position + offset;
    }
}
