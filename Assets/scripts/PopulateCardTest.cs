using UnityEngine;
using UnityEngine.UI;

public class PopulateCard : MonoBehaviour
{
    [SerializeField] private Text childText;

    // Start is called before the first frame update
    void Start()
    {
        childText = GetComponentInChildren<Text>();
        childText.text = APIHelper.GetNewPhoto(1).title;
    }
}
