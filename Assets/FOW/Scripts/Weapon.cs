using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] GameObject Bomb;
    [SerializeField] GameObject Mine;
    [SerializeField] GameObject Gun;
    [SerializeField] Transform GunSocket;
    [SerializeField] float ShootForce;
    [SerializeField] LayerMask LayerMask;
	Camera camera;
    GameObject[] MineList = new GameObject[2];
    int MineAmount = 0;

    // Use this for initialization
    void Start()
    {
        camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ShootBomb();
        ThrowMine();
        BoomMine();
    }

    void ShootBomb()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            if (Physics.Raycast(ray, out hit, 10000000, LayerMask))
            {
                print(hit.point);
                GunSocket.transform.LookAt(hit.point);
                GameObject Clone = Instantiate(Bomb, GunSocket.transform.position, GunSocket.transform.rotation);
                //Bomb.transform.position = GunSocket.position;
                Clone.GetComponent<Rigidbody>().AddForce(GunSocket.forward * ShootForce);
            }
            else
            {
                print(ray.direction.normalized * 1000000);
                GunSocket.transform.LookAt(ray.direction.normalized * 1000000);
                GameObject Clone = Instantiate(Bomb, GunSocket.transform.position, GunSocket.transform.rotation);
                Clone.GetComponent<Rigidbody>().AddForce(GunSocket.forward * ShootForce);
            }
        }
    }

    void ThrowMine()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift) && MineAmount < 2)
        {
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            if(Physics.Raycast(ray, out hit, 10, LayerMask))
            {
                MineList[MineAmount] = Instantiate(Mine, hit.point, Quaternion.LookRotation(hit.normal));
                MineAmount++;
            }
            
        }
    }

    void BoomMine()
    {
        if(Input.GetButtonDown("Fire2") && MineAmount>0)
        {
            Debug.Log("PressBoom");
            for (int i = 0; i < MineAmount;i++)
            {
                MineList[i].SendMessage("Boom");
            }
            MineList = new GameObject[2];
            MineAmount = 0;
        }
    }
}
