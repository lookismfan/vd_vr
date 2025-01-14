using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolObject : MonoBehaviour
{
    // Start is called before the first frame update
   private string[] objectsTags; 
   private int nextObject;


public bool checkNext(){
    string nextTag = objectsTags[nextObject];
     Rigidbody nextObj = GameObject.FindWithTag(nextTag).GetComponent<Rigidbody>();
    float distance = Vector3.Distance(transform.position, nextObj.transform.position); 
    if(distance < 5f){
        Debug.Log("Found object!"); 
        nextObject++;
        return true;
    }
    return false;
}

    void Start()
    {
        objectsTags = new string[]{"1","2","3","4","5","6","7","8","9"};
        nextObject = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
