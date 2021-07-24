using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{

    public Transform[] points;
    public float speed;
    private float waitTime;
    public float startWaitTime;

    private Animator animator;
    private int i;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        waitTime = startWaitTime;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        Vector3 targetDirection = points[i].position - transform.position;
        float singleStep = 2 * speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);


        if(Vector3.Distance(transform.position, points[i].position) < 0.2) {
            if (waitTime <= 0) {
                animator.SetInteger("moving", 1);
                i = (i + 1) % points.Length;
                waitTime = startWaitTime;
            }
            else {
                animator.SetInteger("moving", 0);
                animator.Play("cast");
                waitTime -= Time.deltaTime;
            }
        }
    }
}
