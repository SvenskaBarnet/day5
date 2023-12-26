string[] input = File.ReadAllLines("input.txt");

List<double> seeds = new List<double>();
foreach (string seed in input[0].Split(':')[1].Substring(1).Split(' '))
{
    seeds.Add(double.Parse(seed));
}
List<double> locations = new List<double>();
foreach (double seed in seeds)
{
    double source = seed;
    bool getMap = false;
    foreach (string line in input)
    {
        if (line == string.Empty)
        {
            getMap = false;
        }

        if (getMap)
        {
            double[] map = Array.ConvertAll(line.Split(' '), double.Parse);

            if (map[1] <= source && source < (map[1] + map[2]))
            {
                if (map[1] < map[0])
                {
                    source = source - (map[1] - map[0]);
                    getMap = false;
                }
                else
                {
                    source = source + (map[0] - map[1]);
                    getMap = false;
                }
            }
        }

        if (line.Contains(':') && !line.Contains("seeds:"))
        {
            getMap = true;
        }
    }
    locations.Add(source);
}
Console.WriteLine(locations.Min());
