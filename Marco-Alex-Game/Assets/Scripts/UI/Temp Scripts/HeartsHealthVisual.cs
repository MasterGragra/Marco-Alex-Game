using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartsHealthVisual : MonoBehaviour
{
//    [SerializeField] private Sprite fullheartSprite;
//    [SerializeField] private Sprite oneQuarterheartSprite;
//    [SerializeField] private Sprite halfheartSprite;
//    [SerializeField] private Sprite threeQuarterheartSprite;
//    [SerializeField] private Sprite EmptyheartSprite;

//    private List<HeartImages> heartImageList;
//    private HealthSystem heartSystem;

//    private void Awake()
//    {
//        heartImageList = new List<HeartImages>();
//    }
//    private void Start()
//    {
//        HealthSystem heartSystem = new HealthSystem(4);
//        //HeartSystem heartSystem = new HeartSystem(4);
//        createHeart(new Vector2(0, 0)).SetHeartPortion(1);
//        createHeart(new Vector2(15, 0)).SetHeartPortion(1);
//        createHeart(new Vector2(30, 0)).SetHeartPortion(2);
//    }

//    public void SetHeartSystem(HealthSystem heartSystem)
//    {
//        this.heartSystem = heartSystem;
//        List<HealthSystem.Heart> heartList = heartSystem.GetHeartList();
//        Vector2 heartAnchoredPosition = new Vector2(0, 0);

//        for(int i=0; i<heartList.Count; i++)
//        {
//            HealthSystem.Heart heart = heartList[i];
//            createHeart(new Vector2(0, 0)).SetHeartPortion(heart.GetPortionAmount());
//            heartAnchoredPosition += new Vector2(30, 0);
//        }
//    }
//    private Image createHeart(Vector2 anchoredPosition)
//    {
//        //Creating GameObject 
//        GameObject heartGameObject = new GameObject("Heart", typeof(Image));

//        //Setting the child of the transform
//        heartGameObject.transform.parent = transform;
//        heartGameObject.transform.localPosition = Vector3.zero;

//        //Locating and sizing Hearts
//        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
//        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(10, 10);

//        //Setting the heart sprite
//        Image heartImageUI = heartGameObject.GetComponent<Image>();
//        heartImageUI.sprite = fullheartSprite;

//        HeartImages heartImage = new HeartImages(heartImageUI);
//        heartImageList.Add(heartImage);

//        return heartImage;
//    }

//    public class HeartImages
//    {
//        private Image heartImage;
//        private HeartsHealthVisual heartsUIDisplay;

//        public HeartImages(Image heartImage)
//        {
//            this.heartImage = heartImage;
//        }
//        public HeartImages(HeartsHealthVisual heartsUIDisplay, Image heartImage)
//        {
//            this.heartsUIDisplay = heartsUIDisplay;
//            this.heartImage = heartImage;
//        }

//        public void SetHeartPortion(int portion)
//        {
//            switch (portion)
//            {
//                case 0:
//                    heartImage.sprite = heartsUIDisplay.fullheartSprite;
//                    break;
//                case 1:
//                    heartImage.sprite = heartsUIDisplay.threeQuarterheartSprite;
//                    break;
//                case 2:
//                    heartImage.sprite = heartsUIDisplay.halfheartSprite;
//                    break;
//                case 3:
//                    heartImage.sprite = heartsUIDisplay.oneQuarterheartSprite;
//                    break;
//                case 4:
//                    heartImage.sprite = heartsUIDisplay.EmptyheartSprite;
//                    break;
//            }
//        }
//    }
}
