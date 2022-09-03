using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.UI.Image;

public class TrajectoryCreator : MonoBehaviour
{
    [SerializeField] int dotsNumber;
    [SerializeField] GameObject dotsParent;
    [SerializeField] GameObject dotPrefab;
    [SerializeField] GameObject fakeBallPrefab;

    [SerializeField] float dotSpacing;
    [SerializeField][Range(.001f, .008f)] float dotMinScale;
    [SerializeField][Range(.01f, .14f)] float dotMaxScale;

    Transform[] dotsList;

    Vector2 pos;
    //dot pos
    float timeStamp;
    //--------------------------------
    void Start()
    {
        //hide trajectory in the start
        Hide();
        //prepare dots
        PrepareDots();
    }

    void PrepareDots()
    {
        dotsList = new Transform[dotsNumber];
        dotPrefab.transform.localScale = Vector3.one * dotMaxScale;

        float scale = dotMaxScale;
        float scaleFactor = scale / dotsNumber;

        for (int i = 0; i < dotsNumber; i++)
        {
            dotsList[i] = Instantiate(dotPrefab, null).transform;
            dotsList[i].parent = dotsParent.transform;

            dotsList[i].localScale = Vector3.one * scale;
            if (scale > dotMinScale)
                scale -= scaleFactor;
        }
    }

    public void UpdateDots(Vector3 ballPos, Vector2 forceApplied)
    {
        GameObject fakeB = Instantiate(fakeBallPrefab, ballPos, Quaternion.identity);
        fakeB.GetComponent<Rigidbody>().AddForce(forceApplied, ForceMode.Impulse);
        Physics.autoSimulation = false;
        timeStamp = dotSpacing;
        for (int i = 0; i < dotsNumber; i++)
        {
            Physics.Simulate(timeStamp);
            dotsList[i].position = fakeB.transform.position;
            timeStamp += dotSpacing;
        }
        Physics.autoSimulation = true;
        Destroy(fakeB);
    }

    public void Show()
    {
        dotsParent.SetActive(true);
    }

    public void Hide()
    {
        dotsParent.SetActive(false);
    }
}
