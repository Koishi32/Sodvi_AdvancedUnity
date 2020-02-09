
using UnityEngine;

public class Gun : MonoBehaviour
{

    public float fireRate=15f;
    public float damage=10f;
    public float range=100f;
    public Camera fpsCam;
    public ParticleSystem flash;
    private float nextTimeToFire=0f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time>=nextTimeToFire){
            nextTimeToFire=Time.time+1f/fireRate;
            Shoot();
        }
    }

    void Shoot(){
        flash.Play();
        RaycastHit hit;
       if( Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hit,range)){
           Debug.Log(hit.transform.name);
           
           Enemy enemy= hit.transform.GetComponent<Enemy>();
           if(enemy!=null){
               enemy.TakeDamage(damage);
           }
           SimpleLife destruible=hit.transform.GetComponent<SimpleLife>();
           if (destruible!=null){
               destruible.TakeDamage(damage);
           }
       }
    }
}
