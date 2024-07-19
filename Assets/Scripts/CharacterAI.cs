using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterAI : MonoBehaviour
{
    public NavMeshAgent meshAgent;
    private Vector3 targetPos;
    public CharactorAnimatorController cac;
    public bool willStoping;
    // Start is called before the first frame update
    void Start()
    {
        meshAgent.updateRotation = false;
        meshAgent.updateUpAxis = false;
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        cac.PlayerLocomotionAnimation(targetPos-transform.position,Vector3.Distance(targetPos, transform.position));
        if (Input.GetMouseButtonDown(0))
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = transform.position.z;
            meshAgent.SetDestination(targetPos);
        }
        if (willStoping)
        {
            Ray2D ray = new Ray2D(transform.position, targetPos - transform.position);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(ray.origin, ray.direction);
            if (raycastHit2D) 
            {
                targetPos = raycastHit2D.point;
                targetPos -= 0.1f * (targetPos - transform.position);
            }
            willStoping = false;
            targetPos.z = transform.position.z;
            meshAgent.SetDestination(targetPos);
        }
    }
}
