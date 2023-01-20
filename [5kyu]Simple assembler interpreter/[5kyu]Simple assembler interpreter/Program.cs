using System.Collections.Generic;

namespace Solution
{
    public static class SimpleAssembler
    {
        public static Dictionary<string, int> Interpret(string[] program)
        {
            Dictionary<string, int> storage = new Dictionary<string, int>();

            for (var i = 0; i < program.Length; i++)
            {
                if (program[i].StartsWith("mov"))
                {
                    Mov(storage, program[i]);
                }
                else if (program[i].StartsWith("inc"))
                {
                    Inc(storage, program[i]);
                }
                else if (program[i].StartsWith("dec"))
                {
                    Dec(storage, program[i]);
                }
                else if (program[i].StartsWith("jnz"))
                {
                    i = Jnz(storage, i, program[i]);
                }
            }

            return storage;
        }

        private static void Mov(Dictionary<string, int> storage, string action)
        {
            string[] instructions = action.Split(" ");

            string address = instructions[1];

            int value;

            if (!int.TryParse(instructions[2], out value))
            {
                value = storage[instructions[2]];
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
            string[] instructions = action.Split(" ");

            string address = instructions[1];

            storage[address]++;
        }

        private static void Dec(Dictionary<string, int> storage, string action)
        {
            string[] instructions = action.Split(" ");

            string address = instructions[1];

            storage[address]--;
        }

        private static int Jnz(Dictionary<string, int> storage, int currentState, string action)
        {
            string[] instructions = action.Split(" ");

            int condition;

            if (!int.TryParse(instructions[1], out condition))
            {
                condition = storage[instructions[1]];
            }

            int steps = int.Parse(instructions[2]);

            if (condition != 0)
            {
                return currentState + steps - 1;
            }
            else
            {
                return currentState;
            }
        }
    }
}