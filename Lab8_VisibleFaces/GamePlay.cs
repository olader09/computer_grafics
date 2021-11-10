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
        private List<(string, Figure3D)> sceneFigures = new();
        private int Index = -1;

        public List<(string, Figure3D)> GetFigures() => new(sceneFigures); 

        public (string, Figure3D) NextFigure()
        {
            if (sceneFigures.Count == 0)
                return (null, null); 
            Index = Index == sceneFigures.Count - 1 ? 0 : Index + 1; 
            return sceneFigures.ElementAt(Index);
        }

        public void AddFigure(string name, Figure3D figure) => sceneFigures.Add((name, new(figure)));

        public void DeleteFigure()
        {
            sceneFigures.RemoveAt(Index);
            if (sceneFigures.Count == 0)
                Index = -1;
            else
                Index = 0; 
        }

        public void SetFigure(string name, Figure3D figure) => sceneFigures[Index] = (name, new(figure));
    }
}
