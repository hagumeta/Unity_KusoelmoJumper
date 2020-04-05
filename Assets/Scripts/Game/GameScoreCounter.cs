using UnityEngine;

namespace Game.Controllers
{
    public class GameScoreCounter : MonoBehaviour
    {
        [SerializeField] private StartPoint startPoint;
        [SerializeField] private float ScoreRateFromDistance = 1f;

        private StageController stageController;
        private float distance;
        private int score;
        public int AdditionalScore;

        private void Start()
        {
            this.stageController = FindObjectOfType<StageController>();
        }

        private void Update()
        {
            this.UpdateScore();
        }

        private void UpdateScore()
        {
            if (this.startPoint.GetActor != null)
            {
                this.distance = Vector3.Distance(this.startPoint.transform.position, this.startPoint.GetActor.transform.position);
                this.score = Mathf.FloorToInt(this.AdditionalScore + this.distance * this.ScoreRateFromDistance);
            }
            this.stageController.GameScore.Score = this.score;
        }
    }
}
