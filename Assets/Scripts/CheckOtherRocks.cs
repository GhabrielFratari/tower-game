using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOtherRocks : MonoBehaviour
{   
    private int bitMask;
    Transform myTransform;
    [SerializeField] GameObject testObj;
    private void Awake() 
    {
        bitMask = 1 << 10;
        myTransform = transform;
    }
    private void Update() 
    {
        RaycastHit2D[] hitDown = Physics2D.RaycastAll(myTransform.position, myTransform.TransformDirection(Vector2.down), 0.5f, bitMask);
        for (int i = 0; i < hitDown.Length; i++)
        {
            RaycastHit2D hit = hitDown[i];
            if(hit.collider != null && hit.collider.gameObject != gameObject)
            {
                Instantiate(testObj, hit.collider.gameObject.transform.position, Quaternion.identity);
                Debug.Log(hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }
        }
        RaycastHit2D[] hitUp = Physics2D.RaycastAll(myTransform.position, myTransform.TransformDirection(Vector2.up), 0.5f, bitMask);
        for (int i = 0; i < hitUp.Length; i++)
        {
            RaycastHit2D hit = hitUp[i];
            if(hit.collider != null && hit.collider.gameObject != gameObject)
            {
                Instantiate(testObj, hit.collider.gameObject.transform.position, Quaternion.identity);
                Debug.Log(hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
