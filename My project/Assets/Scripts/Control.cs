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
    void lateUpdate()//플레이어가 먼저 움진인 후에 카메라 update가 호출되어야 한다
    {
        transform.position = player.transform.position + offset;
    }
}
