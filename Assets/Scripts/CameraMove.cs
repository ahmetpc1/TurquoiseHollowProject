using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetPos=target.position;
        targetPos.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position,targetPos,speed*Time.fixedDeltaTime);
    }
}
