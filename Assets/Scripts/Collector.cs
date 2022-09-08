using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector :MonoBehaviour
{
    private GameObject Bag;
    private float _hight;
    public Transform carryingPoint;


    private void Start()
    {
        Bag = GameObject.FindWithTag("Bag");


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Collectable")
        {
            Debug.Log(other);
            _hight += 0.2f;

            
            
            other.gameObject.GetComponent<CollectedObject>().Gathered();
            //other.gameObject.GetComponent<CollectedObject>().SetIndex(_hight);
            other.gameObject.transform.parent = Bag.transform;
            other.gameObject.transform.position = new Vector3(carryingPoint.position.x, carryingPoint.position.y + _hight, carryingPoint.position.z);
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
            


        }
    }
}
