using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_DeleteObjects : MonoBehaviour
{
    [SerializeField]
    int LayerId;

    GameObject[] FindGameObjectsInLayer(int LayerId)
    {
        var goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        var goList = new System.Collections.Generic.List<GameObject>();
        
        for (int i = 0; i < goArray.Length; i++)
        {
                Debug.Log($"{goArray[i].name} {goArray[i].layer} == {LayerId}");
            if (goArray[i].layer == LayerId)
            {
                goList.Add(goArray[i]);
            }
        }

        if (goList.Count == 0)
        {
            return null;
        }
        return goList.ToArray();
    }

    private void Start()
    {
    }

    void Work()
    {
        GameObject[] Objects = FindGameObjectsInLayer(LayerId);

        foreach(var Obj in Objects)
        {
            if (Obj != null)
                Destroy(Obj);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Work();
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Player")
        {
            Work();
        }
    }

}
