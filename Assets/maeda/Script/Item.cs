using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Asset.maeda.script
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private Sign item;
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI name;
        [SerializeField] private TextMeshProUGUI exep;

        // Start is called before the first frame update
        void Start()
        {
            image.sprite = item.signImage;
            name.text = item.signName;
            exep.text = item.exposition;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}