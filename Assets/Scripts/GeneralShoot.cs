using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GeneralShoot instance;
    public GameObject gun;
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public GameObject bulletHolePrefab;
    [SerializeField] AudioClip gunShotSound;
    AudioSource audioSource;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
