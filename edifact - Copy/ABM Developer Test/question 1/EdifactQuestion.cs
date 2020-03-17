using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ABM_Developer_Test.question_1
{
    class EdifactQuestion
    {

        public void RunSolution()
        {
            String input = @"UNA:+.?'UNB+UNOC:3+2021000969+4441963198+180525:1225+3VAL2MJV6EH9IX+KMSV7HMD+CUSDECU-IE++1++1'UNH+EDIFACT+CUSDEC:D:96B:UN:145050'BGM+ZEM:::EX+09SEE7JPUV5HC06IC6+Z'LOC+17+IT044100'LOC+18+SOL'LOC+35+SE'LOC+36+TZ'LOC+116+SE003033'DTM+9:20090527:102'DTM+268:20090626:102'DTM+182:20090527:102'";

            String key = "LOC";

            String[] result = Solution(input, key);
            
            foreach (var element in result)
            {
                Console.WriteLine(element);
            }
        }

        public string[] Solution(string input, String segmentKey)
        {
            String Segmentpattern = @"'";
            String[] segments = System.Text.RegularExpressions.Regex.Split(input, Segmentpattern);

            String elementPattern = @"\+";

            ArrayList list = new ArrayList();
            foreach (var elements in segments)
            {
                try
                {
                    String[] element = System.Text.RegularExpressions.Regex.Split(elements, elementPattern);
                    if (element.Length >= 1)
                    {
                        if (element[0] == segmentKey)
                        {
                            for (int i = 1; i < elements.Length && i < 3; i++)
                            {
                                list.Add(element[i]);       
                            }
                        }
                     }
                }
                catch (Exception e)
                {
                    
                }
               
            }

            return (string[])list.ToArray(typeof(string));
        }
    }
}
