using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Class_GunShoot : MonoBehaviour {

	public GameObject shoot; //宣告一個存放槍口的遊戲物件
	public GunEffect effect; //宣告一個程式，放置槍擊效果腳本

	public float fireRate = 0.25f; //宣告一個浮點數，作為槍開火的間隔
	public float fireRange =  20; //宣告一個浮點數，作為槍射擊的距離
	public int fireDamage = 100; //宣告一個整數，作為槍的攻擊力

	private float fireInterval; //宣告一個浮點數，紀錄開火的間隔

	void Update()
	{
		//這邊處理槍開火的程序
		//條件式(if)判斷玩家有沒有按下滑鼠左鍵，以及確認槍開火的間隔
		if (Input.GetMouseButtonDown(0) && Time.time > fireInterval) {

			//刷新槍的開火間隔
			fireInterval = Time.time + fireRate;

			//宣告一個3維向量，存放槍口的位置
			Vector3 rayOrign = shoot.transform.position;
			//宣告一個RaycastHit物件，存放射線擊中的資訊
			RaycastHit hit;

			//條件式判斷如果射線(Raycast)是否有擊中物件，如果有的話回傳擊中物件的資訊給hit
			if (Physics.Raycast (rayOrign, shoot.transform.forward, out hit, fireRange)) {

				//對擊中的物件傳送訊息"ApplyDamage"，並附帶一個槍的傷害值
				//root會指向遊戲物件層級的母物件
				hit.collider.transform.root.SendMessage ("ApplyDamage", fireDamage);

				//執行GunEffect程式的HandleHit功能，並輸入擊中物件的資訊
				effect.HandleHit (hit);
			}

			//執行GunEffect程式的GunShoot功能，撥放槍擊的聲音
			effect.GunShoot ();
		}

		//不斷更新雷射線的位置
		effect.UpdateLaser( fireRange );
	}
}
