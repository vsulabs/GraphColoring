using System;
using System.Drawing;

namespace csTask3_ex2_Graph
{
    /// <summary> Класс, описывающий вершины графа. 
    /// Вершина имеет радиус, точку привязки и цвет.
    /// Может быть осуществлена проверка пересечения с другой вершиной 
    /// или попадания точки в радиус текущей вершины
    /// </summary>
    class Vertex
    {
        /// <summary> цвет, в который раскрашена вершина. 0 - цвет не присвоен.
        /// Требует правила, по которому числу будет ставиться в соответствие цвет из палитры </summary>
        public int Color { get; set; }

        /// <summary> Координаты привязки вершины к точке на плоскости
        /// </summary>
        public Point Coord { get; }
        
        /// <summary> Радиус вершины. Две вершины не могут пересекаться своими окружностями 
        /// </summary>
        public static int Radius { get; } = 10;

        /// <summary> Конструктор, инициализирующий вершину графа </summary>
        /// <param name="point">Координаты вершины</param>
        /// <param name="c">Цвет вершины. По умолчанию не присвоен</param>
        public Vertex(Point point, int c = 0)
        {
            Coord = point;
            Color = c;
        }

        /// <summary> Метод проверяет, пересекается ли данная вершина своей окружностью с другой вершиной
        /// </summary>
        /// <param name="point">Центр окружности другой вершины</param>
        /// <returns>TRUE, если вершина с центром точке point будет пересекаться с текущей</returns>
        public bool CrossedVertices(Point point)
        {
            return 2 * Radius >= Math.Sqrt(Math.Pow(point.X - Coord.X, 2) + Math.Pow(point.Y - Coord.Y, 2));
        }

        /// <summary> Метод проверяет, попадает ли точка в радиус текущей вершины
        /// </summary>
        /// <param name="p">Точка, которая проверяется на вхождение в радиус текущей вершины</param>
        /// <returns>TRUE, если точка попадает в радиус текущей вершины</returns>
        public bool Crossed(Point p)
        {
            return Radius + 1 >= Math.Sqrt(Math.Pow(p.X - Coord.X, 2) + Math.Pow(p.Y - Coord.Y, 2));
        }

    }
}
