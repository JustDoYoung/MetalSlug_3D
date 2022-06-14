using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeHandler : MonoBehaviour
{
    Animator _anim;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetAttack(1);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            SetAttack(2);
        }
    }

    private void SetAttack(int attackType)
    {
        if (_anim.GetBool("CanAttack"))
        {
            _anim.SetTrigger("Attack");
            _anim.SetInteger("AttackType", attackType);
        }
    }
}
