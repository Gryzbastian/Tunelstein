using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject GonCel;
    private Vector3 PozycjaCelu;
    public float Szybkosc;
	
	void Update()
    {
        PozycjaCelu = new Vector3(GonCel.transform.position.x, GonCel.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, PozycjaCelu, Szybkosc * Time.deltaTime);
    }
}
