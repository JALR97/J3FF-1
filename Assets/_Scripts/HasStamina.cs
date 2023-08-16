
using UnityEngine;

public class HasStamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float currentStamina;
    public float recoveryRate = 10f; // Estamina recuperada por segundo
    public bool isRecovering = false;


    public float CurrentStamina
    {
        get { return currentStamina; }
    }
    private void Start()
    {
        currentStamina = maxStamina;
    }

    public bool UseStamina(float amount)
    {
        if (currentStamina >= amount)
        {
            currentStamina -= amount;
            isRecovering = false;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void StartRecovery()
    {
        isRecovering = true;
    }

    private void Update()
    {
        if (isRecovering)
        {
            currentStamina = Mathf.Min(maxStamina, currentStamina + recoveryRate * Time.deltaTime);
        }
    }
}
