using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_ColliderBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("1");
            GameObject.Find("Scripts").GetComponent<Control_Scenes>().Change_Road((name[4]-'0'+1)%3+1);
        }
    }
}
