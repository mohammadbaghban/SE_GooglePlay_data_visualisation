
using UnityEngine;

public class PanelScript : MonoBehaviour
{
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
            
            gameObject.SetActive(false);
            
        }
    }
}
