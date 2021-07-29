using UnityEngine;

namespace PocketWarriors
{
    public interface IPerform
    {
        ActionRequirement Requirement {get;}
        void Initialize();
        void Check();
        void Perform();
    }
}