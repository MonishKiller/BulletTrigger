using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_PrefabRifle : MonoBehaviour
{
    private Rigidbody rigidbody;
    
    [Range(5, 100)]
    [Tooltip("After how long time should the bullet prefab be destroyed?")]
    public float destroyAfter;
    [Tooltip("If enabled the bullet destroys on impact")]
    public bool destroyOnImpact = false;
    [Tooltip("Minimum time after impact that the bullet is destroyed")]
    public float minDestroyTime;
    [Tooltip("Maximum time after impact that the bullet is destroyed")]
    public float maxDestroyTime;
    private float speed=25f;


    public string playerTag;
    public int bounce;
    private int totalBounce; 
    private void Start()
    {
        //Start destroy timer
        StartCoroutine(DestroyAfter());
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
        totalBounce = bounce;
        
    }
    private void Update()
    {
        // rigidbody.velocity = this.transform.forward * 20f;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
       
    }
    //If the bullet collides with anything
    private void OnCollisionEnter(Collision other)
    {
        //If destroy on impact is false, start 
        //coroutine with random destroy timer
        if (!destroyOnImpact)
        {
            StartCoroutine(DestroyTimer());
        }
        //Otherwise, destroy bullet on impact
        else
        {
            Destroy(gameObject);
        }
        if (other.transform.tag == "Wall") {

            if (bounce <= 0)
            {
                Destroy(gameObject);
            }
            else { 
                Debug.Log("Hit_Wall");
                Vector3 v = Vector3.Reflect(transform.forward, other.contacts[0].normal);
                float rot = 90 - Mathf.Atan2(v.z, v.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0, rot, 0);
                bounce--;
            }
            

        }
        if (other.transform.tag == "Enemy") {
            int damage = 10;
            totalBounce -= bounce;
            Mathf.Abs(totalBounce);
            damage += totalBounce*damage;
            
            Debug.Log(damage);
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
            Destroy(gameObject);
        }
        if (other.transform.tag !=playerTag && other.transform.tag!="Wall" && other.transform.tag !="Enemy") {
            int ammo = 2;
            Debug.Log(bounce + " Bounce");
            totalBounce -= bounce;
            Mathf.Abs(totalBounce);
            Debug.Log(totalBounce + "TotalcBounce");
            ammo += totalBounce * ammo;
            Debug.Log(ammo + "    sdsdsd");
            other.gameObject.GetComponentInChildren<Pistol>().ammo+=ammo;
            other.gameObject.GetComponentInChildren<Pistol>().ChangeColor();
            Destroy(gameObject);

        }

       
    }

    private IEnumerator DestroyTimer()
    {
        //Wait random time based on min and max values
        yield return new WaitForSeconds
            (Random.Range(minDestroyTime, maxDestroyTime));
        //Destroy bullet object
        Destroy(gameObject);
    }

    private IEnumerator DestroyAfter()
    {
        //Wait for set amount of time
        yield return new WaitForSeconds(destroyAfter);
        //Destroy bullet object
        Destroy(gameObject);
    }
}
