using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_FallObjects : MonoBehaviour
{

    private delegate void Checker(string Tag);
    private Checker _checker;

    private delegate void Updater();
    private Updater updater;
    
    [SerializeField]
    private GameObject _Target;
    [SerializeField]
    private Vector3 _NewPos;

    private void Start()
    {
        _checker = WorkChecker;
        updater = EmptyUpdater;
    }

    private void EmptyUpdater()
    {

    }

    private void WorkingUpdater()
    {
        _Target.transform.position = Vector3.Lerp(_Target.transform.position, _NewPos, Time.deltaTime);

        if (_Target.transform.position == _NewPos) updater = EmptyUpdater;
    }

    private void EmptyChecker(string Tag)
    {

    }

    private void WorkChecker(string Tag)
    {
        if (Tag == "Player")
        {
            _checker = EmptyChecker;
            updater = WorkingUpdater;
        }
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

    private void Update()
    {
        updater();
    }
}
