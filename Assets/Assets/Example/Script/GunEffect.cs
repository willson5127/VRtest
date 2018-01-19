using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffect : MonoBehaviour {

	public ParticleSystem muzzleFlash;
	public Transform rayPoint;

	private LineRenderer line;
	private AudioSource au;

	public GameObject metalHitEffect;
	public GameObject sandHitEffect;
	public GameObject stoneHitEffect;
	public GameObject waterLeakEffect;
	public GameObject[] fleshHitEffects;
	public GameObject woodHitEffect;

	void Start()
	{
		line = GetComponent<LineRenderer> ();
		au = GetComponent<AudioSource> ();
	}

	public void UpdateLaser(float distance)
	{
		if (line != null) {
			line.SetPosition( 0, rayPoint.position );
			line.SetPosition( 1, rayPoint.position + rayPoint.forward * distance );
		}

	}

	public void HandleHit(RaycastHit hit)
	{
		if(hit.collider != null)
		{
			string hitTag = hit.collider.tag;

			switch(hitTag)
			{
			case "Metal":
				SpawnDecal(hit, metalHitEffect);
				break;
			case "Sand":
				SpawnDecal(hit, sandHitEffect);
				break;
			case  "Stone":
				SpawnDecal(hit, stoneHitEffect);
				break;
			case "WaterFilled":
				SpawnDecal(hit, waterLeakEffect);
				SpawnDecal(hit, metalHitEffect);
				break;
			case "Wood":
				SpawnDecal(hit, woodHitEffect);
				break;
			case "Meat":
				SpawnDecal(hit, fleshHitEffects[Random.Range(0, fleshHitEffects.Length)]);
				break;
			case "Player":
				SpawnDecal(hit, fleshHitEffects[Random.Range(0, fleshHitEffects.Length)]);
				break;
			}
		}
	}

	void SpawnDecal(RaycastHit hit, GameObject prefab)
	{
		GameObject spawnedDecal = GameObject.Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
		spawnedDecal.transform.SetParent(hit.collider.transform);
	}

	public void GunShoot()
	{
		muzzleFlash.Play ();

		if (au != null) {

			au.Play ();

		}
	}
}
