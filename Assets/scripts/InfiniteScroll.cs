using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    // Debug
    [SerializeField] private float scrollVal;

    // Private
    [SerializeField] private GameObject infiniteScrollPage;
    [SerializeField] private GameObject verticalCardBase;
    [SerializeField] private GameObject contentPanel;
    [SerializeField] private Scrollbar scrollbarVert;

    private void Update()
    {
        //Canvas.ForceUpdateCanvases();

        scrollVal = scrollbarVert.value;
        
        
    }
}
