using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneHitKillManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _healthPacks;
    [SerializeField]
    private EndOneHitKill _endOneHitKill;

	public void StartOneHitKill()
    {
        Destroy(_healthPacks);
    }
}
