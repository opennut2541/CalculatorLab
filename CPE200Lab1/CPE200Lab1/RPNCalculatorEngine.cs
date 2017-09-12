using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{ 
    class RPNCalculatorEngine : CalculatorEngine
    {
        public string Process(string str)
        {
            string result=null;
            Stack <string>rpnStack = new Stack <string>();
            string first, second;
            List<string> parts = str.Split(' ').ToList<string>();
            for (int i = 0; i < parts.Count;i++)
            {
                if (isNumber(parts[i]))
                {
                    rpnStack.Push(parts[i]);
                }
                else if (isOperator(parts[i]))
                {
                    try
                    {
                        second = rpnStack.Pop();
                        first = rpnStack.Pop();
                    }
                    catch(Exception ex)
                    {
                        return "E";
                    }
                    result = calculate(parts[i], first, second);

                    rpnStack.Push(result);
                }
            }
            return result;
        }
    }
}
