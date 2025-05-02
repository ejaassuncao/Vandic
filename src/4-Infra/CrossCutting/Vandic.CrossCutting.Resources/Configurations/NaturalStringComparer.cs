using System.Text.RegularExpressions;

public class NaturalStringComparer<T> : IComparer<T>
{
    private readonly Func<T, string?> _selector;
    private static readonly Regex _numberRegex = new(@"\d+", RegexOptions.Compiled);

    public NaturalStringComparer(Func<T, string?> selector)
    {
        _selector = selector;
    }

    public int Compare(T? x, T? y)
    {
        var strX = _selector(x!);
        var strY = _selector(y!);

        if (strX == null || strY == null)
            return string.Compare(strX, strY, StringComparison.OrdinalIgnoreCase);

        var xParts = _numberRegex.Split(strX);
        var yParts = _numberRegex.Split(strY);
        var xNumbers = _numberRegex.Matches(strX);
        var yNumbers = _numberRegex.Matches(strY);

        int max = Math.Max(xParts.Length, yParts.Length);
        for (int i = 0; i < max; i++)
        {
            if (i < xParts.Length && i < yParts.Length)
            {
                int cmp = string.Compare(xParts[i], yParts[i], StringComparison.OrdinalIgnoreCase);
                if (cmp != 0) return cmp;
            }

            if (i < xNumbers.Count && i < yNumbers.Count)
            {
                int numX = int.Parse(xNumbers[i].Value);
                int numY = int.Parse(yNumbers[i].Value);
                if (numX != numY) return numX.CompareTo(numY);
            }
        }

        return strX.Length.CompareTo(strY.Length);
    }
}
