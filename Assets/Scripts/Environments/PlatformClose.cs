using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;
public class PlatformClose : MonoBehaviour
{
    [SerializeField] private Transform pointA, pointB;
    [SerializeField] private float speed;

    private Vector2 targetPos;

    void Start()
    {
        targetPos = pointB.position;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, pointA.position) < 0.1f) targetPos = pointB.position;
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
    }

}
