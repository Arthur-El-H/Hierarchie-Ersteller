using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace graphhTester
{
    public class Depthtracker: IModel
        //tracks the (number of) elements in the different depths
    {
        private List<List<Node_Model>> depthRows = new List<List<Node_Model>>();
        public List<Node_Model> getDepthList(int depth)
        {
            return depthRows[depth - 1];
        }
        public void addNewRow()
        {
            depthRows.Add(new List<Node_Model>());
        }
        public void addToRow(int depth, Node_Model node)
        {
            depthRows[depth].Add(node);
        }
        public int getDepth()
        {
            return depthRows.Count;
        }
        public void remove(Node_Model node)
        {            
            List<Node_Model> Nodes = depthRows[node.depth - 1];
            Nodes.Remove(node);
        }
    }
}
