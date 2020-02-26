using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironemtnAnimationScript : MonoBehaviour
{
    public int playTime;
    bool playing;
    Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        
        anim = GetComponent<Animator>();

    }
  

   public void PlayAnim()
    {
        anim.SetTrigger("Break");

        Destroy(this.gameObject,playTime);


    }
}
