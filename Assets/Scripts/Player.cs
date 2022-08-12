using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class Player : MonoBehaviour
{
    public int haystackCount;
    private List<GameObject> haystacks = new List<GameObject>();
    private Vector3 backpack = new Vector3(0f, 0.9f, -0.2f);
    private Vector3 rotateBackpack = new Vector3(0f, 0f, 0f);
    private Vector3 scaleBackpack = new Vector3(0.3f, 0.15f, 0.2f);
    private Vector3 salePoint = new Vector3(-20f, 0f, 14f);
    public int coinsCounter;


    private void Start()
    {
        haystackCount = 0;
    }

    public void HaystackInstallation(GameObject newHeystack)
    {
        newHeystack.transform.DOLocalMove(backpack, 1f);
        newHeystack.transform.DOLocalRotate(rotateBackpack, 1f);
        newHeystack.transform.DOScale(scaleBackpack, 1f);
        haystackCount += 1;
        backpack.y = backpack.y + newHeystack.transform.localScale.y / 2;
        haystacks.Add(newHeystack);
    }

    public void HaystackSell()
    {
        GameObject lastHaystack;
        lastHaystack = haystacks.Last();
        lastHaystack.transform.DOMove(salePoint, 2f);
        haystacks.RemoveAt(haystacks.Count - 1);
        backpack.y -= lastHaystack.transform.localScale.y;
        StartCoroutine(DestroyHaystack(lastHaystack));
        haystackCount -= 1;
        coinsCounter += 15;
    }

    IEnumerator DestroyHaystack(GameObject haystack)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(haystack);
    }
}
