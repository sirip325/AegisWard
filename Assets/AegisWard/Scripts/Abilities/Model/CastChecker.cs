namespace AegisWard.Scripts.Abilities.Model
{
    public abstract class CastChecker : ICastChecker
    {
        protected ICastChecker _nextChecker;
    
        public void SetNext(ICastChecker next)
        {
            _nextChecker = next;
        }

        public abstract bool Check(IAbility ability);
    }
}
