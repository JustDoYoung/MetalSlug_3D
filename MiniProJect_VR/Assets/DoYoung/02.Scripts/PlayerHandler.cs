using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public Transform model;

    private Animator anim;
    private Camera mainCamera;
    private Vector3 stickDirection;

    [Range(20f, 80f)]
    public float rotationSpeed = 30f;

    private bool isWeaponEquipped = false;

    void Start()
    {
        mainCamera = Camera.main;
        anim = model.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        stickDirection = new Vector3(h, 0, v);

        HandlerInputData();
        HandlerStandardLocomotionRotation();
    }

    private void HandlerStandardLocomotionRotation()
    {
        Vector3 rotationOffset = /*vodoo magic*/ mainCamera.transform.TransformDirection(stickDirection);
        rotationOffset.y = 0;
        model.forward += Vector3.Lerp(model.forward, rotationOffset, Time.deltaTime * rotationSpeed);
        print(model.forward);
    }
    void HandlerInputData()
    {
        anim.SetFloat("Speed", Vector3.ClampMagnitude(stickDirection, 1).magnitude);

        if (Input.GetKeyDown(KeyCode.F))
        {
            isWeaponEquipped = anim.GetBool("isWeaponEquipped");
            anim.SetBool("isWeaponEquipped", !isWeaponEquipped);
            isWeaponEquipped = !isWeaponEquipped;
        }
    }
}
