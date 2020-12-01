using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitPatrolBehaviour : MonoBehaviour
{
    [SerializeField] private NavPoint[] _patrolPoints;
    [SerializeField] private NavPoint _currentDestination;
    [SerializeField] private NavMeshAgent _agent;

    private void GetNextPatrolPoint(){
        NavPoint[] possibleToTravel = _currentDestination.NeighbourNavPoints;
        _currentDestination = possibleToTravel[ Random.Range(0, possibleToTravel.Length)];
        if( _currentDestination == null ){
            return;
        }
       _agent.destination = _currentDestination.transform.position;
    }

    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f){
            GetNextPatrolPoint();
        }
    }
}
