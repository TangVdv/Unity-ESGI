using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public GameObject blast;
    private float radius_value;
    
    // Start is called before the first frame update
    void Start()
    {
        radius_value = GetComponent<SphereCollider>().radius;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Explode()
    {
        StartCoroutine(WaitInExplosion(0.000001f, 0.5f));
        if (radius_value > 5)
            Destroy(this.gameObject);
    }

    IEnumerator WaitInExplosion(float time, float radius)
    {
        blast.transform.localScale += new Vector3(radius,radius,radius);
        Renderer rend = blast.GetComponent<Renderer>();
        rend.material = Resources.Load<Material>("red");
        radius_value += radius;
        yield return new WaitForSeconds(time);
        Explode();
    }

    public void OnCollisionEnter(Collision collider)
    {
        if (!collider.gameObject.CompareTag("Player") 
            && !collider.gameObject.CompareTag("Projectile") 
            && !collider.gameObject.CompareTag("Projectile_Damage"))
            Explode();
    }
}
