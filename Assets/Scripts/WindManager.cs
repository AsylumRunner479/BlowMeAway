using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject self;
    public Transform waypointParent;
    private Transform[] points;
    public float waypointDistance;
    public int currentWayPoint = 1;
    public GameManager manager;
    public AudioSource[] audio;
    
    // Start is called before the first frame update
    void Start()
    {
        
        agent = self.GetComponent<UnityEngine.AI.NavMeshAgent>();
        points = waypointParent.GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

        if (manager.isPaused == false)
        {
            if (points.Length == 0)
                return;


            agent.destination = points[currentWayPoint].position;
            transform.position = Vector3.MoveTowards(transform.position, points[currentWayPoint].position, 0.25f);
            if (transform.position.x == agent.destination.x && transform.position.z == agent.destination.z)
            {
                audio[currentWayPoint].Play();
                if (currentWayPoint < points.Length - 1)
                {
                    currentWayPoint++;
                }
                else
                {
                    //resets the waypoints to the begining
                    currentWayPoint = 0;
                }

            }
        }
    }
}
