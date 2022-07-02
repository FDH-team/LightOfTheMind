using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_SoundPlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource m_AudioSource;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Playing");
            m_AudioSource.Play();
        }
    }

}
