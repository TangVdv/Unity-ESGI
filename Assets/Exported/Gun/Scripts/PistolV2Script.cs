using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolV2Script : MonoBehaviour
{
    public GameObject projectile; // on stockera le prefab Balle
    public Transform posTir; // Position de la Balle
    public float fireRate;
    private bool canFire = true;
    public float force; // puissance de tir
    public int chargeur = 10;
    public AudioClip sonDeTir; // Son de tir
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && chargeur > 0 && canFire)// qd on clique 
        {
            // Instanciation (création) du projectile
            var go = Instantiate(projectile, posTir.position, Quaternion.identity);
            // Instantiate prend comme paramètre l'objet à instancier, la position et la rotation (ici elle est nulle)
            // on a accès aux composants de go qui est un game object

            // on propulse le projectile
            go.GetComponent<Rigidbody>().AddForce(posTir.forward * force); // on applique une force au rigidbody en face
            
            Destroy(go, 60);

            // On lance le son de tir
            //GetComponent<AudioSource>().PlayOneShot(sonDeTir);

            //chargeur--;

            StartCoroutine(WaitForFire(fireRate));
        }

        if (Input.GetKey("r"))
        {
            chargeur = 10;
        }
        
    }
    
    IEnumerator WaitForFire(float time)
    {
        canFire = false;
        yield return new WaitForSeconds(time);
        canFire = true;
    }
}