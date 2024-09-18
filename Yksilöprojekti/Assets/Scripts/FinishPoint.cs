using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
    [SerializeField] bool goNextLevel;
    [SerializeField] string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            SceneController.instance.NextLevel();

            //if (goNextLevel)
            //{
                
            //}
            //else
            //{
            //    SceneController.instance.LoadScene(levelName);
            //}
        }
    }
}
