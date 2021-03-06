using System;
using System.Collections.Generic;
using System.Linq;
public class Solution {
    public static char[] CircularShiftLeft(char[] arr, int shifts)
    {
        var dest = new char[arr.Length];
        Array.Copy(arr, shifts, dest, 0, arr.Length - shifts);
        Array.Copy(arr, 0, dest, arr.Length - shifts, shifts);
        return dest;
    }
    
    public int solution(string s) {
        int answer = 0;
        Char[] temp = s.ToCharArray();
        int resultcount =0;
        int rightopen =0;
        int leftopen =0;

        for(int i=0; i<temp.Length; i++)
        {
            if(temp[i]=='['||temp[i]=='{'||temp[i]=='(') rightopen++;
            else leftopen++;
        }
        //괄호 개수가 안맞는 경우.
        if(rightopen != leftopen) return 0;
        
        //괄호가 올바르지 못할경우.
        else
        {
            while(resultcount<s.Length)
            {
                List<int> Count = new List<int>(){0,0,0,0,0,0};
                List<Char> stack = new List<Char>();
                for(int i=0; i<temp.Length; i++)
                {
                    if(temp[i] == '[')
                    {
                        stack.Add(temp[i]);
                        Count[0]++;
                    }
                    else if(temp[i] == ']')
                    {
                        Count[1]++;
                        if(Count[0]<Count[1]) 
                        {
                            resultcount++;
                            temp =CircularShiftLeft(temp,1);
                            break;
                        }
                        if(stack.Count != 0 &&stack[stack.Count-1]=='[')
                        {
                            stack.RemoveAt(stack.Count-1);
                        }
                        else
                        {
                            resultcount++;
                            temp =CircularShiftLeft(temp,1);
                            break;
                        }
                    }
                    else if(temp[i] == '{')
                    {
                        stack.Add(temp[i]);
                        Count[2]++;
                    }
                    else if(temp[i] == '}')
                    {
                        Count[3]++;
                        if(Count[2]<Count[3] )  
                        {
                            resultcount++;
                            temp =CircularShiftLeft(temp,1);
                            break;
                        }
                        if(stack.Count != 0 &&stack[stack.Count-1]=='{')
                        {
                            stack.RemoveAt(stack.Count-1);
                        }
                        else
                        {
                            resultcount++;
                            temp =CircularShiftLeft(temp,1);
                            break;
                        }
                    }
                    else if(temp[i] == '(')
                    {
                        stack.Add(temp[i]);
                        Count[4]++;
                    }
                    else if(temp[i] == ')')
                    {
                        Count[5]++;
                        if(Count[4]<Count[5] ) 
                        {
                            resultcount++;
                            temp =CircularShiftLeft(temp,1);
                            break;
                        }
                        if(stack.Count != 0 &&stack[stack.Count-1]=='(')
                        {
                            stack.RemoveAt(stack.Count-1);
                        }
                        else
                        {
                            resultcount++;
                            temp =CircularShiftLeft(temp,1);
                            break;
                        }
                    }
                    if(i == temp.Length-1)
                    {
                        answer++;
                        resultcount++;
                        temp =CircularShiftLeft(temp,1);
                    }
                }
            }
        }
        return answer;
    }
}