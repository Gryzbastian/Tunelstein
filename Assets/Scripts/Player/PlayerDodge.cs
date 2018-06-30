using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : MonoBehaviour
{
    private Rigidbody2D _playerBody;
    private PlayerControll _movementScript;
    private float _dodgeCooldown = 2;
    private float _nextDodge;

	void Start ()
    {
        _playerBody = gameObject.GetComponent<Rigidbody2D>();
        _movementScript = gameObject.GetComponent<PlayerControll>();
	}
	
	void Update ()
    {
		if (Input.GetMouseButtonDown(1) && _movementScript.Movement && (Time.time > _nextDodge))
        {
            Dodge();
        }
	}
    
    private void Dodge()
    {
        Vector2 force = new Vector2(_playerBody.velocity.x * 400, _playerBody.velocity.y * 400);
        _playerBody.AddForce(force, ForceMode2D.Force);
        _nextDodge = Time.time + _dodgeCooldown;
    }
}
