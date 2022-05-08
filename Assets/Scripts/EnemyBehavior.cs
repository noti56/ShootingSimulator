using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    GeneralShoot generalShoot;
    private GameObject player;
    private GameObject playerBody;
    private GameObject gun;
    public GameObject bulletPrefab;
    [SerializeField] float shotPower = 500f;
    void Start()
    {
        var arrayPlayer = GameObject.FindGameObjectsWithTag("Player");
        if (arrayPlayer[0])
        {
            player = arrayPlayer[0];
           
        }
        if (player)
        {
            playerBody = player.transform.Find("Main Camera").transform.Find("body").gameObject;
         
        }
        var arrayGun = GameObject.FindGameObjectsWithTag("gun");
        if (arrayGun[0])
        {
            gun = arrayGun[0];
        }

        Debug.Log(gun);
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.DrawLine(playerBody.transform.position, gun.transform.position, Color.red);
        gun.transform.LookAt(playerBody.transform);
        
        gun.transform.Rotate(Vector3.up * 180);
       // gun.transform.Rotate(Vector3.bottom * 180);
        RaycastHit hitPoint;
        
        if (Physics.Raycast(gun.transform.position, gun.transform.forward * -1, out hitPoint))
        {
            Debug.Log(hitPoint.transform.name);
            if (hitPoint.transform.tag == "Player" || hitPoint.transform.name =="PlayerPrefab") {
                Debug.Log(hitPoint.transform.name);
                shoot();
            }
            

        }




    }
    void shoot()
    {
        if (bulletPrefab)
        {

            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(gun.transform.forward  * shotPower* -1);
         
        }
    }
}
