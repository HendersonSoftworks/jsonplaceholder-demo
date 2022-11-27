using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Net.Http;
using System.Threading.Tasks;
using System;

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
        // Testing
        // Instantiate PlaceholderPhotos object 
        //PlaceholderPhotos placeholderPhotos = new PlaceholderPhotos();
        // Set currentJSON
        //GetPlaceholderPhotos(sharedClient, 1);
        // Serialise PlaceholderPhotos object
        //placeholderPhotos = JsonUtility.FromJson<PlaceholderPhotos>(currentJSON);
        // 
        //Debug.Log(placeholderPhotos.thumbnailUrl);
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

    static async Task GetAsyncTest(HttpClient httpClient)
    {
        using HttpResponseMessage response = await httpClient.GetAsync("todos/3");

        //Debug.Log(response.EnsureSuccessStatusCode());

        var jsonResponse = await response.Content.ReadAsStringAsync();

        Debug.Log($"{jsonResponse}\n");
        Debug.Log($"{jsonResponse}\n");

        // Expected output:
        //   GET https://jsonplaceholder.typicode.com/todos/3 HTTP/ 1.1
        //   {
        //     "userId": 1,
        //     "id": 3,
        //     "title": "fugiat veniam minus",
        //     "completed": false
        //   }
    }

    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
    };

    static async Task GetPlaceholderPhotos(HttpClient httpClient, int id)
    {
        using HttpResponseMessage response = await httpClient.GetAsync("photos/" + id.ToString());

        //Debug.Log(response.EnsureSuccessStatusCode());

        var jsonResponse = await response.Content.ReadAsStringAsync();

        //Debug.Log($"{jsonResponse}\n");

        currentJSON = $"{jsonResponse}\n";
    }

    [Serializable]
    private class PlaceholderPhotos
    {
        public int albumId;
        public int id;
        public string title;
        public string url;
        public string thumbnailUrl;
    }
}