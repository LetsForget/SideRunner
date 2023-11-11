using UnityEngine;

namespace Movement.Crawling
{
    [CreateAssetMenu(menuName = "Assets/Movement/Crawl config", fileName = "Crawl config")]
    public class CrawlConfig : ScriptableObject
    {
        /// <summary>
        /// Duration the player will be crawling
        /// </summary>
        [field: SerializeField] public float CrawlTime { get; private set; }
    }
}