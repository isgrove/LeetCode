namespace LeetCode.Problems;

public class ArraysAndHashing
{

  // Given two strings s and t, return true if t is an anagram of s, and false otherwise.
  // An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
  public bool IsAnagram(string s, string t)
  {
    if (s.Length != t.Length) return false;

    Dictionary<char, int> sCount = new Dictionary<char, int>();
    Dictionary<char, int> tCount = new Dictionary<char, int>();

    for (int i = 0; i < s.Length; i++)
    {
      sCount[s[i]] = 1 + sCount.GetValueOrDefault(s[i]);
      tCount[t[i]] = 1 + tCount.GetValueOrDefault(t[i]);
    }

    foreach (var x in tCount.Keys)
    {
      if (tCount[x] != sCount.GetValueOrDefault(x)) return false;
    }
    return true;
  }

  public void TestIsAnagram()
  {
    string s = "rat";
    string t = "car";

    System.Console.WriteLine($"Case 1: {this.IsAnagram(s, t)}");
  }

  // Given an integer array nums, return true if any value appears atleast twice in the array, and return false if every element is distinct.
  public bool ContainsDuplicate(int[] nums)
  {
    HashSet<int> count = new HashSet<int>();
    foreach (int num in nums)
    {
      if (count.Contains(num))
      {
        return true;
      }
      count.Add(num);
    }
    return false;
  }

  public void TestContainsDuplicate()
  {
    int[] case1 = new int[] { 1, 2, 3, 1 };
    bool expected1 = true;

    System.Console.WriteLine($"Case 1: {expected1 == this.ContainsDuplicate(case1)}");

    int[] case2 = new int[] { 1, 2, 3, 4 };
    bool expected2 = false;

    System.Console.WriteLine($"Case 2: {expected2 == this.ContainsDuplicate(case2)}");

    int[] case3 = new int[] { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
    bool expected3 = true;

    System.Console.WriteLine($"Case 3: {expected3 == this.ContainsDuplicate(case3)}");
  }

  // Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
  // You may assume that each input would have exactly one solution, and you may not use the same element twice.
  // You can return the answer in any order.
  // Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
  // https://leetcode.com/problems/two-sum/
  public int[] TwoSum(int[] nums, int target)
  {
    Dictionary<int, int> prev = new Dictionary<int, int>();
    int diff;
    for (int i = 0; i < nums.Length; i++)
    {
      diff = target - nums[i];
      if (prev.ContainsKey(diff))
      {
        return new int[] { prev[diff], i };
      }
      prev[nums[i]] = i;
    }

    throw new ArgumentException("No Two Sum solution");
  }

  public void TestTwoSum()
  {
    int[] nums1 = new int[] { 2, 7, 11, 15 };
    int target1 = 9;

    System.Console.WriteLine($"Case 1: {this.TwoSum(nums1, target1)}");
  }

  // Given an array of strings strs, group the anagrams together. You can return the answer in any order.
  // An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase, typically using all the original letters exactly once.
  // https://leetcode.com/problems/group-anagrams/
  public IList<IList<string>> GroupAnagrams(string[] strs)
  {
    Dictionary<string, IList<string>> result = new();
    string sortedStr;
    foreach (string str in strs)
    {
      sortedStr = String.Concat(str
        .OrderBy(c => char.ToUpper(c))
        .ThenBy(c => c));
      if (result.ContainsKey(sortedStr))
      {
        result[sortedStr].Add(str);
      }
      else
      {
        result[sortedStr] = new List<string> { str };
      }
    }
    return result.Values.ToList();
  }

  public void TestGroupAnagrams()
  {
    string[] strs1 = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };
    var result = this.GroupAnagrams(strs1);
    string msg;
    foreach (var strs in result)
    {
      msg = "[ ";
      foreach (var str in strs)
      {
        msg += str + " ";
      }
      msg += "]";
      System.Console.WriteLine(msg);
    }
  }

  // Given an integer array nums and an integer k, return the k most frquent elements. You may return the answer in any order.
  // https://leetcode.com/problems/top-k-frequent-elements/
  public int[] TopKFrequent(int[] nums, int k)
  {
    var count = new Dictionary<int, int>();
    var frequency = new List<int>[nums.Length + 1];
    var result = new int[k];
    var added = 0;

    for (int i = 0; i <= nums.Length; i++)
    {
      frequency[i] = new List<int>();
    }

    foreach (int num in nums)
    {
      count[num] = 1 + count.GetValueOrDefault(num);
    }

    foreach (KeyValuePair<int, int> kvp in count)
    {
      frequency[kvp.Value].Add(kvp.Key);
    }

    for (int i = nums.Length; i > 0; i--)
    {
      foreach (var n in frequency[i])
      {
        result[added] = n;
        added++;
        if (added == k)
        {
          return result;
        }
      }
    }
    throw new ArgumentException("No Top K Frequency solution");
  }

  public void TestTopKFrequent()
  {
    var nums1 = new int[] { 1, 1, 1, 2, 2, 3 };
    var k1 = 2;
    var result1 = TopKFrequent(nums1, k1);

    System.Console.WriteLine("Result 1:");
    foreach (var num in result1)
    {
      System.Console.WriteLine(num);
    }
  }
}