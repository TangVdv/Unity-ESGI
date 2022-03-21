using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionScript : MonoBehaviour
{
    public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col) 
                                      
    {
        if (col.name == "PlayerCharacter" && healthbar.getHealth() < 100)        
        {
            healthbar.AddHealth(30);
            DestroyGameObject();
            //print("Touché");
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
