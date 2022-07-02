using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Rotate : MonoBehaviour
{
    [SerializeField]
    GameObject Object;
    [SerializeField]
    Vector3 Angles;
    [SerializeField]
    float TimeMultiple = 2;

    private Quaternion Target;

    private delegate void del_Update();
    private del_Update Updater;

    private void Start()
    {
        Target = Quaternion.Euler(Angles);
        Updater = EmptyUpdater;
    }

    void WorkingUpdater()
    {
        Object.transform.rotation = Quaternion.Lerp(Object.transform.rotation, Target, Time.deltaTime * TimeMultiple);
        if(Object.transform.rotation == Target)
        {
            Updater = EmptyUpdater;
        }
    }

    void EmptyUpdater()
    {

    }

    void Execute()
    {
        Updater = WorkingUpdater;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        Execute();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        Execute();
    }

    private void Update()
    {
        Updater();
    }

}
