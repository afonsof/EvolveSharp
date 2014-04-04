[![Build Status](https://travis-ci.org/afonsof/EvolveSharp.png?branch=master)](https://travis-ci.org/afonsof/EvolveSharp)
[![Built with Grunt](https://cdn.gruntjs.com/builtwith.png)](http://gruntjs.com/)


<img src="http://afonsof.github.io/EvolveSharp/images/logo.png" width="150" />

A Genetic Algorithm Framework for .NET

<a href="http://afonsof.github.io/EvolveSharp" target="_blank">Visit our website</a>

## Getting Started

#### 1. Setting Up

Create a Console Application and install EvoleSharp using Nuget:

```
PM> Install-Package EvolveSharp
```

#### 2. Create a fitness function
In this simple example we are creating a fitness function to sum all genes of an individual
```c#
public class ExampleFitnessFunction : IFitnessFunction<double>
{
    public double Evaluate(IIndividual<double> individual)
    {
        var sum = 0.0;
        for (var i = 0; i < individual.Length; i++)
        {
            sum += individual[i];
        }
        return sum;
    }
}
```

#### 3. Instantiate the GeneticAlgorithm class and call the Evolve method
You can set 3 parameters:

1. Population count: How many individuals each population will have
2. Gene count: How many genes each individual will have
3. Generation count: How many generations will occour

```c#
class Program
{
    static void Main(string[] args)
    {
        const int populationCount = 100;
        const int generationCount = 10000;
        const int geneCount = 10;
       
        var ga = new GeneticAlgorithm(populationCount, geneCount, new ExampleFitnessFunction());
        ga.Evolve(generationCount);
    }
}
```

#### Other information

1. You can create your own mutation, selection, crossover and initializer class. You just need to inherit the respective interface.
2. You can set the ```Mutator```, ```CrossoverMethod```, ```Selector``` and ```Initializer``` after instantiate the ```GeneticAlgorithm``` class.
3. You can create and set your own reporter in ```GeneticAlgorithm``` class.

## Sample
Clone EvolveSharp and try the Travelling salesman problem sample

<img src="http://afonsof.github.io/EvolveSharp/images/tsp.png" />

## Contributing

Please use the issue tracker and pull requests.

## License
Copyright (c) 2014 Afonso França
Licensed under the MIT license.


[![Bitdeli Badge](https://d2weczhvl823v0.cloudfront.net/afonsof/evolvesharp/trend.png)](https://bitdeli.com/free "Bitdeli Badge")

