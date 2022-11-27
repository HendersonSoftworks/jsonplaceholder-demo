using UnityEngine;
using UnityEngine.UI;

public class InfiniteScroll : MonoBehaviour
{
    // Debug
    [SerializeField] private float scrollVal;
    [SerializeField] private int cardNum;

    // Private
    [SerializeField] private GameObject infiniteScrollPage;
    [SerializeField] private GameObject verticalCardBase;
    [SerializeField] private GameObject contentPanel;

    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Scrollbar scrollbarVert;

    [SerializeField] public static string currentJSON;

    private void Start()
    {
        // Populate current cards
        Text[] childTextFields = GetComponentsInChildren<Text>();
        for (int i = 1; i < childTextFields.Length; i++)
        {
            //childTextFields[i].text = APIHelper.GetNewPhoto(i).title;
            //Debug.Log(APIHelper.GetNewPhoto(i).title);
        }
    }

    private void Update()
    {
        // Debugging
        scrollVal = scrollbarVert.value;
        cardNum = contentPanel.GetComponentsInChildren<HorizontalLayoutGroup>().Length;

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
            // If card is even, reverse arrangment
            if (i % 2 == 0)
            {
                newCard.GetComponent<HorizontalLayoutGroup>().reverseArrangement = true;
            }
        }
    }
}