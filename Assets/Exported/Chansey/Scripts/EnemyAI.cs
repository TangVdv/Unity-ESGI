using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using Debug = UnityEngine.Debug;

public class EnemyAI : MonoBehaviour
{
    public int hp_max = 100;
    public int hp = 100;
    private Rigidbody body;
    private Renderer render;
    private EnemyNav nav;
    private NavMeshAgent agent;
    private Material default_mat;
    private bool isDead = false;
    public GameObject laser;
    public GameObject model;

    public PokemonUI pokemon;

    // Start is called before the first frame update
    void Start()
    {
        laser.SetActive(false);
        body = GetComponent<Rigidbody>();
        render = model.GetComponent<Renderer>();
        nav = GetComponent<EnemyNav>();
        agent = GetComponent<NavMeshAgent>();
        default_mat = render.material;
        body.useGravity = false;
        body.isKinematic = true;
        //body.detectCollisions = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (nav.playerSpotted && !isDead)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
                    5f))
                if (hit.collider.gameObject.CompareTag("Player"))
                    laser.SetActive(true);
                else
                    laser.SetActive(false);
        }
        
        if (hp < 1 && !isDead)
        {
            body.isKinematic = false;
            body.detectCollisions = true;
            body.useGravity = true;
            nav.enabled = false;
            agent.enabled = false;
            body.AddForce(transform.forward * 5);
            laser.SetActive(false);
            pokemon.AddPokemon();


            isDead = true;
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Projectile") && !isDead)
        {
            StartCoroutine(WaitForDamage(0.1f, collider.gameObject.GetComponent<ProjectileScript>().damage));
        }
    }
    
    IEnumerator WaitForDamage(float time, int damage)
    {
        if(hp > 0)
        {
            hp -= damage;
            nav.playerSpotted = true;
            render.material.SetColor("_Color", Color.red);
            yield return new WaitForSeconds(time);
            render.material.SetColor("_Color", Color.white);
        }
    }
}
