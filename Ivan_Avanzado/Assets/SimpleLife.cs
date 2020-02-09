
using UnityEngine;

public class SimpleLife : MonoBehaviour
{
    public float health=20f;
    public void TakeDamage(float amount){
        health-=amount;
        if (health<=0f){
            Destroy(gameObject);
        }

    }
}
