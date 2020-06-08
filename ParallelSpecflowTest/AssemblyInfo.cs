using NUnit.Framework;
//this file is required for tests to run in parallel 
//This can just be created as just a class and then remove every thing and just add the line below
[assembly: Parallelizable(ParallelScope.Fixtures)]


