using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    public MazePathGenerator MazePathGenerator;
    public MazePositioner MazePositioner;
    public MazePieceCreator MazePieceCreator;
    public Player Player;
    public ObjectPool ObjectPool;
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
        Container.BindInstance(ObjectPool).AsSingle();
        Container.BindInstance(TimeScale).AsSingle();
        Container.BindInstance(ScoreCounter).AsSingle();
        Container.BindInstance(PanelWorker).AsSingle();
        Container.BindInstance(DataWorker).AsSingle();
        Container.BindInstance(SkillTimeView).AsSingle();

    }
}