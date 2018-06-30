using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeaponPosition : MonoBehaviour
{ 
    Collider2D _parentCollider;
    SpriteRenderer _sprite;
    Vector3 _weaponPos;
    Vector2 _mousePos;
    bool _isInLeft = false;

	void Start ()
    {
        _parentCollider = gameObject.GetComponentInParent<Collider2D>();
        _sprite = gameObject.GetComponent<SpriteRenderer>();
    }

	void Update ()
    {
        _mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (_parentCollider.bounds.center.x > _mousePos.x)
        {
            ChangeToLeftHand(_isInLeft);
        }
        else if (_parentCollider.bounds.center.x < _mousePos.x)
        {
            ChangeToRightHand(_isInLeft);
        }
    }
    
    private void ChangeToLeftHand(bool hand)
    {
        if (!hand)
        {
            _weaponPos = gameObject.transform.localPosition;
            _weaponPos.x = -_weaponPos.x;
            gameObject.transform.localPosition = _weaponPos;
            _sprite.flipY = true;
            _isInLeft = true;
        }
    }

    private void ChangeToRightHand(bool hand)
    {
        if (hand)
        {
            _weaponPos = gameObject.transform.localPosition;
            _weaponPos.x = -_weaponPos.x;
            gameObject.transform.localPosition = _weaponPos;
            _sprite.flipY = false;
            _isInLeft = false;
        }
    }
}
