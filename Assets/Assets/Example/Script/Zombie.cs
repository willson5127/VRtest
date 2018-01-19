using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {

	public GameObject target;
	public int maxHp = 500;

	private NavMeshAgent agent;
	private Animator anim;
	private Collider[] ragColliders;
	private AudioSource au;

	private float distance;
	private int hp;
	private bool dead;

	// Use this for initialization
	void Start () {

		target = GameObject.FindGameObjectWithTag ("Player");
		hp = maxHp;

		agent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		ragColliders = GetComponentsInChildren<Collider> ();
		au = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (dead)
			return;

		distance = Vector3.Distance (transform.position, target.transform.position);
		agent.destination = target.transform.position;

		if (distance <= agent.stoppingDistance + 0.2f) {
			anim.SetTrigger ("Attack");
		}
	}

	public void ApplyDamage(int damage)
	{
		if (dead)
			return;

		hp -= damage;

		if (hp <= 0) {
			hp = 0;

			Dead ();
		}
	}

	void Dead()
	{
		anim.SetTrigger ("Dead");
		dead = true;
		au.Play ();

		DestroyColliders ();
		DestroyAgent ();
		Destroy (gameObject, 5);
	}

	void DestroyColliders()
	{
		for (int i = 0; i < ragColliders.Length; i++) {

			Destroy (ragColliders [i]);
		}
	}

	void DestroyAgent()
	{
		agent.isStopped = true;
		Destroy (agent);
	}
}
