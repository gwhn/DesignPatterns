using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DesignPatterns.Creational.AbstractFactory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Creational.Builder
{
    /// <summary>
    /// Separate the construction of a complex object from its representation 
    /// so that the same construction process can create different representations.
    /// </summary>
    [TestClass]
    public class BuilderTests
    {
        [TestMethod]
        public void Test()
        {
            var director = new Director();

            var builderA = new ConcreteBuilderA();
            director.Construct(builderA);
            Console.WriteLine(builderA.Product);

            var builderB = new ConcreteBuilderB();
            director.Construct(builderB);
            Console.WriteLine(builderB.Product);
        }
    }

    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildA();
            builder.BuildB();   
        }
    }

    public abstract class Builder
    {
        public Product Product = new Product();

        public abstract void BuildA();
        public abstract void BuildB();
    }

    public class ConcreteBuilderA : Builder
    {
        public override void BuildA()
        {
            Product.Add("ConcreteBuilderA.BuildA part");
        }

        public override void BuildB()
        {
            Product.Add("ConcreteBuilderA.BuildB part");
        }
    }

    public class ConcreteBuilderB : Builder
    {
        public override void BuildA()
        {
            Product.Add("ConcreteBuilderB.BuildA part");
        }

        public override void BuildB()
        {
            Product.Add("ConcreteBuilderB.BuildB part");
        }
    }

    public class Product
    {
        private readonly List<string> _parts = new List<string>();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var part in _parts)
            {
                sb.AppendLine(part);
            }
            return sb.ToString();
        }
    }
}
