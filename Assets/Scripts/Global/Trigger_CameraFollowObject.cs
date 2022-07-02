using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_CameraFollowObject : MonoBehaviour
{
    [SerializeField]
    public GameObject m_CameraFollowObject;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.other.tag == "Player")
        Camera_ObjectFollow.Instance.Object = m_CameraFollowObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        Camera_ObjectFollow.Instance.Object = m_CameraFollowObject;
    }

}
