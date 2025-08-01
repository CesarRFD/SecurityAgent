using System;
using UnityEngine;
public class IsInTheArea : MonoBehaviour
{
    public bool cs;
    public Stalk stalk;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Area"))
        {
            cs = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Area"))
        {
            cs = false;
            stalk.StopChase();
        }
    }
    
}
