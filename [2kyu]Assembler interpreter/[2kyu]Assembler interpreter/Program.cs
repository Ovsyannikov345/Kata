using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

public static class AssemblerInterpreter
{
    public static string Interpret(string input)
    {
        // Storage for variables.
        Dictionary<string, int> storage = new Dictionary<string, int>();

        // Array of commands.
        string[] program = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        // Call stack to return after "ret" command.
        Stack<int> callStack = new Stack<int>();

        // Index of current executing command in program.
        int currentCommand = 0;

        // The result of previous compare operation.
        int compareResult = 0;

        // Message to be returned.
        StringBuilder resultMessage = new StringBuilder();

        // end reached => 0 => return result.
        // end not reached => 1 => return null.
        int exitCode = 0;

        while (currentCommand < program.Length)
        {
            // Preparing the command for execution.
            string command = RemoveComment(program[currentCommand]).Trim();

            // Executing command.
            string action = Regex.Match(command, @"\w+").Value;

            switch (action)
            {
                case "mov":
                    Mov(storage, command);
                    currentCommand++;
                    break;
                case "inc":
                    Inc(storage, command);
                    currentCommand++;
                    break;
                case "dec":
                    Dec(storage, command);
                    currentCommand++;
                    break;
                case "add":
                    Add(storage, command);
                    currentCommand++;
                    break;
                case "sub":
                    Sub(storage, command);
                    currentCommand++;
                    break;
                case "mul":
                    Mul(storage, command);
                    currentCommand++;
                    break;
                case "div":
                    Div(storage, command);
                    currentCommand++;
                    break;
                case "jmp":
                    currentCommand = Jmp(program, command);
                    break;
                case "cmp":
                    compareResult = Cmp(storage, command);
                    currentCommand++;
                    break;
                case "jne":
                    currentCommand = Jne(program, command, currentCommand, compareResult);
                    break;
                case "je":
                    currentCommand = Je(program, command, currentCommand, compareResult);
                    break;
                case "jge":
                    currentCommand = Jge(program, command, currentCommand, compareResult);
                    break;
                case "jg":
                    currentCommand = Jg(program, command, currentCommand, compareResult);
                    break;
                case "jle":
                    currentCommand = Jle(program, command, currentCommand, compareResult);
                    break;
                case "jl":
                    currentCommand = Jl(program, command, currentCommand, compareResult);
                    break;
                case "call":
                    callStack.Push(currentCommand);
                    currentCommand = Call(program, command);
                    break;
                case "ret":
                    currentCommand = callStack.Pop() + 1;
                    break;
                case "msg":
                    resultMessage.Append(Msg(storage, command));
                    currentCommand++;
                    break;
                case "end":
                    return End(exitCode, resultMessage.ToString());
                default:
                    currentCommand++;
                    break;
            }
        }

        return null;
    }

    private static void Mov(Dictionary<string, int> storage, string action)
    {
        action = Regex.Replace(action, @"mov\s*", "");

        string[] instructions = Regex.Split(action, @",\s*");

        string address = instructions[0];

        int value;

        if (!int.TryParse(instructions[1], out value))
        {
            value = storage[instructions[1]];
        }

        if (storage.ContainsKey(address))
        {
            storage[address] = value;
        }
        else
        {
            storage.Add(address, value);
        }
    }

    private static void Inc(Dictionary<string, int> storage, string action)
    {
        action = Regex.Replace(action, @"inc\s*", "");

        string address = action;

        storage[address]++;
    }

    private static void Dec(Dictionary<string, int> storage, string action)
    {
        action = Regex.Replace(action, @"dec\s*", "");

        string address = action;

        storage[address]--;
    }

    private static void Add(Dictionary<string, int> storage, string action)
    {
        action = Regex.Replace(action, @"add\s*", "");

        string[] instructions = Regex.Split(action, @",\s*");

        string address = instructions[0];

        int value;

        if (!int.TryParse(instructions[1], out value))
        {
            value = storage[instructions[1]];
        }

        storage[address] += value;
    }

    private static void Sub(Dictionary<string, int> storage, string action)
    {
        action = Regex.Replace(action, @"sub\s*", "");

        string[] instructions = Regex.Split(action, @",\s*");

        string address = instructions[0];

        int value;

        if (!int.TryParse(instructions[1], out value))
        {
            value = storage[instructions[1]];
        }

        storage[address] -= value;
    }

