using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class DialogueManager : MonoBehaviour {

        public TextMeshProUGUI nameText;
        public TextMeshProUGUI dialogueText;

        public Animator animator;

        private Queue<string> names;
        private Queue<string> sentences;

        // Use this for initialization
        void Start () {
            names = new Queue<string>();
            sentences = new Queue<string>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                DisplayNextSentence();
                
            }
            
        }

        public void StartDialogue (Dialogue dialogue)
        {
            animator.SetBool("IsOpen", true);

            names.Clear();
            
            foreach (string name in dialogue.names)            
            {
                names.Enqueue(name);
            }

            sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
            
        }
        
        public void DisplayNextSentence ()
        {
            
            if (sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string name = names.Dequeue();
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeName(name));
            StartCoroutine(TypeSentence(sentence));
        }

        IEnumerator TypeName (string name)
        {
            nameText.text = "";
            foreach (char letter in name.ToCharArray())
            {
                nameText.text += letter;
                yield return null;
            }
        }
        IEnumerator TypeSentence (string sentence)
        {
            dialogueText.text = "";
            foreach (char letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }
        }

        public void EndDialogue()
        {
            animator.SetBool("IsOpen", false);
        }

    }
}