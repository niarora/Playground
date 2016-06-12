namespace Playground.Problems
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BuildDependency
    {
        public string Build { get; private set; }
        public string DependentOn { get; private set; }

        public BuildDependency(string build, string dependentOn)
        {
            this.Build = build;
            this.DependentOn = dependentOn;
        }
    }

    public class BuildOrder
    {
        private string[] Builds { get; set; }
        private IEnumerable<BuildDependency> BuildDependencies { get; set; }

        public BuildOrder(string[] builds, IEnumerable<BuildDependency> dependecies)
        {
            this.Builds = builds;
            this.BuildDependencies = dependecies;
        }
        
        // An O(N + M) algorithm for establishing a build order where builds can have dependencies on each other.
        // N is number of builds and M is the number of dependencies.
        // This method 
        public IEnumerable<string> GetBuildOrder()
        {
            // Create two dictionaries. One for build 'foo' depends on 'b1, b2.
            // Other 'bar' can build 'b3, b4'.
            var dependentOn = new Dictionary<string, ICollection<string>>();
            var canBuild = new Dictionary<string, ICollection<string>>();
            foreach (var build in this.Builds) // O(N)
            {
                dependentOn.Add(build, new List<string>());
                canBuild.Add(build, new List<string>());
            }

            foreach (var dependency in BuildDependencies) // O(M)
            {
                dependentOn[dependency.Build].Add(dependency.DependentOn);
                canBuild[dependency.DependentOn].Add(dependency.Build);
            }

            // Can build builds where there are no dependecies. O(N)
            var canBuildBuilds = dependentOn
                    .Where(dependency => dependency.Value.Count == 0)
                    .Select(pair => pair.Key).ToList();
            var buildsBuilt = new List<string>();
            bool buildsAdded;
            do
            {
                buildsAdded = false;
                var newBuildsToBuild = new List<string>();
                // Remove builds that are now built (added to buildsBuilt list) from the dependentOn dictionary.
                // For each build 'X' that can be built, 'canBuild[X]' value is the list of builds that depend on 'X'.
                // For each 'canBuild' value 'Y' for X, update 'dependentOn[Y]' by removing 'X' from the dependentOn[Y] value.
                // If a newly updated dependentOn[Y] has zero values, that build is not ready to be built in the next pass.
                if (canBuildBuilds.Count > 0)
                {
                    buildsAdded = true;
                    buildsBuilt.AddRange(canBuildBuilds); // Building the new builds.
                    // This inner loop seems like N * M, but it only executes M times.
                    // Since dictionary access is constant and we are only flowing through the dependency edges once,
                    // the total iterations is M.
                    foreach (var build in canBuildBuilds)
                    {
                        dependentOn.Remove(build); // Remove builds that were built.
                        // Update the depends on list to remove the dependecies just built.
                        foreach (var b in canBuild[build])
                        {
                            dependentOn[b].Remove(build);
                            if (dependentOn[b].Count == 0)
                            {
                                newBuildsToBuild.Add(b);
                            }
                        }
                    }
                }

                canBuildBuilds = newBuildsToBuild;
            } while (buildsAdded);

            if (buildsBuilt.Count != this.Builds.Length)
            {
                throw new InvalidOperationException("Builds have a circular dependency.");
            }

            return buildsBuilt;
        }
    }
}