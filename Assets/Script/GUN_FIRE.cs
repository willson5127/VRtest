using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUN_FIRE : MonoBehaviour {

    //槍枝變數
    //public int ammo = 30;

    public GameObject shoot; // 匯入一個假設遊戲物件
    public GunEffect2 gunEffect; // 匯入開槍反應之物件

    public int fireDamage = 100;
    public float fireRate = 0.15f;
    public float fireRange = 100f;

    private float fireInterval;
    private string fireMode;

	// Use this for initialization
	void Start () {
        fireMode = "Auto";
	}
	
	// Update is called once per frame
	void Update () {
        //f(Input.GetKeyDown.
        switch (fireMode)
        {
            case "Simi":
                if (Input.GetMouseButtonDown(0) && Time.time > fireInterval)
                {
                    Fire();
                }
                gunEffect.UpdateLaser(fireRange);
                break;
            case "Auto":
                if (Input.GetMouseButton(0) && Time.time > fireInterval)
                {
                    Fire();
                }
                gunEffect.UpdateLaser(fireRange);
                break;
            default:
                break;
        }
	}

    void Fire()
    {

        fireInterval = Time.time + fireRate;

        //宣告一個3維向量，存放槍口的位置
        Vector3 rayOrign = shoot.transform.position;
        //宣告一個RaycastHit物件，存放射線擊中的資訊
        RaycastHit hit;

        //條件式判斷如果射線(Raycast)是否有擊中物件，如果有的話回傳擊中物件的資訊給hit
        if (Physics.Raycast(rayOrign, shoot.transform.forward, out hit, fireRange))
        {
            //hit.collider.transform.root.SendMessage("ApplyDamage", fireDamage);

            //gunEffect.HandleHit(hit);
        }

        gunEffect.GunShoot();
    }
}
