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
    public GameObject clickEffectGo;
    private float followMouseTimer;
    private int clickCount;
    private bool followMouse;
    private float createEffectTime;
    // Start is called before the first frame update
    void Start()
    {
        meshAgent.updateRotation = false;
        meshAgent.updateUpAxis = false;
        targetPos = transform.position;
        meshAgent.updatePosition = false;
    }

    // Update is called once per frame
    void Update()
    {
        cac.PlayerLocomotionAnimation(meshAgent.nextPosition-transform.position,Vector3.Distance(targetPos, transform.position));
        if (Input.GetMouseButtonDown(0))
        {
            clickCount++;
            followMouse = false;
            ClickMouse();
        }
        if (willStoping)
        {
            GetNotWalkableMovePoint();
        }
        DoubleClickMouse();
        transform.position = meshAgent.nextPosition;
    }

    private void ClickMouse()
    {
        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = transform.position.z;
        meshAgent.SetDestination(targetPos);
        if (Time.time - createEffectTime >= 0.1f) 
        {
            createEffectTime = Time.time;
            Instantiate(clickEffectGo, targetPos, Quaternion.identity);
        }      
    }

    private void GetNotWalkableMovePoint()
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
    private void DoubleClickMouse()
    {
        if (followMouse) //已经开启开关，人物跟随鼠标移动
        {
            ClickMouse();
        }
        else
        {
            if (Time.time - followMouseTimer >= 0.2f) 
            {
                //已超出规定时间，重新计时
                followMouseTimer = Time.time;
                clickCount = 0;
            }
            else
            {
                if (clickCount > 1) 
                {
                    followMouse = true;
                }
            }
        }
    }
}
