namespace TheLine.ObjectPool
{
    public class AbilityObjectPool : TheLine.ObjectPool.ObjectPool<TheLine.Ability>
    {
        void Awake()
        {
            Initialize();
        }

        new void Initialize()
        {
            base.Initialize();
            for (int i = 0; i < objectCount; i++)
            {
                objects[i].Initialize(endPoint.position);
            }
        }
    }
}