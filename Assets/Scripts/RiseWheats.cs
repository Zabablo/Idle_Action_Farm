using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RiseWheats : MonoBehaviour
{
    private Vector3 growthEnd;
    private Vector3 offset = new Vector3(0f, 0.2f, 0f);

    [SerializeField]
    private GameObject fieldArea;
    [SerializeField]
    private GameObject prefabWheat;
    [SerializeField]
    private GameObject prefabHaystack;
    private GameObject wheat;
    private GameObject haystack;
    [SerializeField] private PlayerAnimationManager animationManager;

    void Start()
    {
        growthEnd = new Vector3(0.03f, 0.03f, 0.03f);
        CreateWheat();
    }

    public void CreateWheat()
    {
        wheat = Instantiate(prefabWheat);
        wheat.transform.SetParent(transform, false);
        Growth();
    }

    public void Growth()
    {
        wheat.transform.DOScale(growthEnd, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (wheat != null)
        {
            if (wheat.transform.localScale == growthEnd)
            {
                Destroy(wheat);
                haystack = Instantiate(prefabHaystack);
                haystack.transform.SetParent(transform, false);
                haystack.transform.localPosition = haystack.transform.localPosition + offset;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (haystack != null)
        {
            if (other.transform.name == haystack.name)
            {
                CreateWheat();
            }
        }
    }
}
