using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Vakuu.Engine
{
    public sealed class ActionBuilder
    {
        readonly Action executor;
        readonly float cost;

        readonly Dictionary<string, float> variables;
        readonly List<Action<ConcurrentDictionary<string, object?>>> reducers;

        public ActionBuilder(Action executor, string name, float cost)
        {
            this.executor = executor;
            this.cost = cost;
            variables = new Dictionary<string, float>();
            reducers = new List<Action<ConcurrentDictionary<string, object?>>>();
            Name = name;
            StaticPreconditions = new Dictionary<string, object>();
        }

        public Dictionary<string, object> StaticPreconditions { get; }

        public string Name { get; }

        public void AddVariableReducer(string name, float initialValue)
            => variables.Add(name, initialValue);

        public MountainGoap.Action Build()
        {
            throw new NotImplementedException();
        }
    }
}
