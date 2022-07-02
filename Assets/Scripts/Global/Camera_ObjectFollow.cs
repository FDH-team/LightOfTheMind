using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_ObjectFollow : MonoBehaviour
{
    [SerializeField]
    public GameObject Object;

    static private Camera_ObjectFollow m_Instance;
    static  public Camera_ObjectFollow Instance { get { return m_Instance; } }

    void Start()
    {
        m_Instance = this;
        Object = ObjectsManager.Instance.m_Player.gameObject;
    }

    void Update()
    {
        Vector2 NewPos2 = Vector2.Lerp(transform.position, Object.transform.position, Time.deltaTime * 4);
        transform.transform.position = new Vector3(NewPos2.x, NewPos2.y, -10);
    }
}
