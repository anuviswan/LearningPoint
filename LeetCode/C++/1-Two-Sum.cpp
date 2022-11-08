using namespace std;

class Solution {
public:
    vector<int> twoSum(vector<int>& nums, int target) {

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
};