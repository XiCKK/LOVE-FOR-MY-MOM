using UnityEngine;
using System.Collections;
using Unity.VisualScripting.Dependencies.Sqlite;
public class CutoutSwitch : MonoBehaviour
{
    [SerializeField]
    private GameObject floor;
    private Animator anim;
    [SerializeField] private AudioClip switchOn;
    private bool check;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        floor.SetActive(true);
    }
    private void Update()
    {
        if (check == true && Input.GetKey(KeyCode.E))
        {
            SoundManager.instance.PlaySound2(switchOn);
            anim.SetTrigger("CutoutOn");
            floor.SetActive(false);
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
