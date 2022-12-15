using UnityEngine;

namespace Dialogue
{
    public class OtoTrigger: MonoBehaviour {

        public Dialogue dialogue;

        public void OnTriggerEnter (Collider other)
        {
            if (other.CompareTag("Player"))
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
            
        }

        public void OnTriggerExit (Collider other)
        {
            if (other.CompareTag("Player"))
            {
                FindObjectOfType<DialogueManager>().EndDialogue();
            }
            
        }
    }
}