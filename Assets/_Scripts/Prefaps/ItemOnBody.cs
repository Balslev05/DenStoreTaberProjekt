using UnityEngine;

public class ItemOnBody : MonoBehaviour
{
    public GameObject parent;
    void Start()
    {
        gameObject.transform.parent = parent.transform;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
