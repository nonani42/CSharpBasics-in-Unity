using System.Collections.Generic;


namespace Lesson_07
{
    public class Elements<T>
    {
        public List<T> testList;

        public Elements()
        {
            testList = new();
        }

        public Dictionary<T, int> GetUniqueElem()
        {
            Dictionary<T, int> res = new();
            foreach (var el in testList)
            {
                if (!res.ContainsKey(el))
                {
                    res.Add(el, 0);
                }
                res[el]++;
            }
            return res;
        }
    }
}
