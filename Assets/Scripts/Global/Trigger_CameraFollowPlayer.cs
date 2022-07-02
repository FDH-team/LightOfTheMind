using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_CameraFollowPlayer : MonoBehaviour
{
    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.tag == "Player")
            Camera_ObjectFollow.Instance.Object = ObjectsManager.Instance.m_Player.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        Camera_ObjectFollow.Instance.Object = ObjectsManager.Instance.m_Player.gameObject;
    }
}
