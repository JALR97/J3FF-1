using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    //This class controls the communication between the player related classes that are components
    //in the player game object, and it makes the executive decisions with the information provided by the others

    //All the other player related classes which we will connect through the editor
    [SerializeField] private PlayerCollisions playerCollisions;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private MovementController movementController;
    [SerializeField] private HasHealth hasHealth;
    [SerializeField] private HasStamina hasStamina;
    [SerializeField] private PlayerAnimation playerAnimation;
    
    //Constants
    private float GLOBAL_SPEED_MODIFIER = 100.0f;
    
    //All the status variables that the manager needs to keep track of whether the player:
    private bool grounded;      //is on the ground
    private bool recovery = false;      //is in the invincibility/recovery frames
    private bool canAct = true;        //can perform a move (jump, roll, slide, etc.)  
    private bool canMove = true;       //can move, be it walk, sprint, or while in the air
    private bool alive;         //self explanatory
    private bool isSprinting;   //is currently sprinting
    private bool rolling;       //is currently rolling
    
    //Balance control variables
    [SerializeField][Range(5.0f, 30.0f)] private float walkSpeed;
    [SerializeField][Range(1.0f, 10.0f)] private float sprintBoost; //Added to walkSpeed when sprinting
    [SerializeField][Range(0.1f, 2.0f)] private float rollTime;
    [SerializeField][Range(10.0f, 40.0f)] private float rollSpeed;
    [SerializeField] AnimationCurve rollCurve;
    
    //Enum that gives a simple naming system for the messages the player manager will be receiving from the
    //modules. The Names start with the name of the module it belongs to, underscore and the name of the
    //specific message
    public enum Messages {
        INPUT_WALK,
        INPUT_SPRINT,
        INPUT_JUMP,
        INPUT_ROLL,
        INPUT_INTERACT,
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
            
            Debug.Log("Module component not set through editor in: PlayerManager.cs"); //PLACEHOLDER!!
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
            
            case Messages.INPUT_INTERACT:
                Debug.Log("Interact"); //PLACEHOLDER!!
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
            case Messages.INPUT_WALK: //Walk
                if (canMove) {
                    movementController.Move(direction, GLOBAL_SPEED_MODIFIER * walkSpeed);
                }
                break;
            
            case Messages.INPUT_SPRINT: //Sprint
                if (canMove) {
                    movementController.Move(direction, GLOBAL_SPEED_MODIFIER * (walkSpeed + sprintBoost));    
                }
                break;
            
            case Messages.INPUT_ROLL: //Roll
                if (canAct) {
                    StartCoroutine(Roll(direction));
                }
                break;
        }
    }
    
    //Roll implementation through the MovementController module
    private IEnumerator Roll(Vector2 direction) {
        //Setup to start the roll, like updating status and initializing variables
        float time = 0;         //Timer
        float speedPercent;     //value returned by the Roll curve, goes from 0.0 to 1.0    
        rolling = true;
        canAct = false;
        canMove = false;

        //Collision change call
        //--Placeholder-------------------
        
        //start animation
        //--Placeholder-------------------
        
        //Main movement loop and time increment check for the 
        while (rolling) {
            //Main curve functionality uses an animation curve.
            //Both speed and time are used as percentages to "communicate" with the Animation curve
            //which uses percent values in both axis going from 0.0f to 1.0f.
            //
            //therefore we can divide the timer value between rolltime to get a percentage representing
            //the time progress of the action. 
            speedPercent = rollCurve.Evaluate(time / rollTime);
            //The percentage obtained from the curve will be multiplied by
            //the rollSpeed var to then be able to modulate the roll speed in two ways, the shape of the curve
            //and the overall velocity
            movementController.Move(direction, speedPercent * rollSpeed * GLOBAL_SPEED_MODIFIER); 
            
            time += Time.fixedDeltaTime;
            Debug.Log("time : " + time);
            if (time >= rollTime) {                     //When the time is up we break the cycle
                rolling = false;
            }
            else {
                yield return new WaitForFixedUpdate();  //if not, next cycle will come at fixed update
            }
        }
        //Collision change call
        //--Placeholder-------------------

        //recovery is checked here to make sure the loop wasn't stopped by the player getting damaged
        //This way the status or animations set by the damage function won't be affected
        if (!recovery) { 
            //Back to normal animation
            //--Placeholder-------------------
        
            canAct = true;  
            canMove = true;
        }
    }
}
