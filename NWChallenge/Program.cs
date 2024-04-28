using System.Collections;
using System.Collections.Specialized;

public class Program
{
    public static void Main(string[] args)
    {
        // Problem 1: Sort Characters
        
        // Input 1
        // Console.Write("Input one line of words (S) : ");
        // string? problem1Input1 = Console.ReadLine();
        // SortCharacters(problem1Input1 ?? string.Empty, out OrderedDictionary vowels, out OrderedDictionary consonants);
        // PrintCharacters("Vowel Characters", vowels);
        // PrintCharacters("Consonants Characters", consonants);
        // 
        // // Input 2
        // Console.Write("Input one line of words (S) : ");
        // string? problem1Input2 = Console.ReadLine();
        // SortCharacters(problem1Input2 ?? string.Empty, out OrderedDictionary vowels2, out OrderedDictionary consonants2);
        // PrintCharacters("Vowel Characters", vowels2);
        // PrintCharacters("Consonants Characters", consonants2);

        // --

        // Problem 2: PSBB
        
        // Input 1
        Console.Write("Input the number of families : ");
        string problem2Input1Line1 = Console.ReadLine() ?? string.Empty;

        bool result = int.TryParse(problem2Input1Line1, out int familyCount);
        if (!result)
        {
            Console.WriteLine("Oops error, input is not number");
        }

        Console.Write("Input the number of members in the family (separated by a space) : ");
        string problem2Input1Line2 = Console.ReadLine() ?? string.Empty;

        string strResult = CountBusDuringQuarantine(problem2Input1Line2, familyCount);
        Console.WriteLine(strResult);

        // Input 2

    }

    // --

    public static string CountBusDuringQuarantine(string input, int familyCount)
    {
        string[] splits = input.Split(' ');

        if (splits.Length != familyCount) 
        {
            return "Input must be equal with count of family";
        }

        int[] familyMemberCounts = new int[familyCount];
        for (int i = 0; i < familyCount; i++)
        {
            if (!int.TryParse(splits[i], out int familyMemberCount))
            {
                return "Error in converting number from string split";
            }

            familyMemberCounts[i] = familyMemberCount;
        }

        int sum = 0;
        foreach (int count in familyMemberCounts)
        {
            sum += count;
        }

        int busCount = sum / 4;

        bool additionalBus = sum % 4 != 0;
        if (additionalBus) busCount += 1;

        
        return $"Minimum bus required is : {busCount}";
    }

    // -------------------------------------------------------------------------
    // -------------------------------------------------------------------------

    private static char[] _vowelCharsLookupTable = new char[] { 'a', 'e', 'i', 'o', 'u' };

    private static bool IsVowelChar(char character)
    {
        foreach (char vowel in _vowelCharsLookupTable)
        {
            if (character == vowel)
            {
                return true;
            }
        }

        return false;
    }

    public static void SortCharacters(string word, out OrderedDictionary vowels, out OrderedDictionary consonants)
    {
        string lowered = word.ToLower();

        // Use ordered dictionary to store char along its occurences
        vowels = new OrderedDictionary();
        consonants = new OrderedDictionary();

        for (int i = 0; i < lowered.Length; i++)
        {
            if (lowered[i] == ' ') continue;

            if (IsVowelChar(lowered[i]))
            {
                HandleOrderedCharacters(lowered, i, vowels);
            }
            else
            {
                HandleOrderedCharacters(lowered, i, consonants);
            }
        }
    }

    private static void HandleOrderedCharacters(string word, int index, OrderedDictionary ordered)
    {
        if (ordered.Contains(word[index]))
        {
            int occurences = (int)ordered[(object)word[index]];
            occurences += 1;
            ordered[(object)word[index]] = occurences;
        }
        else
        {
            ordered.Add((object)word[index], 1);
        }
    }

    public static void PrintCharacters(string header, OrderedDictionary orderedDict)
    {
        // print vowels
        Console.WriteLine($"{header} : ");
        foreach (DictionaryEntry kvp in orderedDict)
        {
            int occurences = (int)kvp.Value;
            for (int i = 0; i < occurences; i++)
            {
                Console.Write((char)kvp.Key);
            }
        }
        Console.WriteLine();
    }
    
    // -------------------------------------------------------------------------
    // -------------------------------------------------------------------------


}
