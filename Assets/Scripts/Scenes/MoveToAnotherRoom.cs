using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToAnotherRoom : MonoBehaviour
{
    public GameObject target;
    private GameObject Kamera;

    void Start()
    {
        Kamera = GameObject.Find("Main Camera");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.position = new Vector3(target.transform.position.x,target.transform.position.y,0);
            Kamera.gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -10);

        }
    }
}