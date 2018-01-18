using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleBomb : MonoBehaviour {

    [SerializeField] float TimeToBoom;
    [SerializeField] GameObject Effect;
    float Timer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Timer += Time.deltaTime;
		if(Timer > TimeToBoom)
		{
            GameObject clone = Instantiate(Effect);
            clone.transform.position = transform.position;
            Destroy(gameObject);
        }
    }
}
