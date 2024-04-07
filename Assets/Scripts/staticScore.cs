using System.Collections;
using System.Collections.Generic;

namespace Game 
{

    public static class PreservedScore {
        public static int staticScore = 0;

        public static void AddScore(int amount) {
            staticScore += amount;
        }
    
    }
}