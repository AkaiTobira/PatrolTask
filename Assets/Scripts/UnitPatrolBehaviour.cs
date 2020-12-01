using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitPatrolBehaviour : MonoBehaviour
{
    [SerializeField] private NavPoint _currentDestination;
    [SerializeField] private NavMeshAgent _agent;

    private void GetNextPatrolPoint(){
        NavPoint[] possibleToTravel = _currentDestination?.NeighbourNavPoints;
        
        if( possibleToTravel == null || possibleToTravel.Length == 0 ){
            Debug.LogError("Couldn't get new NavPoints");
            enabled = false;
            return;
        }
        _currentDestination = possibleToTravel[ Random.Range(0, (int)possibleToTravel.Length )];
        if( _currentDestination == null ){
            Debug.LogError("Current destination is null");
            enabled = false;
            return;
        }
       _agent.destination = _currentDestination.transform.position;
    }

    void Update()
    {
        if( _agent == null ){
            Debug.LogWarning("Agent is not set");
            enabled = false;
            return;
        }

        if (!_agent.pathPending && _agent.remainingDistance < 0.5f){
            GetNextPatrolPoint();
        }
    }

    public void AddPatrolPoint( ref NavPoint newPoint ){
        if( newPoint == null ){
            Debug.LogWarning("New NavPoint is null");
            return;
        }
        _currentDestination = newPoint;
        if(enabled == false) enabled = true;
    }
}
