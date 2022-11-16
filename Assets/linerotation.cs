using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linerotation : MonoBehaviour
{

    public GameObject enemytrackingpoint;
    private float rotationSpeed;

    


    // Start is called before the first frame update
    void Awake()
    {
        rotationSpeed = 180f;


    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        //The line sweeps around and detects the tracking points
        //When a point is detected it will be visible for 3 seconds
        if (other.gameObject.tag == "enemytrackingpoint")
        {
            {
                fadeobject1.Fadein = true;
                Debug.Log("Enemy detected");
                
                
            }
        }
    }


}
