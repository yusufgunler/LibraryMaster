using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BookCreator : MonoBehaviour
{
    [SerializeField] private Transform[] PaperPlace = new Transform[10];
    [SerializeField] private GameObject paper;
    [SerializeField] private float PaperDeliveryTime, YAxis;

    private void Start()
    {
        for (int i = 0; i < PaperPlace.Length; i++)
        {
            PaperPlace[i] = transform.GetChild(0).GetChild(i);
        }
        StartCoroutine(PrintPaper(PaperDeliveryTime));
    }

    public IEnumerator PrintPaper(float Time)
    {
        var CountPapers = 0;
        var PP_Index=0;
        while (CountPapers<100)
        {
            GameObject NewPaper = Instantiate(paper, new Vector3(transform.position.x, -3f, transform.position.z), Quaternion.identity, transform.GetChild(1));

            NewPaper.transform.DOJump(new Vector3(PaperPlace[PP_Index].position.x, PaperPlace[PP_Index].position.y+ YAxis, PaperPlace[PP_Index].position.z),2f,1,0.5f).SetEase(Ease.OutQuad);
            if (PP_Index <9)
            {
                PP_Index++;
            }
            else
            {
                PP_Index = 0;
                YAxis += 0.1f;

            }
            yield return new WaitForSeconds(Time);
        }

    }
}
