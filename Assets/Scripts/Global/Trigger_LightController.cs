using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_LightController : MonoBehaviour
{
    [SerializeField]
    public Color NewColor;
    [SerializeField]
    public float TimeMultiple = 7;
    [SerializeField]
    public bool m_bIsOneTime = false;

    [SerializeField]
    public string[] Tags;

    private fg_Light_Instance[] m_Lights;

    private delegate void del_OnTriggerEnter(string tag);
    private del_OnTriggerEnter _onTriggerEnter;

    private delegate void del_Update();
    private del_Update Updater;

    GameObject[] FindGameObjectsWithTags(params string[] tags)
    {
        var all = new List<GameObject>();

        foreach (string tag in tags)
        {
            all.AddRange(GameObject.FindGameObjectsWithTag(tag));
        }

        return all.ToArray();
    }

    private fg_Light_Instance[] GetLights(string[] Tags)
    {
        GameObject[] Objects = FindGameObjectsWithTags(Tags);

        List<fg_Light_Instance> Lights = new List<fg_Light_Instance>();

        foreach (GameObject obj in Objects)
        {
            Lights.Add(obj.GetComponent<fg_Light_Instance>());
        }

        return Lights.ToArray();
    }

    private void Start()
    {
        _onTriggerEnter = CollisionHandler;
        Updater = EmptyUpdate;

        m_Lights = GetLights(Tags);
    }

    public void OnEnable()
    {
        _onTriggerEnter = CollisionHandler;
    }

    private void PlayerDetected()
    {
        Updater = WorkUpdate;
    }

    private void CollisionHandler(string tag)
    {
        if (tag == "Player")
        {
            PlayerDetected();
            if (m_bIsOneTime)
            {
                _onTriggerEnter = EmptyCollisionHandler;
            }
        }
    }

    private void EmptyCollisionHandler(string tag)
    {

    }

    private void EmptyUpdate()
    {

    }

    void CheckColorAndVector()
    {

    }

    private void WorkUpdate()
    {
        foreach (fg_Light_Instance inst in m_Lights)
        {
            inst.light.color = Color.Lerp(inst.light.color, NewColor, Time.deltaTime * TimeMultiple);
        }

        if (m_Lights[m_Lights.Length - 1].light.color == (Color)NewColor)
        {
            Updater = EmptyUpdate;
        }
    }

    private void Update()
    {
        Updater();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _onTriggerEnter(collision.gameObject.tag);
    }

    private void OnTriggerEnter(Collider other)
    {
        _onTriggerEnter(other.gameObject.tag);
    }

}
