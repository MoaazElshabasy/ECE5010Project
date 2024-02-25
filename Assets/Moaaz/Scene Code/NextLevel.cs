using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public SpriteRenderer popUpText;
    private bool Triggered;
    public int level = 0;

    private void Start()
    {
        popUpText.enabled = false;
    }

    private void Update()
    {
        if (Triggered && Input.GetKeyDown(KeyCode.E))
        {
            Action(level);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            popUpText.enabled = true;
            Triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            popUpText.enabled = false;
            Triggered = false;
        }
    }

    private void Action(int level)
    {

        SceneManager.LoadScene(level);

    }


}
