using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentManager : MonoBehaviour
{
    [SerializeField] Text pageNum;
    [SerializeField] Text pageName;

    [SerializeField] GameObject infiniteScrollPage;
    [SerializeField] GameObject animationPage;
    [SerializeField] GameObject model;
    [SerializeField] GameObject radialPage;

    public void ActivatePage1()
    {
        pageNum.text = "1";
        pageName.text = "Infinite Scroller";

        animationPage.SetActive(false);
        infiniteScrollPage.SetActive(true);
        model.SetActive(false);
        radialPage.SetActive(false);

    }

    public void ActivatePage2()
    {
        pageNum.text = "2";
        pageName.text = "Interlaced Model";

        animationPage.SetActive(true);
        infiniteScrollPage.SetActive(false);
        model.SetActive(true);
        radialPage.SetActive(false);

    }

    public void ActivatePage3()
    {
        pageNum.text = "3";
        pageName.text = "radial Menu";

        animationPage.SetActive(false);
        infiniteScrollPage.SetActive(false);
        model.SetActive(false);
        radialPage.SetActive(true);
    }

}
