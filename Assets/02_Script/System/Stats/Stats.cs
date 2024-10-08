using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{

    [SerializeField] private float value;

    private List<float> modify = new();

    public void AddMod(float value)
    {

        modify.Add(value);

    }

    public void RemoveMod(float value)
    {

        modify.Remove(value);

    }

    public float GetValue()
    {

        float v = value;

        foreach (var mod in modify)
        {

            v += mod;

        }

        return v;

    }

}
