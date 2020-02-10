using UnityEngine.UI;
using UnityEngine;

public class CharacterHealt : MonoBehaviour
{
    public Image lifeBar;
    public float health=50f;
    private float maxLHealth;
    public Transform pos_ini;
    // Start is called before the first frame update
    void Start()
    {   
        maxLHealth=health;
        //pos_ini = this.transform.position;
    }
    private void Update()
    {
        if (this.transform.position.y < -50 || health <= 1f)
        {
            resert();
        }
    }
    public void TakeDamage(float amount){
        health-=amount;
        lifeBar.fillAmount=health/maxLHealth;

    }
    public void resert()
    {
        health = maxLHealth;
        lifeBar.fillAmount = 100;
        this.transform.position = pos_ini.position;
    }

}
