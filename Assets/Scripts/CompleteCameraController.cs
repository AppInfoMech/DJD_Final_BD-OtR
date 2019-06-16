using UnityEngine;
using System.Collections;

public class CompleteCameraController : MonoBehaviour
{

    public Transform player;
    public float offset = 285f;


    private Vector3 followVec = new Vector3();         


    void LateUpdate()
    {
        followVec.x = player.position.x + offset;
        followVec.y = this.transform.position.y;
        followVec.z = this.transform.position.z;
        this.transform.position = followVec;
    }
}
