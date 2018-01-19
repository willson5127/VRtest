using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    [SerializeField]
    float TimeToBoom;
    [SerializeField]
    GameObject Effect;
    SphereCollider collider;
    float Timer;

    // Use this for initialization
    void Start()
    {
        collider = GetComponentInChildren<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        OnTriggerEnter(collider);
        if (Timer > TimeToBoom)
        {
            print("miss");
            Destroy(this.gameObject);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.gameObject.tag == "Metal")
            Destroy(this.gameObject);
    }
}
