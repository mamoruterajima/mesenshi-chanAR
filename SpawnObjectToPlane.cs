using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnObjectToPlane : MonoBehaviour
{
    public GameObject cubePrefab;
    GameObject spawnedObj; // 生成されたものCube
    ARRaycastManager arRaycastManager;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
        // タップした場所に生成
        if (Input.touchCount > 0)
        {
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                if (spawnedObj == null)
                {
                    spawnedObj = Instantiate(cubePrefab, hitPose.position, hitPose.rotation);
                }
                else
                {
                    spawnedObj.transform.position = hitPose.position;
                }
            }

        }
    }
}
