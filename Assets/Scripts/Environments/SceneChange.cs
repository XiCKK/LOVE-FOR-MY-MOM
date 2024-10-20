using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScenceController.instance.NextLevel();
        }
    }
}
