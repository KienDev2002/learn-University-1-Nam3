

#đọc từ trái -> phải, phải -> trái nhữ nhau

class Solution:
    def isPalindrome(self,s:str) -> bool:
        if s:
            result = []
            #chuyen het ve thuong
            for c in s.lower():
                if c.isalnum(): #nếu là các kí tư ko phải là dấu ,....
                    result.append(c) #result sẽ chứa các chữ
            return result == result[::-1]

        else:
            return  True
