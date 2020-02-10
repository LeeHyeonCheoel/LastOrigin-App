using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Buff
{
    public string explanation;

    public abstract void Apply();
}
