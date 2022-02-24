using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyActions : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
        //transform.LookAt(player);
        //transform.position += transform.forward * agent.speed * Time.deltaTime;
    }

    public void SetPlayerTransform(Transform player)
    {
        this.player = player;
    }
}


