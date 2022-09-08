using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedObject : MonoBehaviour
{
    private bool isGathered=false;
    

    public bool IsGathered()
    {
        return isGathered;
    }

    public void Gathered()
    {
        isGathered = true;
    }





}
