using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCreator : MonoBehaviour
{
    [SerializeField] protected GameObject CreateObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mPos = Input.mousePosition;
            mPos = Camera.main.ScreenToWorldPoint(mPos);
            mPos.z = 0f;
            Instantiate(this.CreateObject, mPos, Quaternion.identity, this.transform);
        }
    }
}
