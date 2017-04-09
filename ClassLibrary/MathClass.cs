using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class MathClass
    {
        /// <summary>
        /// 获取一元二次方程的跟
        /// </summary>
        /// <param name="a">平方系数</param>
        /// <param name="b">一次方系数</param>
        /// <param name="c">常量系数</param>
        /// <returns>平方根</returns>
        /// list
        public List<double> GetSquareRoot(int a,int b,int c)
        {
            
            List<double> list = new List<double>();
            int d = b * b - 4 * a * c;
            if (d>=0)
            {
                list.Add((-b-Math.Sqrt(d)/(2*a)));
                list.Add((b - Math.Sqrt(d) / (2 * a)));
            }
            return list;
        }
    }
}
