using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Calculator.Controllers
{
    public class CalcController : Controller
    {

        public string str = "calc";

        public IActionResult Calc()
        {
            return View();
        }

        [HttpGet]
        public string Calculate(Payload data)
        {
            return EvaluateString.evaluate(data.Operation).ToString();
        }

    }

    public class Payload
    {
        public string? Operation { get; set; }
    }
}

public class EvaluateString
{
    public static float evaluate(string expression)
    {
        char[] tokens = expression.ToCharArray();

        Stack<float> values = new Stack<float>();

        Stack<char> ops = new Stack<char>();

        for (int i = 0; i < tokens.Length; i++)
        {
            if (tokens[i] == ' ')
            {
                continue;
            }

            if (tokens[i] >= '0' && tokens[i] <= '9')
            {
                StringBuilder sbuf = new StringBuilder();

                while (i < tokens.Length &&
                        tokens[i] >= '0' &&
                            tokens[i] <= '9')
                {
                    sbuf.Append(tokens[i++]);
                }
                values.Push(float.Parse(sbuf.ToString()));

                i--;
            }
            else if (tokens[i] == '(')
            {
                ops.Push(tokens[i]);
            }
            else if (tokens[i] == ')')
            {
                while (ops.Peek() != '(')
                {
                    values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
                }
                ops.Pop();
            }

            else if (tokens[i] == '+' ||
                    tokens[i] == '-' ||
                    tokens[i] == '*' ||
                    tokens[i] == '/')
            {


                while (ops.Count > 0 &&
                        hasPrecedence(tokens[i],
                                    ops.Peek()))
                {
                    values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
                }

                ops.Push(tokens[i]);
            }
        }


        while (ops.Count > 0)
        {
            values.Push(applyOp(ops.Pop(), values.Pop(), values.Pop()));
        }


        return values.Pop();
    }

    public static bool hasPrecedence(char op1,
                                    char op2)
    {
        if (op2 == '(' || op2 == ')')
        {
            return false;
        }
        if ((op1 == '*' || op1 == '/') &&
            (op2 == '+' || op2 == '-'))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public static float applyOp(char op,
                            float b, float a)
    {
        switch (op)
        {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                if (b == 0)
                {
                    throw new
                    System.NotSupportedException(
                        "Cannot divide by zero");
                }
                return a / b;
        }
        return 0;
    }

    
}

