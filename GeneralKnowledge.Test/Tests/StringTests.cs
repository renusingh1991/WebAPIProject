using System;
using System.Collections.Generic;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic string manipulation exercises
    /// </summary>
    public class StringTests : ITest
    {

        public void Run()
        {
            // TODO
            // Complete the methods below

            AnagramTest();
            GetUniqueCharsAndCount();
        }

        private void AnagramTest()
        {
            var word = "stop";
            var possibleAnagrams = new string[] { "stop", "test", "tops", "spin", "post", "mist", "step" };

            foreach (var possibleAnagram in possibleAnagrams)
            {
                Console.WriteLine(string.Format("{0} > {1}: {2}", word, possibleAnagram, possibleAnagram.IsAnagram(word)));
            }
        }

        private void GetUniqueCharsAndCount()
        {
            var word = "xxzwxzyzzyxwxzyxyzyxzyxzyzyxzzz";
            Dictionary<string, int> dictUniqueCharAndCounts = GetUniqueCharsAndCount(word);

            foreach (KeyValuePair<string, int> item in dictUniqueCharAndCounts)
            {
                Console.WriteLine("Unique character {0} and its count is {1}", item.Key, item.Value);
            }

        }
        public static Dictionary<string, int> GetUniqueCharsAndCount(string word)
        {
            char[] charArr = word.ToCharArray();
            Dictionary<string, int> dictUniqueCharAndCount = new Dictionary<string, int>();
            // TODO
            // Write an algorithm that gets the unique characters of the word below 
            // and counts the number of occurrences for each character found
            try
            {


                foreach (var charValue in charArr)
                {
                    if (dictUniqueCharAndCount.Count == 0)
                    {
                        dictUniqueCharAndCount.Add(charValue.ToString(), 1);
                    }
                    else
                    {

                        if (dictUniqueCharAndCount.ContainsKey(charValue.ToString()))
                        {

                            dictUniqueCharAndCount[charValue.ToString()] = dictUniqueCharAndCount[charValue.ToString()] + 1;

                        }
                        else
                        {
                            dictUniqueCharAndCount.Add(charValue.ToString(), 1);
                        }
                    }
                }

                return dictUniqueCharAndCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }

    public static class StringExtensions
    {
        public static bool IsAnagram(this string a, string b)

        {
            // TODO
            // Write logic to determine whether a is an anagram of b

            Dictionary<string, int> dictWord = StringTests.GetUniqueCharsAndCount(b);
            Dictionary<string, int> dictPossibleAnagram = StringTests.GetUniqueCharsAndCount(a);
            bool isAnagramBool = false;
            try
            {
                if (dictWord.Count != dictPossibleAnagram.Count)
                {
                    return false;
                }
                else
                {
                    foreach (var item in dictWord)
                    {
                        if (dictPossibleAnagram.ContainsKey(item.Key) && dictPossibleAnagram[item.Key] == dictWord[item.Key])
                        {
                            isAnagramBool = true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isAnagramBool;





        }
    }
}
