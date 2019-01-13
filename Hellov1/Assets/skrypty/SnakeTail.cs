using UnityEngine;
using System.Collections;


public class SnakeTail : MonoBehaviour
{

    private int myOrder;
    private Transform head;
    private Vector3 movementVelocity;
    public float time = 0.5f;

    // Use this for initialization
    void Start()
    {
        head = GameObject.FindGameObjectWithTag("Head").gameObject.transform;
        for (int i = 0; i < head.GetComponent<BasicMove>().bodyParts.Count; i++)
        {
            if (gameObject == head.GetComponent<BasicMove>().bodyParts[i].gameObject)
            {
                myOrder = i;
            }
        }
    }

    void FixedUpdate()
    {
        if (myOrder == 0)
        {
            transform.position = Vector3.SmoothDamp(transform.position, head.position, ref movementVelocity, time);
            transform.LookAt(head.transform.position);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, head.GetComponent<BasicMove>().bodyParts[myOrder - 1].position, ref movementVelocity, time);
            transform.LookAt(head.transform.position);
        }
    }
}
