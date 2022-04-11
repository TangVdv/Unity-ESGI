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
    public NavMeshAgent agent;
    public Vector3 destination;
    public bool moving = false;
    public float change_position;
    
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

        if (!moving)
            StartCoroutine(WaitForDestination(change_position));
    }
    
    IEnumerator WaitForDestination(float time)
    {
        moving = true;
        var random = new System.Random();
        var newpositionid = random.Next(0, positions.Length);
        destination = positions[newpositionid].position;
        yield return new WaitForSeconds(time);
        moving = false;
        change_position = random.Next(0, 4);
    }
}
