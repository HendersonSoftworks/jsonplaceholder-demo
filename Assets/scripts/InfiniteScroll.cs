using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InfiniteScroll : MonoBehaviour
{
    // Debug
    [SerializeField] private float scrollVal;

    // Private
    [SerializeField] private GameObject infiniteScrollPage;
    [SerializeField] private GameObject verticalCardBase;
    [SerializeField] private GameObject contentPanel;

    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Scrollbar scrollbarVert;
    

    private void Update()
    {
        // Show scrollval in editor for debugging
        scrollVal = scrollbarVert.value;
        
        // Check if user has reached the end of the page, if so, spawn 20 more cards and force the canvas to update.
        if (scrollVal <= 0.1)
        {
            AddMoreCards();
            scrollVal = 1; // reset scrollval to 1 temporarily to avoid spawning more cards than necessary. It would probably be better to implement event handlers here.
            Canvas.ForceUpdateCanvases();
        }
    }

    private void AddMoreCards()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject newCard = Instantiate(verticalCardBase);
            newCard.transform.SetParent(contentPanel.transform, false);
        }
    }
}
