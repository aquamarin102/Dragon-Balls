using System.Linq;
using UnityEngine;

public class Task2 : MonoBehaviour
{
    [SerializeField] private string _searchableSymbol = "l";
    private string text = "Language-Integrated Query (LINQ) is the name for a set of technologies based on the integration of query capabilities directly into the C# language." +
                          " Traditionally, queries against data are expressed as simple strings without type checking at compile time or IntelliSense support.";
    private void Start()
    {
        SearchSymbol(text,_searchableSymbol);
    }

    public static void SearchSymbol(string text, string searchableSymbol)
    {
        int count = text.ToCharArray().Where(c => c == searchableSymbol[0]).Count();

        Debug.Log(count);
    }
}
