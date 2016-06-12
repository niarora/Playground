namespace Playground
{
    using System;
    using Playground.Extensions;
    using Playground.Problems;

    public static class Program
    {
        public static void Main()
        {
            var builds = new[] { "b0", "b1", "b2", "b3", "b4", "b5", "b6", "b7", "b8", "b9" };
            var dependencies = new BuildDependency[]
            {
                new BuildDependency(builds[0], builds[1]),
                new BuildDependency(builds[5], builds[2]),
                new BuildDependency(builds[7], builds[1]),
                new BuildDependency(builds[7], builds[3]),
                new BuildDependency(builds[2], builds[3]),
                new BuildDependency(builds[4], builds[8]),
                new BuildDependency(builds[2], builds[7]),
                new BuildDependency(builds[9], builds[1]),
                new BuildDependency(builds[1], builds[3]),
                new BuildDependency(builds[8], builds[6])
            };

            var buildOrder = new BuildOrder(builds, dependencies).GetBuildOrder();
            // b3, b6, b1, b8, b0, b7, b9, b4, b2, b5
            Console.WriteLine("Builds: {0}", builds.Length);
            buildOrder.WriteLine();
        }
    }
}