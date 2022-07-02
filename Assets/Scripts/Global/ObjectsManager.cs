using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour
{
    static private ObjectsManager m_Instance;
    static public ObjectsManager Instance { get { return m_Instance; } }

    public Player m_Player;

    public static List<fg_Light_Instance> m_LightObjects = new List<fg_Light_Instance>();

    private void Awake()
    {
        
    }

    private void Start()
    {
        m_Instance = this;
    }

    

}
