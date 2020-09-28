using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject posX;
    public GameObject negX;
    public GameObject posY;
    public GameObject negY;
    public GameObject player;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private void Awake() { GetMinMaxValues(); }

    // Update is called once per frame
    void Update()
    {
        transform.position = GetClampedPosition();
    }

    private Vector3 GetClampedPosition()
    {

        float xPos, yPos;

        xPos = Mathf.Clamp(player.transform.position.x, minX, maxX);
        yPos = Mathf.Clamp(player.transform.position.y, minY, maxY);

        return new Vector3(xPos, yPos, transform.position.z);

    }

    private void GetMinMaxValues()
    {

        minX = (negX != null) ? negX.transform.position.x : -1;
        maxX = (posX != null) ? posX.transform.position.x : 1;
        minY = (negY != null) ? negY.transform.position.y : -1;
        maxY = (posY != null) ? posY.transform.position.y : 1;

    }

}
