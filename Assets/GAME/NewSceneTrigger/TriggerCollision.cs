using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollision : MonoBehaviour
{
    // Trigger = boite de collision ou collider 
    public string sceneName;
    public GameObject triggerZone;
    public Material material;
    private Collider triggerCollider;

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "PlayerCharacter")
        {
            Application.LoadLevel(sceneName);
        }
    }

    public void TriggerIsActive(string name)
    {
        if(triggerZone.name == name)
        {
            triggerCollider = GetComponent<Collider>();
            triggerCollider.isTrigger = true;
            triggerZone.GetComponent<Renderer>().material = material;
        }
    }

}