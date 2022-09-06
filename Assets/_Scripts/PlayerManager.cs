using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    //This class controls the communication between the player related classes that are components
    //in the player game object, and it makes the executive decisions with the information provided by the others

    //All the other player related classes which we will connect through the editor
    public PlayerCollisions playerCollisions;
    public PlayerInput playerInput;
    public MovementController movementController;
    public HasHealth hasHealth;
    public HasStamina hasStamina;
    public PlayerAnimation playerAnimation;
    
    //All the status variables that the manager needs to keep track of whether the player:
    private bool grounded;  //is on the ground
    private bool recovery;  //is in the invincibility/recovery frames
    private bool canAct;    //can perform a move (jump, roll, slide, etc.)  
    private bool canMove;   //can move, be it walk, sprint, or while in the air
    private bool alive;     //self explanatory
    
    //Enum that gives a simple naming system for the messages the player manager will be receiving from the
    //modules. The Names start with the name of the module it belongs to, underscore and the name of the
    //specific message
    public enum Messages {
        INPUT_WALK,
        INPUT_SPRINT,
        INPUT_JUMP,
        INPUT_ROLL,
        INPUT_SLIDE,
        HEALTH_0HP,
        COLLISIONS_DAMAGE
    }
    
    //We check if any of the modules were not assigned
    private void Awake() {  
        if (playerCollisions == null || 
            playerInput == null || 
            movementController == null || 
            hasHealth == null ||
            hasStamina == null ||
            playerAnimation == null) {
            //---PLACEHOLDER
            ; //we need to send an error message here cause editor error
        }
    }
    
    //The whole communication system between the modules and this class relies on this function
    //it is public so that all the other modules can call it and send a messages to the manager,
    //at the same time we will make use of overloads to allow the addition of data with the message.
    public void SendMessage(Enum messageCode) {
        //The use of an enum for the message codes should help here to keep cases organized by their 
        //module of origin
        switch (messageCode) {
            
            //Input module messages
            //################################
            case Messages.INPUT_JUMP:
                Debug.Log("Jump"); //PLACEHOLDER!!
                break;
            case Messages.INPUT_ROLL:
                Debug.Log("Roll"); //PLACEHOLDER!!
                break;
            
            //health module messages
            //################################
            case Messages.HEALTH_0HP:
                Debug.Log("Dead"); //PLACEHOLDER!!
                break;
            
            //Collisions module messages
            //################################
            case Messages.COLLISIONS_DAMAGE:
                Debug.Log("Damaged"); //PLACEHOLDER!!
                break;
        }
    }
    
    //This overload takes a 2D vector as an argument on top of the message code
    public void SendMessage(Enum messageCode, Vector2 direction) {
        switch (messageCode) {
            
            //Input module messages
            //################################
            case Messages.INPUT_WALK:
                Debug.Log("Walk"); //PLACEHOLDER!!
                break;
            case Messages.INPUT_SPRINT:
                Debug.Log("Sprint"); //PLACEHOLDER!!
                break;
        }
    }
}
