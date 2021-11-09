using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab6_Figures3D; 

namespace Lab8_VisibleFaces
{
    public class SceneFigures
    {
        private List<Figure3D> sceneFigures = new();
        private int Index = -1;

        public Figure3D NextFigure()
        {
            if (sceneFigures.Count == 0)
                return null; 
            Index = Index == sceneFigures.Count - 1 ? 0 : Index + 1; 
            return sceneFigures.ElementAt(Index);
        }

        public void AddFigure(Figure3D figure) => sceneFigures.Add(new(figure));

        public void DeleteFigure()
        {
            sceneFigures.RemoveAt(Index);
            if (sceneFigures.Count == 0)
                Index = -1;
            else
                Index = 0; 
        }

        public void SetFigure(string name, Figure3D figure) => sceneFigures[Index] = new(figure);
    }
}
