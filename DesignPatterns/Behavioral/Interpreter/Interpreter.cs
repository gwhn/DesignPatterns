using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatterns.Behavioral.Interpreter
{
    /// <summary>
    /// Given a language, define a representation for its grammar along with an interpreter 
    /// that uses the representation to interpret sentences in the language.
    /// </summary>
    [TestClass]
    public class InterpreterTests
    {
        [TestMethod]
        public void Test()
        {
            var context = new Context();
            var list = new List<AbstractExpression>
            {
                new TerminalExpression(),
                new NonTerminalExpression(),
                new TerminalExpression(),
                new TerminalExpression()
            };
            foreach (var expression in list)
            {
                expression.Interpret(context);
            }
        }
    }

    public class Context
    {
    }

    public abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    public class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("TerminalExpression.Interpret");
        }
    }

    public class NonTerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("NonTerminalExpression.Interpret");
        }
    }
}
