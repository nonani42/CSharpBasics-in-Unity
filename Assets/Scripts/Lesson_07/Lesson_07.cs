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
            // 2. ����������� ����� ���������� ��� ������ ���������� �������� � ������.
            Debug.Log("2 �������");
            string test = "qwerty";
            Debug.Log(test.GetCharNum());
        }

        private static void ThirdEx()
        {
            /* 
             * 3. ���� ��������� List<T>. ��������� ����������, ������� ��� ������ ������� ����������� � ������ ���������:
             * �. ��� ����� �����;
             * b. *��� ���������� ���������;
             * �. ** ��������� Linq.
             */
            Debug.Log("3 �������");

            Debug.Log("�������� ����");
            Elements<int> el = new();
            Random r = new();
            for (int i = 0; i < 10; i++)
            {
                el.testList.Add(r.Next(10));
                Debug.Log(el.testList.Last());
            }

            Debug.Log("�������� �������");
            Dictionary<int, int> result = el.GetUniqueElem();
            foreach (var e in result)
            {
                Debug.Log($"{e.Key}: {e.Value}; ");
            }

            Debug.Log("��������� Linq");
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
             * *4. * � ��������� ��� �������� ���������, ����������:
             * �. �������� ��������� � OrderBy � �������������� ������-��������� =>.
             * b. * ���������� ��������� � OrderBy � �������������� ��������
             */
            Dictionary<string, int> dict = new()
            {
                { "four", 4 },
                { "two", 2 },
                { "one", 1 },
                { "three", 3 },
            };

            //var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) {return pair.Value;});

            var � = dict.OrderBy(pair => pair.Value);

            Order = GetValue; //������� �����
            Order += delegate (KeyValuePair<string, int> pair) { return pair.Value; }; //��������� �����
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
