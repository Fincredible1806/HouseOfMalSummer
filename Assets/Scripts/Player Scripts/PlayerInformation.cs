using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public Dictionary<string, AbstractInteractable> playerInventory = new Dictionary<string, AbstractInteractable>();
    public List<string> noteInfos = new List<string>();
    public AudioClip startClip;
}
