using System.Collections;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class Stalk : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    private IsInTheArea IsArea;
    public float distance;
    private Animator anim;
    
    
    
    
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        IsArea = player.GetComponent<IsInTheArea>();
        anim = GetComponent<Animator>();

        StartWandering();
    }

    void Update()
    {
        if (IsArea.cs)
        {
            ChasePlayer();
        }

        if (agent.remainingDistance <= agent.stoppingDistance || !agent.hasPath) SetRandomDestination();
    }
    
    void StartWandering()
    {
        SetRandomDestination();
        agent.isStopped = false;
        anim.SetFloat("Blend", 0.5f);
        BriefStop();
    }

    void SetRandomDestination()
    {
        agent.destination = distance * Random.insideUnitSphere;
    }

    void BriefStop()
    {
        StartCoroutine(Wait());
    }
    
    IEnumerator Wait()
    {
        float random = Random.Range(5f, 15f);
        yield return new WaitForSeconds(random);
        agent.isStopped = true;
        anim.SetFloat("Blend", 0f);
        yield return new WaitForSeconds(3);
        anim.SetFloat("Blend", 0.5f);
        StartWandering();
    }
    
    void ChasePlayer()
    {
        agent.speed = 3;
        agent.destination = player.transform.position;
        if(agent.isStopped) agent.isStopped = false;
        anim.SetFloat("Blend", 1f);
    }

    public void StopChase()
    {
        agent.speed = 1;
        agent.ResetPath();
        StartWandering();
    }
}
