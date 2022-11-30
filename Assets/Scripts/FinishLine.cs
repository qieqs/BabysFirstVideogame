using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FinishLine : MonoBehaviour
{
    public Image youWin;
    private Vector2 imagesize;

    private bool youwon;

    public GameObject leftsparkler;
    public GameObject rightsparkler;
    public AudioSource audiosource;
    public AudioClip pop;
    void Start()
    {
        GameObject go1 = new GameObject();
        go1.name = "go1";
        imagesize = new Vector2(youWin.transform.localScale.x, youWin.transform.localScale.z);
        youWin.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(youwon == true)
        {
            if (Input.GetKeyDown("r"))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(youwon == false)
            {
                audiosource.PlayOneShot(pop, 1f);
                leftsparkler.SetActive(true);
                rightsparkler.SetActive(true);
                Debug.Log("je hebt gewonnen gefeliciteerd!!!!!");
                StartCoroutine(grow());
                youwon = true;
            }
        }
    }

    private IEnumerator grow()
    {
        youWin.gameObject.SetActive(true);
        float timeElapsed = 0;
        while (timeElapsed < 0.7f)
        {
            youWin.transform.localScale = Vector2.Lerp(new Vector2(0,0), imagesize, timeElapsed / 0.7f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        youWin.transform.localScale = imagesize;
    }
}
