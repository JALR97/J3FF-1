using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driller : MonoBehaviour
{
    //-----------------//Data structures//-----------------//
    //enums
    private enum State {
        INACTIVE,
        SEEK,
        AIM,
        DASH,
        COOLDOWN
    }

    //-----------------//Components//-----------------//
    //Internal Components
    

    //Prefabs


    //External References
    private Transform player;

    //-----------------//Variables//-----------------//
    //Process variables - private
    private State currentState;
    private float distancePlayer;

    //Balance variables - serialized 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float activateDistance;
    [SerializeField] private float dashDistance;

    //Public properties - private set "Name { get; private set; }"


    //-----------------//Functions//-----------------//
    //Built-in
    private void Start() {
        player = GameObject.FindWithTag("Player").transform;
        currentState = State.INACTIVE;
    }

    private void Update() {
        if (currentState is State.INACTIVE or State.SEEK) {
            distancePlayer = (transform.position - player.position).magnitude;
        }
        
    }
    
    //Inner process - private


    //External interaction - public

}
