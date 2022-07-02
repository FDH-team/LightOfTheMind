using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_SpawnObject : MonoBehaviour
{
    [SerializeField]
    public GameObject Prefab;
    [SerializeField]
    public GameObject ObjectPos;

    [SerializeField]
    public float SpawnTime = 0.3f;

    private delegate void Checker(string Tag);
    private Checker _checker;

    private void Start()
    {
        _checker = WorkChecker;
    }

    void Spawn()
    {

        Instantiate(Prefab, ObjectPos.transform.position, Quaternion.identity, null);
    }

    private void EmptyChecker(string Tag)
    {

    }

    private void WorkChecker(string Tag)
    {
        if (Tag == "Player")
            Invoke("Spawn", SpawnTime);
        _checker = EmptyChecker;
    }

    [System.Obsolete]
    private void OnCollisionEnter(Collision collision)
    {
        _checker(collision.other.tag);
    }

    private void OnTriggerEnter(Collider other)
    {
        _checker(other.tag);
    }



}
