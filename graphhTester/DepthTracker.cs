using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace graphhTester
{
    public class Depthtracker //tracks the (number of) elements in the different depths
    {
        public List<List<Node>> depthRows = new List<List<Node>>();
        public List<Node> getDepthList(int depth)
        {
            return depthRows[depth - 1];
        }
        public void addNewRow()
        {
            depthRows.Add(new List<Node>());
        }
        public void addToRow(int depth, Node node)
        {
            depthRows[depth].Add(node);
        }
        public int getDepth()
        {
            return depthRows.Count;
        }
        public void remove(Node node)
        {            
            List<Node> Nodes = depthRows[node.depth - 1];
            Nodes.Remove(node);
        }

    }
}
