using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float fireRate=20f;
    private float nextTimeToFire=0f;
    [Range(0.0f,1.0f)]
    public float AttackProbability=0.5f;
    public float DamagePoints=10;
    bool enemy=false;
    public Vector3 extBox;
    public float health=50f;
    private float maxLHealth;
    public LayerMask playerMask;
    Patrol navAgent;
    public CharacterHealt player;
        public Image lifeBar;
    private void Awake() {
        navAgent=transform.GetComponent<Patrol>();
        maxLHealth=health;
    }
    public void TakeDamage(float amount){
        health-=amount;
        lifeBar.fillAmount=health/maxLHealth;
        if (health<=0f){
            Destroy(gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        enemy= Physics.CheckBox(transform.position,extBox,Quaternion.identity,playerMask);
        navAgent.enNearby=enemy;
        if (enemy&& Time.time>=nextTimeToFire && navAgent.agent.velocity.magnitude==0){
            nextTimeToFire=Time.time+1f/fireRate;
            float random= Random.Range(0.0f,1.0f);
            if (random>(1.0f-AttackProbability)){
                player.TakeDamage(DamagePoints);
            }
        }
    }
}
