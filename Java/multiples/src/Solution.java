public class Solution {

    public int solution(int number) {

        int sum = 0;
        List multiples = new ArrayList();

        for(int i = 3; i < number; i += 3)
            multiples.add(i);
        for(int j = 5; j < number; j += 5){
            if(multiples.contains() = false)
                multiples.add(j);
        }
        for (int z = 0; z < multiples.size(); z++)
            sum += z;

        return sum;
    }
}