using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateDoor : MonoBehaviour
{
    private float yMotionSpeed = 1F;


    private float range = 2.0f;

    private Transform t;
    private Transform player;
    private Transform init;
    private Boolean opening = false;

    private void Awake()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        init = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        t = this.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log("Distance is" + playerDistance());

        if (opening)
        {
            transform.Translate(Vector3.right * yMotionSpeed * Time.deltaTime);
        }
        else if (t.position != init.position)
        {
            transform.Translate(Vector3.left * yMotionSpeed * Time.deltaTime);
        }



    }

    void startOpening()
    {
        opening = true;
        transform.Translate(Vector3.right * yMotionSpeed * Time.deltaTime);
    }

    private float playerDistance()
    {

        return Vector3.Distance(t.position, player.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        opening = true;
    }

    private void OnTriggerExit(Collider other)
    {
        opening = false;
        
    }


}
