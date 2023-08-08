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
        rigidBody2D.velocity = direction * (Speed * Time.deltaTime);
        
    }
    
    //General rotation 
    public void Rotate(Vector2 direction, float Speed) {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion qDest = Quaternion.Euler(new Vector3(0, 0, angle + 90));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, qDest, 100 * Speed * Time.deltaTime); 
    }
    //Instant rotation overload
    public void Rotate(Vector2 direction) {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90));
    }
}
