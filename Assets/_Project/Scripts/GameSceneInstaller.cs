using Zenject;
using TheLine.Maze;
using TheLine.UI;

namespace TheLine
{
    public class GameSceneInstaller : MonoInstaller
    {
        public MazePathGenerator MazePathGenerator;
        public MazePositioner MazePositioner;
        public MazePieceCreator MazePieceCreator;
        public TheLine.Player.Player Player;
        public TheLine.ObjectPool.MazePieceObjectPool MazePieceObjectPool;
        public TheLine.ObjectPool.AbilityObjectPool AbilityObjectPool;
        public TimeScale TimeScale;
        public ScoreCounter ScoreCounter;
        public PanelWorker PanelWorker;
        public DataWorker DataWorker;
        public SkillTimeView SkillTimeView;

        public override void InstallBindings()
        {
            Container.BindInstance(MazePathGenerator).AsSingle();
            Container.BindInstance(MazePositioner).AsSingle();
            Container.BindInstance(MazePieceCreator).AsSingle();
            Container.BindInstance(Player).AsSingle();
            Container.BindInstance(MazePieceObjectPool).AsSingle();
            Container.BindInstance(AbilityObjectPool).AsSingle();
            Container.BindInstance(TimeScale).AsSingle();
            Container.BindInstance(ScoreCounter).AsSingle();
            Container.BindInstance(PanelWorker).AsSingle();
            Container.BindInstance(DataWorker).AsSingle();
            Container.BindInstance(SkillTimeView).AsSingle();

        }
    }
}