using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float szybkosc;
    private Animator anima;
    private Rigidbody2D cialo; 
    private bool poruszanie;
    private Vector2 ostatniRuch;
    private static bool _canPause;

    public static bool CanPause
    {
        get { return _canPause; }
        set { _canPause = value; }
    }

    public bool Movement
    {
        get { return poruszanie; }
    }

    void Start()
    {
        _canPause = true;
        anima = GetComponent<Animator>();
        cialo = GetComponent<Rigidbody2D>();        
    }

    void Update()
    {
        poruszanie = false;
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            cialo.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*szybkosc, cialo.velocity.y);
            poruszanie = true;
            ostatniRuch = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            cialo.velocity = new Vector2(cialo.velocity.x, Input.GetAxisRaw("Vertical")*szybkosc);
            poruszanie = true;
            ostatniRuch = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            cialo.velocity = new Vector2(0f, cialo.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            cialo.velocity = new Vector2(cialo.velocity.x, 0f);
        }       

        anima.SetFloat("RuchX", Input.GetAxisRaw("Horizontal"));
        anima.SetFloat("RuchY", Input.GetAxisRaw("Vertical"));
        anima.SetBool("Ruch", poruszanie);
        anima.SetFloat("OstatniRuchX", ostatniRuch.x);
        anima.SetFloat("OstatniRuchY", ostatniRuch.y);
    }
}
