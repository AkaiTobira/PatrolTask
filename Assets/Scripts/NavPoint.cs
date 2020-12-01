using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavPoint : MonoBehaviour
{
    [SerializeField] private NavPoint[] _neighbourNavPoints;

    public NavPoint[] NeighbourNavPoints{
        get { return _neighbourNavPoints; }
    }
}
