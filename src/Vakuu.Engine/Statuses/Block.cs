using System;

namespace Vakuu.Engine.Statuses
{
    internal sealed class Block : IStatus
    {
        public string Name => "Block";

        public short Amount => throw new System.NotImplementedException();

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
