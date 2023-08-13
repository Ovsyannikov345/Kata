using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class Dinglemouse
{
    public static string[] TrafficLights(string road, int iterations)
    {
        (int position, string color, int timer)[] lights = Regex.Matches(road, @"[GOR]")
                                                                .Select(x => (x.Index, x.Value, 0))
                                                                .ToArray();

        int[] carPositions = Regex.Matches(road, @"C")
                                  .Select(x => x.Index)
                                  .ToArray();

        string[] roadStates = new string[iterations + 1];

        roadStates[0] = road;

        for (var iteration = 1; iteration <= iterations; iteration++)
        {
            ChangeLights();
            MoveCars();

            roadStates[iteration] = BuildRoadState(road.Length, lights, carPositions);
        }

        return roadStates;

        void ChangeLights()
        {
            for (var i = 0; i < lights.Length; i++)
            {
                lights[i].timer++;

                if (lights[i].color == "O" && lights[i].timer == 1)
                {
                    lights[i].color = "R";
                    lights[i].timer = 0;
                }
                else if (lights[i].timer == 5)
                {
                    if (lights[i].color == "R")
                    {
                        lights[i].color = "G";
                    }
                    else
                    {
                        lights[i].color = "O";
                    }

                    lights[i].timer = 0;
                }
            }
        }

        void MoveCars()
        {
            for (var i = carPositions.Length - 1; i >= 0; i--)
            {
                var forwardLight = lights.FirstOrDefault(light => light.position == carPositions[i] + 1);

                if (forwardLight != default)
                {
                    if (forwardLight.color != "G")
                    {
                        continue;
                    }
                    else if (carPositions.Any(carPosition => carPosition == carPositions[i] + 2))
                    {
                        continue;
                    }
                }
                else if (carPositions.Any(carPosition => carPosition == carPositions[i] + 1))
                {
                    continue;
                }

                carPositions[i]++;

                if (carPositions[i] >= road.Length)
                {
                    carPositions[i]++;
                }
            }
        }
    }

    private static string BuildRoadState(int roadLength, (int position, string color, int timer)[] lights, int[] carPositions)
    {
        char[] road = new string('.', roadLength).ToCharArray();

        foreach (var light in lights)
        {
            road[light.position] = char.Parse(light.color);
        }

        foreach (var carPosition in carPositions)
        {
            if (carPosition < roadLength)
            {
                road[carPosition] = 'C';
            }
        }

        return new string(road);
    }
}