    private static void Mul(Dictionary<string, int> storage, string action)
    {
        action = Regex.Replace(action, @"mul\s*", "");

        string[] instructions = Regex.Split(action, @",\s*");

        string address = instructions[0];

        int value;

        if (!int.TryParse(instructions[1], out value))
        {
            value = storage[instructions[1]];
        }

        storage[address] *= value;
    }

    private static void Div(Dictionary<string, int> storage, string action)
    {
        action = Regex.Replace(action, @"div\s*", "");

        string[] instructions = Regex.Split(action, @",\s*");

        string address = instructions[0];

        int value;

        if (!int.TryParse(instructions[1], out value))
        {
            value = storage[instructions[1]];
        }

        storage[address] /= value;
    }

    private static int Jmp(string[] program, string action)
    {
        action = Regex.Replace(action, @"(jmp|jne|je|jge|jg|jle|jl)\s*", "");

        int jumpIndex = Array.FindIndex(program, command => command.StartsWith(action));

        return jumpIndex + 1;
    }

    private static int Cmp(Dictionary<string, int> storage, string action)
    {
        action = Regex.Replace(action, @"cmp\s*", "");

        string[] instructions = Regex.Split(action, @",\s*");

        int x;

        if (!int.TryParse(instructions[0], out x))
        {
            x = storage[instructions[0]];
        }

        int y;

        if (!int.TryParse(instructions[1], out y))
        {
            y = storage[instructions[1]];
        }

        return x - y;
    }

    private static int Jne(string[] program, string action, int currentCommand, int compareResult)
    {
        if (compareResult != 0)
        {
            return Jmp(program, action);
        }
        else
        {
            return currentCommand + 1;
        }
    }

    private static int Je(string[] program, string action, int currentCommand, int compareResult)
    {
        if (compareResult == 0)
        {
            return Jmp(program, action);
        }
        else
        {
            return currentCommand + 1;
        }
    }

    private static int Jge(string[] program, string action, int currentCommand, int compareResult)
    {
        if (compareResult >= 0)
        {
            return Jmp(program, action);
        }
        else
        {
            return currentCommand + 1;
        }
    }

    private static int Jg(string[] program, string action, int currentCommand, int compareResult)
    {
        if (compareResult > 0)
        {
            return Jmp(program, action);
        }
        else
        {
            return currentCommand + 1;
        }
    }

    private static int Jle(string[] program, string action, int currentCommand, int compareResult)
    {
        if (compareResult <= 0)
        {
            return Jmp(program, action);
        }
        else
        {
            return currentCommand + 1;
        }
    }

    private static int Jl(string[] program, string action, int currentCommand, int compareResult)
    {
        if (compareResult < 0)
        {
            return Jmp(program, action);
        }
        else
        {
            return currentCommand + 1;
        }
    }

    private static int Call(string[] program, string action)
    {
        action = Regex.Replace(action, @"call\s*", "");

        int jumpIndex = Array.FindIndex(program, command => command.StartsWith(action));

        return jumpIndex + 1;
    }

    private static string Msg(Dictionary<string, int> storage, string action)
    {
        action = Regex.Replace(action, @"msg\s*", "");

        StringBuilder message = new StringBuilder();

        // Splitting action into parts (just strings or variables).
        List<string> parts = new List<string>();

        bool betweenQuotes = false;

        for (var i = 0; i < action.Length; i++)
        {
            if (action[i] == '\'')
            {
                betweenQuotes = !betweenQuotes;
            }
            else if (action[i] == ',' && !betweenQuotes)
            {
                parts.Add(action[..i]);
                action = action[(i + 1)..].TrimStart();
                i = -1;
            }
        }

        if (action.Length != 0)
        {
            parts.Add(action);
        }

        // Assembling the result string.
        // Replacing variable names with values if necessary.
        foreach (var part in parts)
        {
            if (storage.ContainsKey(part))
            {
                message.Append(storage[part]);
            }
            else
            {
                message.Append(part[1..^1]);
            }
        }

        return message.ToString();
    }

    private static string End(int exitCode, string message)
    {
        if (exitCode == 0)
        {
            return message;
        }
        else
        {
            return null;
        }
    }

    private static string RemoveComment(string command)
    {
        int index = command.IndexOf(';');

        if (index != -1)
        {
            return command[..index];
        }
        else
        {
            return command;
        }
    }
}