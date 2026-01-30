using UnityEngine;

namespace Assets.Scripts.Items
{
    public class Item : ScriptableObject
    {
        public string Name;

        [TextArea]
        public string Description;

        //public Sprite Icon;
    }
}
