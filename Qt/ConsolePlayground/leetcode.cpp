#include "leetcode.h"
using namespace std;

LeetCode::LeetCode()
{

}

vector<int> LeetCode::twoSum(vector<int> &nums, int target)
{
    qInfo() << "Recieved input " << nums;
    qInfo() << "Recieved Target " << target;
    map<int,int> mapInt;

    for(int i=0;i< sizeof(nums);i++){
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
