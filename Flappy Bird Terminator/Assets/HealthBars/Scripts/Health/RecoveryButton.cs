using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoveryButton : ButtonHealth
{
    [SerializeField] private int _recovery;

    protected override void ChangeHealth()
    {
        PlayerHealth.Recovery(_recovery);
    }
}
