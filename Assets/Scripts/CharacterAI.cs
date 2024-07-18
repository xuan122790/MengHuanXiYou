using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterAI : MonoBehaviour
{
    public NavMeshAgent meshAgent;
    private Vector3 targetPos;
    // Start is called before the first frame update
    void Start()
    {
        meshAgent.updateRotation = false;
        meshAgent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;
            meshAgent.SetDestination(targetPos);
        }
    }
}
