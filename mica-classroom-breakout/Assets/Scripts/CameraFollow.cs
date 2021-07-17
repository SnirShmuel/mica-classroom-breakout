using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField]
    private Vector2 cameraSensitivity = Vector2.one;
 
    [SerializeField]
    private float zoomSensitivity = 1.0f;
 
    [SerializeField]
    private Vector2 zoomClamp = new Vector2(0.5f, 25.0f);
 
    [SerializeField]
    private float zoomDamp = 0.05f;
 
    [SerializeField]
    private float cameraRadius = 0.5f;
 
    private float targetZoom = 5.0f, zoom = 5.0f;
    private float zoomVelocity = 0.0f;
 
    private void Update()
    {
        Zoom();
    }
 
 
    private void Zoom()
    {
        targetZoom += Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
 
        Ray ray = new Ray(transform.parent.position, -transform.parent.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, targetZoom))
        {
            zoom = Mathf.SmoothDamp(zoom, hit.distance, ref zoomVelocity, zoomDamp);
            zoom -= cameraRadius;
        }
        else
        {
            zoom = Mathf.SmoothDamp(zoom, targetZoom, ref zoomVelocity, zoomDamp);
        }
        zoom = Mathf.Clamp(zoom, zoomClamp.x, zoomClamp.y);
        transform.localPosition = Vector3.back * zoom;
 
    }
}
