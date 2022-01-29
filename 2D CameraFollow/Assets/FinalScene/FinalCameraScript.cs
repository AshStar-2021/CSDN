using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCameraScript : MonoBehaviour
{
    Transform target;
    [SerializeField] Vector3 offset;//镜头中心相对于玩家的偏移
    [SerializeField] float smoothSpeed;//缓动速度

    float cameraHalfWidth, cameraHalfHeight;
    float topLimit, bottomLimit, leftLimit, rightLimit;//摄像机活动的范围

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        cameraHalfHeight = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().orthographicSize;
        cameraHalfWidth = cameraHalfHeight * Screen.width / Screen.height;

        refreshBoundary(GameObject.Find("CameraBoundary/1").GetComponent<BoxCollider2D>());
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition = new Vector3(
            Mathf.Clamp(desiredPosition.x, leftLimit, rightLimit),
            Mathf.Clamp(desiredPosition.y, bottomLimit, topLimit),
            desiredPosition.z
            );

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    public void refreshBoundary(BoxCollider2D boundary)
    {
        leftLimit = boundary.transform.position.x - boundary.size.x / 2 + boundary.offset.x + cameraHalfWidth;
        rightLimit = boundary.transform.position.x + boundary.size.x / 2 + boundary.offset.x - cameraHalfWidth;
        bottomLimit = boundary.transform.position.y - boundary.size.y / 2 + boundary.offset.y + cameraHalfHeight;
        topLimit = boundary.transform.position.y + boundary.size.y / 2 + boundary.offset.y - cameraHalfHeight;
    }
}