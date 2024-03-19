using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.Presentation.CardView
{
    public class CardView : MonoBehaviour
    {
        public _Source.Core.CardInstance.CardInstance cardInstance;

        public void Init(_Source.Core.CardInstance.CardInstance cardInstance)
        {
            this.cardInstance = cardInstance;
        }

    }
}
