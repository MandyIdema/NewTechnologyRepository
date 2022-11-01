using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRotation : MonoBehaviour
{
   
    public List<GameObject> RadarObjects;
    public GameObject Radarprefab;
    public GameObject[] Trackedobjects;
    public Transform parent_turrent;
    public Transform parent_basicRobot;

    ///Radar sweeping
    public GameObject Sweeping;
    private float rotationSpeed;
    private float radarRange;
  
    private void Awake()
    {
        CreatetrackedObjects();

        
        rotationSpeed = 180f;
        radarRange = 50f;

    }

    
   private void Update()
    {
        //The gameobject rotates with the rotationspeed on the Z axis every frame
        Sweeping.transform.eulerAngles -= new Vector3(0, 0, rotationSpeed * Time.deltaTime);

        Physics.Raycast(transform.position, (Sweeping.transform.eulerAngles), radarRange);
 
    }

    //This function creates a child object on the object that you want to display on the radar
    //The child object follows the position of the tracked object and will only be displayed on the radar camera
    void CreatetrackedObjects()
    {
        //Create a new list of gameobjects added to radarobjects
        RadarObjects = new List<GameObject>();
        foreach (GameObject o in Trackedobjects)
        {
            //Instantiate the radarprefab as childobject of the parent
            GameObject radarBasicRobotEnemyPrefab = Instantiate(Radarprefab, o.transform.position, Quaternion.identity) as GameObject;
            radarBasicRobotEnemyPrefab.transform.SetParent(parent_basicRobot);

            GameObject radarRobotEnemyPrefab = Instantiate(Radarprefab, o.transform.position, Quaternion.identity) as GameObject;
            radarRobotEnemyPrefab.transform.SetParent(parent_basicRobot);

            RadarObjects.Add(radarBasicRobotEnemyPrefab);
            RadarObjects.Add(radarRobotEnemyPrefab);

        }
    }

}
