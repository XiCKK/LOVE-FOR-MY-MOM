using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCloseTrigger : MonoBehaviour
{
    [SerializeField] private GameObject floor;

    private void Start()
    {
        floor.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            floor.SetActive (true);
        }
    }
}
