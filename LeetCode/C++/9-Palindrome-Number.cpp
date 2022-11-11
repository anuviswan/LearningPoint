class Solution {
public:
bool isPalindrome(int x)
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
};