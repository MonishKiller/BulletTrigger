using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pistol : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public GameObject muzzleFlashprefab;
    public Transform muzzlePoint;
    public float startTimeBtwShots;


    public AudioSource audioSource;
    public AudioClip[] bulletSounds;

    private bool shot;
    private float timeBtwShots;
    private bool destroy = false;


    //Ammo
    public int ammo;
    private int currentAmmo;
    private bool outOfAmmo;
    public bool refilled;
    public bool selectedPistol = false;

    //rootTag
    private string player_root_tag;

    //bounce 
    private int bounce_Times;
    //Ammo
    [SerializeField] private Text ammoText;
    [SerializeField] private Text bounceText;

    //
    [SerializeField] private Material AmmoMat;
    [SerializeField] private Material DefaultMat;

    // Start is called once per frame
    private void Start()
    {
        outOfAmmo = false;
        currentAmmo = ammo;
        player_root_tag = this.gameObject.transform.root.tag;
        timeBtwShots = startTimeBtwShots;
      

    }
    // Update is called once per frame

    public void ChangeColor() {
        this.gameObject.transform.root.GetComponent<MeshRenderer>().material = AmmoMat;
    }
    void Update()
    {
        if (player_root_tag != "0" && refilled == false && selectedPistol)
        {
            Debug.Log("Check");
            AmmoRefill();
        }
        if (selectedPistol)
        {
            BounceCheck();
            ShootCheck();
            ammoText.text = "Ammo : " + currentAmmo;
            bounceText.text = "Bounce : " + bounce_Times;
        }
        


    }
    public void AmmoRefill() {
        if (currentAmmo <= 0)
        {
            currentAmmo = ammo;
            ammo = 0;
            
        }
        refilled = true;

    }
 
    private void MuzzleFlash()
    {

        GameObject MuzzleFlashEffect = Instantiate(muzzleFlashprefab, muzzlePoint.position, muzzlePoint.rotation);
        Destroy(MuzzleFlashEffect, 1f);

    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Bullet_PrefabRifle>().playerTag = this.transform.root.tag;
        bullet.GetComponent<Bullet_PrefabRifle>().bounce = bounce_Times;
        audioSource.clip = bulletSounds[Random.Range(0, bulletSounds.Length)];
        audioSource.Play();


    }
    private void BounceCheck() {
        if (Input.GetMouseButtonDown(1) && selectedPistol && !outOfAmmo) {
            if (bounce_Times > 1)
            {
                bounce_Times = 0;
            }
            else
            {
                bounce_Times++;
                Debug.Log(bounce_Times);
            }

        }


    }
    public void ShootCheck()
    {
       if (timeBtwShots <= 0)
            {
                if (currentAmmo == 0)
                {
                    outOfAmmo = true;

                }
                else
                {
                    outOfAmmo = false;
                }

                if (Input.GetMouseButtonDown(0) && selectedPistol == true && !outOfAmmo)
                {
                    currentAmmo--;
                    if(currentAmmo<=0)
                     this.gameObject.transform.root.GetComponent<MeshRenderer>().material = DefaultMat;
                     Shoot();
                    //MuzzleFlash();
                    timeBtwShots = startTimeBtwShots;

                }

            }
            else
                timeBtwShots -= Time.deltaTime;
        

    }
    
} 
   

