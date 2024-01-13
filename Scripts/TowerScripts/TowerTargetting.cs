using System.Collections.Generic;
using UnityEngine;

public class TowerTargetting : MonoBehaviour
{
    private List<Transform> targets = new();
    private Transform primaryTarget;

    //finds an important target to focus on and caches the reference
    public Transform Target
    {
        get
        {
            if (primaryTarget == null)
            {
                // clean the targets list by removing each target transform
                // that is nulled due to the gameobject already being destroyed
                targets.RemoveAll(eachTarget => { return eachTarget == null; });

                if (targets.Count > 0)
                {
                    // find the first element that would cause the lambada to return true
                    // you can change this later to allow the tower to prioritize different targets
                    primaryTarget = targets.Find(target => { return true; });
                }
            }

            return primaryTarget;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            targets.Add(other.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //in case it was the primary target that leaves the Tower's range
        if (ReferenceEquals(primaryTarget, other.transform))
        {
            primaryTarget = null;
        }

        targets.Remove(other.transform);
    }
}
