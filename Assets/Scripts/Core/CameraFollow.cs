using UnityEngine;
using UnityEngine.UIElements;

public class CameraFollow : MonoBehaviour
{
    //speed of camera follow
    [SerializeField]
    private float followSpeed;
    //yOffset
    [SerializeField]
    private float yOffset;
    [SerializeField]
    private float xOffset;
    public Transform target;



    private void Update()
    {
        //Camera Follow Player
        Vector3 newPos = new Vector3(target.position.x + xOffset, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime); 
    }

}
