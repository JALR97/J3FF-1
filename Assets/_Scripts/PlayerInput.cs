using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    //Connection with the player manager for communication, and any other component it needs
    [SerializeField] private PlayerManager playerManager;

    //vector2 to handle movement direction from inputs 
    private Vector2 direction;

    //standard check for correct connection of components
    private void Awake() {
        if (playerManager == null) {
            Debug.Log("Module component not set through editor in: PlayerInput.cs"); //PLACEHOLDER!!
        }
    }

    //We obtain the direction of the input and
    //normalize it to avoid diagonal speed boost
    private void UpdateDirection() {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction.Normalize(); 
    }
    
    //The main functionality of this module is to determine what message to send to the player manager 
    //regarding input. There are 5 message codes this module sends to the manager, 3 in update, 2 in fixed.
    private void Update() {
        //---Roll input is checked first
        if (Input.GetKeyDown(KeyCode.LeftControl) && direction.magnitude > 0) {
            UpdateDirection();
            playerManager.SendMessage(PlayerManager.Messages.INPUT_ROLL, direction);
        } //---Jump input 
        else if (Input.GetKeyDown(KeyCode.Space)) {
            playerManager.SendMessage(PlayerManager.Messages.INPUT_JUMP);
        } //---Interact input
        else if (Input.GetKeyDown(KeyCode.E)) {
            playerManager.SendMessage(PlayerManager.Messages.INPUT_INTERACT);
        }
    }

    private void FixedUpdate() {
        //if the player is holding down a direction, and if shift is held down,
        //that information is sent to the manager, which decides how to respond
        UpdateDirection();
        if (direction.magnitude > 0) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                //Sprinting message if shift held down
                playerManager.SendMessage(PlayerManager.Messages.INPUT_SPRINT, direction);
            }
            else {
                //regular walk message
                playerManager.SendMessage(PlayerManager.Messages.INPUT_WALK, direction);
            }
        }
    }
}