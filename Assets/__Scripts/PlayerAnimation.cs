using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
   
    [SerializeField] private Animator playerAnimator;
    private string currentAnim = "Idle";
    
    public void SwitchAnim(string animName) {
        if (animName != currentAnim) {
            playerAnimator.Play(animName);
            currentAnim = animName;
        }
    }
}
