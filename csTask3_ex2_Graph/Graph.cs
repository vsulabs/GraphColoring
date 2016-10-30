using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace csTask3_ex2_Graph
{
    /// <summary> Класс, описывающий граф (неориентированный, без self-loop вершин)
    /// Максимальное количество вершин ограничено. 
    /// Дуги задаются матрицей смежности
    /// </summary>
    class Graph
    {
        /// <summary> Максимальное количество вершин в графе
        /// </summary>
        public static int MaxN { get; } = 25;

        /// <summary> Текущее количество вершин в графе
        /// </summary>
        public int Size => Vertices.Count;

        /// <summary> Текущие вершины графа
        /// </summary>
        protected readonly List<Vertex> Vertices;

        /// <summary> Матрица смежности, задающая дуги между вершинами
        /// </summary>
        protected bool[,] Matr;

        /// <summary>
        /// Конструктор 
        /// </summary>
        public Graph()
        {
            Vertices = new List<Vertex>();            
        }

        /// <summary> Метод работы с дугами графа. 
        /// Координаты соответствующих вершин, с дугами между которыми происходит работа,
        /// должны попасть в радиус этих вершин
        /// </summary>
        /// <param name="one">Координата, соответствующая первой вершине</param>
        /// <param name="two">Координата, соответствующая второй вершине</param>
        /// <param name="isAddAction">TRUE, если необходимо добавить дугу между вершинами;
        /// FALSE, если необходимо удалить дугу между вершинами</param>
        /// <returns>TRUE, если работа с дугой прошла успешно, FALSE в противном случае</returns>
        public bool ActionArc(ref Point one, ref Point two, bool isAddAction)
        {
            // ищем необходимые для создания или удаления дуги вершины
            Point ij = GetVerticesCoords(one, two);
            if (ij.X == -1 && ij.Y == -1)
                return false; // выходим, если таковые не найдены или они совпадают (-1, -1).

            // матрице смежности присваиваем значение в зависимости от 
            // необходимого действия: добавления или удаления дуги
            Matr[ij.X, ij.Y] = Matr[ij.Y, ij.X] = isAddAction;
            return true;
        }

        /// <summary> Позволяет добавить вершину в граф.
        /// </summary>
        /// <param name="pos">Точка привязки вершины на плоскости</param>
        /// <returns>TRUE, если вершина не пересекается с другими и может быть добавлена</returns>
        public bool AddVertices(Point pos)
        {            
            // проверка, что ещё не достигнуто максимальное число вершин 
            // и что новая вершина не будет пересекаться с другими
            if (Vertices.Count == MaxN ||Vertices.Any(v => v.CrossedVertices(pos))) 
                return false;                        
            Vertices.Add(new Vertex(pos));
            
            IncRangMatrix(); // добавление строки, соответствующей новой вершине, в матрицу смежности 
            return true;
        }

        /// <summary> Метод позволяет удалить вершину из графа
        /// </summary>
        /// <param name="pos">Точка, характеризующая удаляемую вершину: должна попасть в её радиус окружности</param>
        /// <returns>TRUE, если найдена и удалена соответсствующая вершина</returns>
        public bool DelVertices(Point pos)
        {            
            for (int i = 0; i < Vertices.Count; ++i)
                // если найдена вершина, которую следует удалить 
                if (Vertices[i].Crossed(pos)) {
                    // бежим по всем другим вершинам и удаляем дуги в матрице смежности                              
                    for (int j = 0; j < Vertices.Count; ++j) 
                        if (Matr[i, j]) 
                            Matr[i, j] = Matr[j, i] = false;                        
                    Vertices.RemoveAt(i);
                    DecRangMatrix(i); // пересчет матрицы смежности              
                    return true;
                }
            return false;
        }
        
        /// <summary> Функция находит две искомые вершины, и возвращает их координаты в виде структуры Point </summary>
        /// <param name="one">Точка, которая должна попасть в радиус первой вершины</param>
        /// <param name="two">Точка, которая должна попасть в радиус второй вершины</param>
        /// <returns>Пара, хванящая координаты вершин в сиходном векторе, или -1, -1, если две различные
        /// точки не найдены</returns>
        private Point GetVerticesCoords(Point one, Point two)
        {
            Point res = new Point(0, 0);
            // пытаемся найти две вершины, в радиус которых попадают переданные точки
            for (; res.X < Size && !Vertices[res.X].Crossed(one); ++res.X) { }
            for (; res.Y < Size && !Vertices[res.Y].Crossed(two); ++res.Y) { }
            // если вершины не найдены или совпадают, следует вернуть специальную точку -1,-1
            if (!(res.Y < Vertices.Count && res.X < Vertices.Count && res.X != res.Y))
                res = new Point(-1, -1);
            return res;
        }

        /// <summary> Решение задачи раскраски графа. Вершины должны быть раскрашены минимальным количеством цветов так,
        /// чтобы смежным вершинам не был присвоен один цвет. Реализуется рекурсивной функцией:
        /// Попытка раскрасить граф с помощью 1 цвета, затем 2, ... 
        /// Граф точно будет раскрашен в MaxN цветов, т.е. каждой вершине свой цвет
        /// </summary>
        public void Colorize()
        {
            int k = 0;
            // цикл начнется с 1 и закончится при успешной раскраске графа, котоаря в худшем случае
            // наступит на шаге k, равном количеству вершин
            do
            { 
                ++k;
            } while (!ColorizeRec(0, k));
        }

        /// <summary> Рекурсивный алгоритм получения раскраски графа
        /// </summary>
        /// <param name="i"> Текущая вершина, которую необходимо окрасить </param>
        /// <param name="k"> Количество цветов в распоряжении </param>
        /// <returns></returns>
        private bool ColorizeRec(int i, int k)
        {
            HashSet<int> palitra = new HashSet<int>(); // набор цветов в распоряжении
            int j = 1;
            for (; j <= k; ++j) // в множестве palitra теперь цвета от 1..k, 
                palitra.Add(j); // и к - максимально доступный цвет

            for (j = 0; j < i; ++j)
                if (Matr[i, j])    // если у текущей вершины есть связь с предшествующей, 
                    palitra.Remove(Vertices[j].Color); // удаляем цвет, в который окрашена смежная вершина

            if (palitra.Count == 0) // если уже не хватает цветов, возвращаемся по рекурсии
                return false;

            // пытаемся раскрасить текущую вершину во все доступные цвета, и переходя к следующей
            // когда будет достигнута последняя вершина с задействованием минимально числа цветов,
            // выход из рекурсии
            foreach (var color in palitra) 
            {
                Vertices[i].Color = color;
                if (i + 1 == Vertices.Count) // если окрашена последняя вершина, 
                    return true; // все хорошо, выходим из рекурсии, true       
                if (ColorizeRec(i + 1, k))
                    return true; // если граф успешно окрашен заданным количеством цветов, выход из рекурсии
                Vertices[i].Color = 0;
            }
            return false;
        }
        
        /// <summary> Метод устанавливает всем вершинам Default цвет 0 
        /// </summary>
        protected void SetDefaultColors()
        {
            for (int i = 0; i < Size; ++i)
                Vertices[i].Color = 0;
        }

        /// <summary> Очистка графа - не остается вершин, матрица смежности пуста
        /// </summary>
        public void Clear()
        {
            Matr = null;
            Vertices.Clear();            
        }

        /// <summary> Добавление новой строки в матрицу смежности, необходимое 
        /// при добавлении новой вершины
        /// </summary>
        void IncRangMatrix()
        {
            int size = Vertices.Count;
            if (size == 0) {
                Matr = null;
                return;
            }
            bool[,] result = new bool[size, size];
            // перезапись всей старой информации
            for (int i = 0; i < size - 1; ++i)
                for (int j = 0; j < size - 1; ++j)
                    result[i, j] = Matr[i, j];
            // новый ряд и столбец пока не связаны ни с одной вершиной 
            for (int i = 0; i < size; ++i)
                result[size - 1, i] = result[i, size - 1] = false;
            Matr = result;
        }

        /// <summary> Удаление строки из матрицы смежности, связанное с удалением вершины и всех ее связей.
        /// </summary>
        /// <param name="pos">Номер вершины, которая была удалена. Соответствует ряду и столбцу матрицы</param>
        void DecRangMatrix(int pos)
        {
            int size = Vertices.Count;
            if (size == 0) {
                Matr = null;
                return;
            }
            bool[,] result = new bool[size, size];
            // переписываем всю информацию из старой матрицы до удаленной вершины
            for (int i = 0; i < pos && i < size; ++i)
                for (int j = 0; j < pos && i < size; ++j)
                    result[i, j] = Matr[i, j];
            // переписываем всю информацию из старой матрицы после удаленной вершины
            for (int i = pos; i < size; ++i)
                for (int j = pos; j < size; ++j)
                    result[i, j] = Matr[i + 1, j + 1];
            Matr = result;
        }
    }
}
