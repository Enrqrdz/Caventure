using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public float speed;
    float timer;
    float sin1;
    public float size1 = 3f;
    public float size2 = 2f;
    public float size3 = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += speed*Time.deltaTime;

        sin1= Mathf.Sin(timer)/size3;
        
        
        
        
        transform.localScale= new Vector3(sin1+size1/size2, sin1 + size1 / size2, sin1 + size1 / size2);
    }
}
