using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonHealth : MonoBehaviour
{
    [SerializeField] protected PlayerHealth PlayerHealth;
    [SerializeField] protected Button ChangeButton;

    private void OnEnable()
    {
        ChangeButton.onClick.AddListener(ChangeHealth);
    }

    private void OnDisable()
    {
        ChangeButton.onClick.RemoveListener(ChangeHealth);
    }

    virtual protected void ChangeHealth() 
    {
        
    }
}