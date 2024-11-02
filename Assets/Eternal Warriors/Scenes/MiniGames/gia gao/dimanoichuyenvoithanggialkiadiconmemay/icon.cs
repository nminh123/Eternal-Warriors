using UnityEngine;
//using UnityEngine.UI; 

public class ShowIconOnTrigger : MonoBehaviour
{
    public /*Image*/ GameObject icon;

    void Start()
    {
        icon.gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            icon.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            icon.gameObject.SetActive(false); 
        }
    }
}
