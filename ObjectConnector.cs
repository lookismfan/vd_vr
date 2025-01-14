using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
 
public class ObjectConnector : MonoBehaviour 
{ 
    public float connectionDistance = 5f; // Расстояние для соединения 
    public GameObject connectedObject; // Объект, с которым соединяемся 
    public ToolObject testObject; // Объект, при поднесении которого соединяемся     
 
    private bool isConnected = false; 
    private Rigidbody rb; 
    private Rigidbody connectedRb;
    private Rigidbody testRb;    
    private FixedJoint joint;
 
    void Start() 
    { 
        rb = GetComponent<Rigidbody>();
        if (connectedObject != null) { 
            connectedRb = connectedObject.GetComponent<Rigidbody>(); 
        } 
                if (testObject != null) { 
            testRb = testObject.GetComponent<Rigidbody>(); 
        } 
    } 
 
    void Update() 
    { 
        if (connectedObject == null) return; 
        if (!isConnected) 
        { 
            float distance = Vector3.Distance(connectedRb.transform.position, testObject.transform.position); 
            if (distance <= connectionDistance) 
            { 
                if (testObject.checkNext()){
                connectedRb.transform.position = transform.position;
                ConnectObjects(); 
                }

            } 
        } 
    } 
 
    void ConnectObjects() 
    { 
        if (connectedRb == null || rb == null) return; //Проверка на наличие  
 
        isConnected = true; 
 
        //Соединяем объекты, используя
        joint = gameObject.AddComponent<FixedJoint>(); 
        joint.connectedBody = connectedRb; 
 
        //Дополнительные настройки соединения (при необходимости) 
        joint.breakForce = 100f; //Сила, при которой соединение разрушается 
        joint.breakTorque = 100f; //Крутящий момент, при котором соединение разрушается 
  
        rb.isKinematic = true; 
        connectedRb.isKinematic = true; 

        connectedRb.constraints = RigidbodyConstraints.FreezePosition;
 
 
        Debug.Log("Objects connected!"); 
    } 
}
