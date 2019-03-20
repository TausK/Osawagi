using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerControls
{
    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode attack;
}

[Serializable]
public class KeyBindings
{
    public PlayerControls[] players;
}
