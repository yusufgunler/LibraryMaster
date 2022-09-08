using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StackMechanic : MonoBehaviour
{
    public static StackMechanic Instance;
    public float movementDelay = 0.25f;
    public List<GameObject> cubes = new List<GameObject>();
    private Vector3 carryingPoint;
    public int maxCap = 5;
    

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            MoveListElements();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            MoveOrigin();
        }
    }

    public void StackCube(GameObject other, int index)
    {
        if (cubes.Count <= maxCap )
        {
            float randomRange = Random.Range(0f, 10f);
            other.transform.parent = transform;
            carryingPoint = cubes[index].transform.localPosition;
            carryingPoint.y += 1;
            carryingPoint.z = -1;
          
            other.transform.localPosition = carryingPoint;

            cubes.Add(other);
        }
        StartCoroutine(MakeObjectsBigger());
       
    }
    public IEnumerator MakeObjectsBigger()
    {
        for (int i = cubes.Count -1; i > 0; i--)
        {
            int index = i;
            Vector3 scale = new Vector3(1,1,1);
            scale *= 1.5f;

            cubes[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
             cubes[index].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            yield return new WaitForSeconds(0.05f);


        }

    }
    public IEnumerator DropMoney(GameObject dropArea)
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            cubes[i].transform.parent = dropArea.transform;
            cubes[i].tag = "Untagged";
            cubes.RemoveAt(i);
            Debug.Log(i);
            yield return new WaitForSeconds(.1f);
        }
        
    }

    private void MoveListElements()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[i - 1].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, movementDelay);

        }
    }
    private void MoveOrigin()
    {
        for (int i = 1; i < cubes.Count; i++)
        {
            Vector3 pos = cubes[i].transform.localPosition;
            pos.x = cubes[0].transform.localPosition.x;
            cubes[i].transform.DOLocalMove(pos, 0.70f );

        }
    }
}
