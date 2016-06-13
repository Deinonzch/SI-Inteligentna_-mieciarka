using UnityEngine;
using System.Collections;

public class DestroySmietnik : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("Thrah"))
        {
            // Get longer in next Move call

            // Remove the Food
            Destroy(coll.gameObject);
        }
    }
}

