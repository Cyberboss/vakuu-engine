using System;

namespace Vakuu.Engine.Statuses
{
    internal sealed class Vulnerable : IStatus
    {
        public string Name => "Vulnerable";

        public void OnActionTakenAgainst(ActionBuilder stateMutationBuilder)
        {
            throw new NotImplementedException();
        }

        public void OnTurnStart(ActionBuilder stateMutationBuilder)
        {
            throw new NotImplementedException();
        }
    }
}
