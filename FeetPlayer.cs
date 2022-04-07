using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetPlayer : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D Other)
    {
        {
            var tag = Other.gameObject.tag;
            if (tag == "Muerte")
            {
                Destroy(Other.gameObject);
            }

        }
    }
}