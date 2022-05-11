using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    GeneralShoot generalShoot;
    [SerializeField] GameObject player;
    private GameObject playerBody;
    [SerializeField] GameObject gun;
    public GameObject bulletPrefab;
    [SerializeField] int bulletsAmount = 6;
    private int bulletsAvialable = 6;
    [SerializeField] float shotPower = 500f;
    public bool isReloading = false;
    [SerializeField] int timeOfReloading = 5;
    [SerializeField] AudioClip gunShotSound;
    public AudioSource audioSource;
    




    private void OnEnable()
    {
        SimpleShoot.onShootOnEnemyEvent += killEnemy;
        PlayerContoller.OnPlayerMovementEvent += handleWeaponMovement;
    }
    private void OnDisable()
    {
        SimpleShoot.onShootOnEnemyEvent -= killEnemy;
        PlayerContoller.OnPlayerMovementEvent -= handleWeaponMovement;
    }
 
    

    private void OnDestroy()
    {
        Debug.Log("Destroyed enemy");
        SimpleShoot.onShootOnEnemyEvent -= killEnemy;
        PlayerContoller.OnPlayerMovementEvent -= handleWeaponMovement;

    }
    void Start()
    {
        bulletsAvialable = bulletsAmount;
    
        if (player)
        {
            Debug.Log(playerBody);
            playerBody = player.transform.Find("Main Camera").transform.Find("body").gameObject;
         
        }
    

        Debug.Log(playerBody);
    }

    // Update is called once per frame
    public void killEnemy(GameObject enemy) {
        Debug.Log(gameObject.GetInstanceID());
        Debug.Log(enemy.GetInstanceID());
            Destroy(enemy);
        
    }


    void handleWeaponMovement(Transform playerTransform)
    {
        playerBody = playerTransform.Find("Main Camera").transform.Find("body").gameObject;
        gun.transform.LookAt(playerTransform.transform);

        gun.transform.Rotate(Vector3.up * 180);
    }

    void Update()
    {

       
        gun.transform.LookAt(playerBody.transform);
        
        gun.transform.Rotate(Vector3.up * 180);
       // gun.transform.Rotate(Vector3.bottom * 180);
        if (bulletsAvialable > 0 )
        {

        RaycastHit hitPoint;
        if (Physics.Raycast(gun.transform.position, gun.transform.forward * -1, out hitPoint))
        {
 
            if ( hitPoint.transform.tag == "Player" || hitPoint.transform.name =="PlayerPrefab") {
                shoot();
            }
            

        }
        }
        else if (bulletsAvialable<=0)
        {
           
            
            StartCoroutine(waitForReloading());
        }




    }
    void shoot()
    {
        if (bulletPrefab)
        {
            if (gunShotSound)
            {

            AudioSource audio = GetComponent<AudioSource>();
        audio.Play();        
        audio.clip = gunShotSound;
        audio.Play();
            }
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(gun.transform.forward  * shotPower* -1);
            bulletsAvialable = bulletsAvialable -1;
            
        }
    }



    

    IEnumerator waitForReloading()
    {
        
        isReloading = true;
        yield return new WaitForSeconds(timeOfReloading);
        bulletsAvialable = bulletsAmount;
        isReloading = false ;

    }
}
