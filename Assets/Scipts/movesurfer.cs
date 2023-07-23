using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movesurfer : MonoBehaviour
{
    Rigidbody2D surf;
    bool isStart;
    bool buttondown;
    public int energy;
    public LayerMask killer;
    public GameObject startButton;
    public GameObject gameover;
    Animator animator;

    //Game over
     
    // Start is called before the first frame update
    void Start()
    {
        energy = 0;
        surf = GetComponent<Rigidbody2D>();
        //surf.velocity = new Vector2(5, 0);
        buttondown = false;
        isStart = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            surfMoving();
            if (!buttondown)
                surf.velocity = new Vector2(5, -1);
            if (surf.transform.position.x > 90)
                Restart();
        }
        
    }

    private void Restart()
    {
        Camera.main.GetComponent<background>();
        Start();
    }

    private void surfMoving()
    {
        float step = 0.015f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            buttondown = true;
            transform.position = transform.position + new Vector3(0, step, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            buttondown = true;
            transform.position = transform.position + new Vector3(0, -step, 0);
        }
        else
        {
            buttondown = false;
        }

    }
    public void startClick()
    {
        isStart = true;
        Destroy(startButton);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (Mathf.Pow(2,other.gameObject.layer) == (int)killer) 
        { 
            animator.SetBool("killer", true);
            surf.velocity = Vector3.zero;
            isStart = false;

            Instantiate(gameover, new Vector2 (surf.position.x, 0), Quaternion.identity);
           
        } 
        
        else
        {
            energy += 1;
            Destroy(other.gameObject);
        }
        
    }
}
