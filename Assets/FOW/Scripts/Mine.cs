using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

    [SerializeField]GameObject Effect;
    [SerializeField] LayerMask layerMask;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Boom()
	{
        Collider[] Hit = Physics.OverlapSphere(transform.position, 5, layerMask);
		if(Hit.Length>0)
		{
			for (int i = 0; i < Hit.Length; i++)
			{
                    print(Hit[i].name);
                Hit[i].GetComponent<Rigidbody>().velocity += transform.up * 10000;
            }
		}
        Instantiate(Effect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
