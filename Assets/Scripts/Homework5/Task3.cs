using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Task3 : MonoBehaviour
{
    [SerializeField] private int _numberSearch = 1;
     private int _numberOfRepeats;
     List<int> nums = new List<int>() { 1, 5, -2, 4, -6, 7, 1, 20, -16, 1, 1};
    private void Start()
    {
        foreach (var num in nums)
        {
            if (num == _numberSearch)
            {
                _numberOfRepeats++;
            }
        }
        Debug.Log(_numberOfRepeats);

        var posNums = from element 
                                    in nums 
                                    where element == _numberSearch 
                                    select _numberOfRepeats++;
        Debug.Log(posNums.Count());

        var res = nums.Where(i => i == _numberSearch);
        Debug.Log(res.Count());

    }
}
