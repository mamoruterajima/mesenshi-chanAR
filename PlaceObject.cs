using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class PlaceObject : MonoBehaviour
{
    [SerializeField] GameObject mesenshi;
    float maxRayDistance = 30.0f;

    ARRaycastManager raycastManager;
    List<ARRaycastHit> hitList = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {

#if UNITY_EDITOR  //シュミュレート用
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, maxRayDistance))
            {
                SetMesenshi(hit.point);
            }
            /*if (raycastManager.Raycast(Input.GetTouch(0).position, hitList, TrackableType.Planes))
            {
                Instantiate(objectPrefab, hitList[0].pose.position, hitList[0].pose.rotation);
            }*/
        }
#else   //端末用
        if (Input.touchCount > 0)//タッチ入力があった場合の入力数
        {
            var touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)//タッチしているかどうか
            {
                if (raycastManager.Raycast(touch.position, hitList, TrackableType.Planes))
                {
                    SetMesenshi(hitList[0].pose.position);
                }
                else if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    return;
                }
            }
        }
#endif
    }
    void SetMesenshi(Vector3 position)
    {
        mesenshi.transform.position = position;
    }
}
