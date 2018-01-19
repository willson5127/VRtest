using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawn : MonoBehaviour {

	private GameObject[] spawners; //宣告一個存放遊戲物件的陣列
	public GameObject enemy; //宣告一個存放敵人的遊戲物件

	private float spawnInterval; //宣告一個浮點數，作為每個敵人生成的間隔時間

	// Use this for initialization
	void Start () {
		
		//將這個陣列裝滿標籤(Tag)為"Spawner"的遊戲物件
		spawners = GameObject.FindGameObjectsWithTag ("Spawner"); 
	}
	
	// Update is called once per frame
	void Update () {

		//這邊做一個計時裝置，讓敵人不會像爆炸一樣產生
		if (Time.time > spawnInterval) {

			SpawnEnemy ();

			//當遊戲時間大於間格，spawnInterval會把現在的遊戲時間加上一個亂數(3~5秒)，形成一個新的時間間格
			spawnInterval = Time.time + Random.Range (3.0f, 5.0f);
		}

	}

	//實作一個生成敵人的方法
	void SpawnEnemy()
	{
		//這邊是亂數選出要由哪一個Spawner生成敵人
		int id = Random.Range (0, spawners.Length);

		//Instantiate是Unity生成物件的方法，這邊是生成一個enemy存放的遊戲物件，而他的位置和方向則由亂數選出的spawners決定
		GameObject zombie = Instantiate (enemy, Vector3.zero, Quaternion.identity);
		//抓取Zombie物件身上的NavMeshAgent組件，將位置移動到Spawners上
		zombie.GetComponent<NavMeshAgent>().Warp( spawners[ id ].transform.position );
	}
}
