using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    [SerializeField]
    private GameObject floor;
    private Animator anim;
    [SerializeField] private AudioClip valveEffect;
    private bool check;
    private int keyPressCheck;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        floor.SetActive(false);
    }
    private void Update()
    {
        if (check == true && Input.GetKey(KeyCode.E) && GetComponent<PlayerMovement>().isGrounded())
        {
            SoundManager.instance.PlaySound2(valveEffect);
            anim.SetTrigger("ValveSpin");
            floor.SetActive(true);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            check = true;
        }
        else
        {
            check = false;
        }
    }
}
