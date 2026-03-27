using System;

namespace Vakuu.Engine.Statuses
{
    internal sealed class Strength : IStatus
    {
        public string Name => "Strength";

        public void OnActionTakenAgainst(ActionBuilder stateMutationBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
