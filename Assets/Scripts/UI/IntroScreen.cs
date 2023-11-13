using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class IntroScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup[] images;
        [SerializeField] private float fadeOutTime;
        [SerializeField] private float sceneTransferDelay;
        
        private int currentIndex = 0;
        private bool completed;
        
        private void Start()
        {
            AppearPicture();
        }

        private void Update()
        {
            if (completed)
            {
                return;
            }

            if (Input.anyKeyDown)
            {
                AppearPicture();
            }
        }

        private void AppearPicture()
        {
            if (completed)
            {
                return;
            }
            
            if (currentIndex >= images.Length)
            {
                completed = true;
                
                var sequence = DOTween.Sequence();
                
                foreach (var image in images)
                {
                    sequence.Insert(0,image.DOFade(0, fadeOutTime));
                }
                
                sequence.InsertCallback(fadeOutTime + sceneTransferDelay,
                    () => SceneManager.LoadSceneAsync("PlayScene"));
                
                return;    
            }

            images[currentIndex].DOFade(1, fadeOutTime);
            currentIndex++;
        }
    }
}