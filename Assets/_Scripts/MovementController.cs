using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
    //Connection with the player manager for communication, and any other component it needs
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] private Rigidbody2D rigidBody2D;
    
    //standard check for correct connection of components
    private void Awake() {  
        if (playerManager == null || 
            rigidBody2D == null) {
            
            Debug.Log("Module component not set through editor in: MovementController.cs"); //PLACEHOLDER!!
        }
    }
    
    //General self movement function
    public void Move(Vector2 direction, float Speed) {
        rigidBody2D.velocity = direction * (Speed * Time.fixedDeltaTime);
    }
    
    //General rotation 
    public void Rotate() {
        
    }
}
