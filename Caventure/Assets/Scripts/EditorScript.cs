#if UNITY_EDITOR
using System;
using UnityEngine;

[ExecuteInEditMode]
public class EditorScript : MonoBehaviour
{
    //Class used to help do things in the editor quicker.
    public Transform ParentTransform;
    
    private void Update()
    {
        
    }
}
#endif