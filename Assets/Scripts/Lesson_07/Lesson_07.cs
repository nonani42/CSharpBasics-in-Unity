using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;


namespace Lesson_07
{
    public class Lesson_07 : MonoBehaviour
    {
        Func<KeyValuePair<string, int>, int> Order;

        public void Start()
        {
            SecondEx();
            ThirdEx();
            FourthEx();
        }

        private static void SecondEx()
        {
            // 2. Реализовать метод расширения для поиска количество символов в строке.
            Debug.Log("2 задание");
            string test = "qwerty";
            Debug.Log(test.GetCharNum());
        }

        private static void ThirdEx()
        {
            /* 
             * 3. Дана коллекция List<T>. Требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции:
             * а. для целых чисел;
             * b. *для обобщенной коллекции;
             * с. ** используя Linq.
             */
            Debug.Log("3 задание");

            Debug.Log("Исходный лист");
            Elements<int> el = new();
            Random r = new();
            for (int i = 0; i < 10; i++)
            {
                el.testList.Add(r.Next(10));
                Debug.Log(el.testList.Last());
            }

            Debug.Log("Итоговый словарь");
            Dictionary<int, int> result = el.GetUniqueElem();
            foreach (var e in result)
            {
                Debug.Log($"{e.Key}: {e.Value}; ");
            }

            Debug.Log("Используя Linq");
            List<char> testList = new() { 'r', 'q', 'w', 'r', 't', 'e', 'r', 'q', 'r', 't', 'y' };
            var uniqueEl = from t
                           in testList
                           group t by t into l
                           select new { l.Key, Value = l.Count() };

            foreach (var e in uniqueEl)
            {
                Debug.Log($"{e.Key}: {e.Value}; ");
            }
        }

        private void FourthEx()
        {
            /* 
             * *4. * В методичке дан фрагмент программы, необходимо:
             * а. Свернуть обращение к OrderBy с использованием лямбда-выражения =>.
             * b. * Развернуть обращение к OrderBy с использованием делегата
             */
            Dictionary<string, int> dict = new()
            {
                { "four", 4 },
                { "two", 2 },
                { "one", 1 },
                { "three", 3 },
            };

            //var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) {return pair.Value;});

            var а = dict.OrderBy(pair => pair.Value);

            Order = GetValue; //обычный метод
            Order += delegate (KeyValuePair<string, int> pair) { return pair.Value; }; //анонимный метод
            var b = dict.OrderBy(Order);

            foreach (var pair in b)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }
        }

        public int GetValue(KeyValuePair<string, int> pair)
        {
            return pair.Value;
        }
    }
}
