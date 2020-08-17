using UnityEngine;

public class TorInteraction : MonoBehaviour
{
    public GameObject spieler;
    int ychange;

    // Start is called before the first frame update
    void Start()
    {
        ychange = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if ((spieler.transform.position - transform.position).magnitude < 2 && Input.GetKeyDown(KeyCode.E))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + ychange, transform.position.z);
            ychange *= -1;
        }
    }
}
