using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameDrinker.GentleUI
{
    [RequireComponent(typeof(Image))]
    public class CardUIBehaviour : MonoBehaviour
    {
        public Image img;

        [SerializeField]
        private Text number;
        public int Number
        {
            set { number.text = value.ToString(); }
        }


        protected virtual void Awake()
        {
            img = GetComponent<Image>();
        }

        public void ChangeSprite(Sprite sp, int n)
        {
            img.sprite = sp;
            Number = n;
        }
        
    }
}