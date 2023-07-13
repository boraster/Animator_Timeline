
    using TMPro;
    using UnityEngine.Playables;

    public class SubtitleBehavior :PlayableBehaviour
    {
        public string subtitle;

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            var displayedSubtitle = playerData as TextMeshProUGUI;
            displayedSubtitle.text = subtitle;
        }
    }
