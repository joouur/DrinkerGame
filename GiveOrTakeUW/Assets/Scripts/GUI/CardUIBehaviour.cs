using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameDrinker.GentleUI
{
    public class CardUIBehaviour : MonoBehaviour
    {
        public Image img;

        protected virtual void Awake()
        {
            img = GetComponent<Image>();
        }

        public void ChangeSprite(Sprite sp)
        {
            img.sprite = sp;
        }
        
    }
}