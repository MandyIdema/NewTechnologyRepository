using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    public List<GameObject> Radarobjects;
    public GameObject[] Trackedobjects;
    public GameObject Radarprefab;

    List<GameObject> borderObjects;
    public float switchDistance;
    public Transform helpTransform;



    // Start is called before the first frame update
    void Start()
    {
        createRadarobject();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; 1 < Radarobjects.Count; i++)
        {
            if (Vector3.Distance(Radarobjects[i].transform.position,transform.position)> switchDistance)
            {
                helpTransform.LookAt(Radarobjects[i]);
                borderObjects[i].transform.position = transform.position * switchDistance*helpTransform.forward;
            }
            else
            {

            }
        }
    }

    void createRadarobject()
    {
        Radarobjects = new List<GameObject>();
        foreach(GameObject o in Trackedobjects)
        {
            GameObject k = Instantiate(Radarprefab, o.transform.position, Quaternion.identity) as GameObject;
            Radarobjects.Add(k);
            GameObject j = Instantiate(Radarprefab, o.transform.position, Quaternion.identity) as GameObject;
            Radarobjects.Add(j);
        }
    }
}
