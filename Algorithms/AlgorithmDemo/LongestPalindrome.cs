using System;

namespace AlgorithmDemo
{
    public class LongestPalindrome
    {
        public string ExpandingWithCorners(string src)
        {
            var left = 0;
            var max = 0;
            for(int i=0;i<src.Length; i++)
            {
                var l1 = GetLength(src, i, i);
                var l2 = GetLength(src, i, i+1);
                var current = Math.Max(l1, l2);

                if(current > max)
                {
                    max = current;
                    left = i-(current-1)/2;
                }
            }

            return src.Substring(left, max);
        }

        private int GetLength(string src,int left,int right)
        {
            while(left>=0 && right < src.Length && src[left]==src[right])
            {
                left--;
                right++;
            }

            return right - (left+1);
        }
    }
}
