using UnityEngine.UI;
using UnityEngine;

public class CharacterHealt : MonoBehaviour
{
    public Image lifeBar;
    public float health=50f;
    private float maxLHealth;
    // Start is called before the first frame update
    void Start()
    {   
        maxLHealth=health;
    }

    public void TakeDamage(float amount){
        health-=amount;
        lifeBar.fillAmount=health/maxLHealth;
        if (health<=0f){
            Debug.Log("You Died");
        }

    }

}
