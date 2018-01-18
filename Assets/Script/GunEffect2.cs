using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEffect2 : MonoBehaviour
{
    public Transform rayPoint;

    private LineRenderer line;
    private AudioSource audio;

    // Use this for initialization
    void Start()
    {
        line = GetComponent<LineRenderer>();
        audio = GetComponent<AudioSource>();
    }

    void SpawnDecal(RaycastHit hit, GameObject prefab)
    {
        GameObject spawnedDecal = GameObject.Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
        spawnedDecal.transform.SetParent(hit.collider.transform);
    }

    public void UpdateLaser(float distance)
    {
        if (line != null)
        {
            line.SetPosition(0, rayPoint.position);
            line.SetPosition(1, rayPoint.position + rayPoint.forward * distance);
        }
    }

    public void GunShoot()
    {
        //muzzleFlash.Play ();

        if (audio != null)
        {

            audio.Play();

        }
    }

}
