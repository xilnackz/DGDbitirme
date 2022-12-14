using UnityEngine;

namespace Dialogue
{
    [System.Serializable]
    public class Dialogue{

        [TextArea(3, 10)]
        public string[] names;

        [TextArea(3, 10)]
        public string[] sentences;

    }
}