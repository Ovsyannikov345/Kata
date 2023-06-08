using System;
using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static Dictionary<string, string[]> ExpandDependencies(Dictionary<string, string[]> dependencies)
    {
        string[] keys = dependencies.Keys.ToArray();

        // Expanding dependencies for each node.
        for (var i = 0; i < dependencies.Count; i++)
        {
            string currentNode = keys[i];

            // Expanding each dependency of current node.
            for (var j = 0; j < dependencies[currentNode].Length; j++)
            {
                // Looking for dependency that will be expanded.
                string[] expandedDependencies = dependencies[dependencies[currentNode][j]];

                // Preventing the circular dependency.
                if (expandedDependencies.Contains(currentNode))
                {
                    throw new InvalidOperationException();
                }

                // Adding new dependencies for current node (they will also be expanded later).
                dependencies[currentNode] = dependencies[currentNode].Union(expandedDependencies).ToArray();
            }
        }

        return dependencies;
    }
}