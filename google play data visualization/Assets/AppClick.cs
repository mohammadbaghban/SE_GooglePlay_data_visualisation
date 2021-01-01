
using UnityEngine;
using UnityEngine.UI;

public class AppClick : MonoBehaviour
{
    public DefaultNamespace.Application application = null;

    public GameObject appPanel; 
    public Text appText;
    public Text appDownloadNumber;

    private bool panelIsActive = false;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnMouseOver(){
        
        if (Input.GetMouseButtonDown(0)) 
        {
            if (application != null)
            {
                appPanel.SetActive(true);
                appText.text = application.Name;
                appDownloadNumber.text = application.Installs.ToString();
                panelIsActive = true;
            }
        }
    }
}
