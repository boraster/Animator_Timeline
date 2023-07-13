
    using UnityEngine;
    using UnityEngine.Playables;

    public class SubtitleClip :PlayableAsset
    {
        [SerializeField] private string subtitle;
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
         var subtitlePlayable =   ScriptPlayable<SubtitleBehavior>.Create(graph);
         var subtitleBehavior = subtitlePlayable.GetBehaviour();
         subtitleBehavior.subtitle = subtitle;

         return subtitlePlayable;
        }
    }
