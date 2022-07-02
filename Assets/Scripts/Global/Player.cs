using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float JumpForce = 3.0f;
    [SerializeField]
    public float Speed = 2.0f;

    [SerializeField]
    private bool m_bCanJump = true;

    private Rigidbody m_Rigidbody;


    void Start()
    {
        if (ObjectsManager.Instance.m_Player != null)
        {
            enabled = false;
            Debug.LogError("Working only with one player");
            return;
        }

        ObjectsManager.Instance.m_Player = this;

        m_Rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");

        Vector3 tmp = new Vector3(Horizontal, 0, 0);
        m_Rigidbody.AddForce(tmp * Speed, ForceMode.Acceleration);

        if ((Input.GetAxis("Jump") > 0) && m_bCanJump)
        {
            m_Rigidbody.AddForce(Vector2.up * JumpForce, ForceMode.Impulse);
            m_bCanJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground") m_bCanJump = true;
    }

}
