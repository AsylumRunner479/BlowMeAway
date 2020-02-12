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
        for (int i = 0; i < audio.Length; i++)
        {
            audio[i].Play();
            audio[i].volume = 0;
        }
        audio[0].volume = 100;

    }

    // Update is called once per frame
    void Update()
    {
        if (Score.CurWalls/Score.MaxWalls <= 1)
        {
            audio[1].volume = 100;
        }
        if (Score.CurWalls / Score.MaxWalls <= 0.8)
        {
            audio[2].volume = 100;
        }
        if (Score.CurWalls / Score.MaxWalls <= 0.6)
        {
            audio[3].volume = 100;
        }
        if (Score.CurWalls / Score.MaxWalls <= 0.4)
        {
            audio[4].volume = 100;
        }
        if (Score.CurWalls / Score.MaxWalls <= 0.2)
        {
            audio[5].volume = 100;
        }
        if (Score.CurWalls / Score.MaxWalls >= 0.8)
        {
            audio[2].volume = 0;
        }
        if (Score.CurWalls / Score.MaxWalls >= 0.6)
        {
            audio[3].volume = 0;
        }
        if (Score.CurWalls / Score.MaxWalls >= 0.4)
        {
            audio[4].volume = 0;
        }
        if (Score.CurWalls / Score.MaxWalls >= 0.2)
        {
            audio[5].volume = 0;
        }
        if (manager.isPaused == false)
        {
            if (points.Length == 0)
                return;


            agent.destination = points[currentWayPoint].position;
            transform.position = Vector3.MoveTowards(transform.position, points[currentWayPoint].position, 0.25f);
            if (transform.position.x == agent.destination.x && transform.position.z == agent.destination.z)
            {
                audio[currentWayPoint].volume = 100;
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
