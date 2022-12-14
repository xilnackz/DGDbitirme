using UnityEngine;

namespace Dialogue
{
    public class DialogueTrigger : MonoBehaviour {

        public Dialogue dialogue;

        public void OnTriggerStay (Collider other)
        {
            if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
            
        }

    }
}