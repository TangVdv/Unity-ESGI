using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNav : MonoBehaviour
{
    public Transform[] positions;
    public GameObject player;
    private NavMeshAgent agent;
    public Vector3 destination;
    public bool moving = false;
    public float change_position;
    public bool playerSpotted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        change_position = 0;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(destination);

        if (!moving && !playerSpotted)
            StartCoroutine(WaitForDestination(change_position));
        else if (playerSpotted)
            destination = player.transform.position;
    }

    private void FixedUpdate()
    {
        if (!playerSpotted)
        {
            // https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,
                    25f))
                if(hit.collider.gameObject != null)
                    Debug.Log("" + hit.collider.gameObject.name);
                    if (hit.collider.gameObject.CompareTag("Player"))
                     playerSpotted = true;
        }
    }

    IEnumerator WaitForDestination(float time)
    {
        moving = true;
        var newpositionid = UnityEngine.Random.Range(0, positions.Length);
        destination = positions[newpositionid].position;
        yield return new WaitForSeconds(time);
        moving = false;
        change_position = UnityEngine.Random.Range(0, 6);
    }
}
