﻿using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton 
    public static PlayerManager instance;
    void Awake()
    {
        instance = this;
    }

    #endregion

    public Transform playerposition;
    public float playerwalkspeed = 2f;
    
}
