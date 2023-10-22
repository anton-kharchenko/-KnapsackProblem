var weight = new[] { 0, 8, 2, 6, 1 };
var values = new[] { 0, 50, 150, 210, 30 };
var data = new int[5, 11];
const int itemsCount = 4;
const int maxCapacity = 10;

for (var itemNum = 0; itemNum <= itemsCount; itemNum++)
{
    for (var capacity = 0; capacity <= maxCapacity; capacity++)
    {
        if (itemNum == 0 || capacity == 0)
        {
            data[itemNum, capacity] = 0;
        }
        else if (weight[itemNum] <= capacity)
        {
            // current item = Max between max value for prev item and (current value + allowed value)
            data[itemNum, capacity] = Math.Max(
                data[itemNum - 1, capacity], // max value for prev item
                values[itemNum] +
                data[itemNum - 1,
                    capacity - weight[
                        itemNum]] // current value + allowed value ( prev item row (is max row) , max capacity - current item capacity )
            );
        }
        else
        {
            data[itemNum, capacity] = data[itemNum - 1, capacity];
        }
    }
}

Console.WriteLine($"Max value of items included in container: {data[itemsCount, maxCapacity]}");
Console.ReadLine();