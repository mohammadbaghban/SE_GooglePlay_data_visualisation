
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

public class AppClick : MonoBehaviour
{
    public DefaultNamespace.Application application = null;

    public GameObject appPanel; 
    public Text appText;
    public Text appDownloadNumber;
    public Text appGenre;
    public Text appRating;
    public Text appCategory;
    public Dictionary<CategoriesEnum, Color> categoryToColor;

    private bool panelIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        var loadChart = GameObject.Find("Load Chart").GetComponent<LoadChart>();
        if (loadChart != null)
        {
            categoryToColor = loadChart.categoryToColor;
        }
        else
        {
            categoryToColor = GameObject.Find("Load Chart").GetComponent<LoadTopApps>().categoryToColor;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey ("enter")) {
            appPanel.SetActive(false);
        }
    }
    
    void OnMouseOver(){
        
        if (Input.GetMouseButtonDown(0)) 
        {
            if (application != null)
            {
                appPanel.SetActive(true);
                appText.text = application.Name;
                appDownloadNumber.text = application.Installs.ToString();
                appRating.text = application.Rating.ToString();
                appCategory.text = application.Category.ToString();
                var tempColor = categoryToColor[application.Category];
                tempColor.a = 0.8f;
                appPanel.GetComponent<Image>().color = tempColor;
            }
        }
    }
}
