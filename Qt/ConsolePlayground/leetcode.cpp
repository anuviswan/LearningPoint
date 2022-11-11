#include "leetcode.h"
using namespace std;

LeetCode::LeetCode()
{

}

vector<int> LeetCode::twoSum(vector<int> &nums, int target)
{
    map<int,int> mapInt;

    for(int i=0;i< end(nums) - begin(nums) ;i++)
    {
        int current = nums[i];
        int expected = target - current;

        std::map<int,int>::iterator iterate = mapInt.find(expected);
        if(iterate != mapInt.end())
        {
             return vector<int>{i,iterate->second};
        }

        mapInt.insert(std::pair<int,int>(current,i));
    }
    return vector<int> {0,0};
}

bool LeetCode::isPalindrome(int x)
{
    long reverse = 0;
    long original = x;

    while(original > 0)
    {
        long remainder = original % 10;
        reverse = (reverse*10) + remainder;

        original = original / 10;
    }

    return (reverse == x);
}
