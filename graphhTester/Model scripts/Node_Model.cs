using System.Collections.Generic;

namespace graphhTester
{
    /*
    public class weightedNode
    {
        public Node node { get; set; }
        public int weight { get; set; }

        public weightedNode(Node nodeEntry, int weightEntry)
        {
            node = nodeEntry;
            weight = weightEntry;
        }
    }

    */
    public class Node_Model: IModel
    {
        public string name;
        public NodeRepresenter_Viewer nodeRep;
        public Node_Model parent;
        public List<Node_Model> children = new List<Node_Model>();
        public System.Drawing.Color currentColor = System.Drawing.Color.FromArgb(198, 196, 221);
        public int depth = 0;

        private Depthtracker depthtracker;

        public Node_Model(string nameEntry, Depthtracker depthtracker_)
        {
            name = nameEntry;
            depthtracker = depthtracker_;
            children = new List<Node_Model>();
        }
        public List<Node_Model> isPartOf()
        {
            List<Node_Model> output = new List<Node_Model>();
            output.Add(parent);
            if (parent.parent != null)
            {
                output.AddRange(parent.isPartOf()); 
            }
            return output;
        }
        public List<Node_Model> includes()
        {
            List<Node_Model> output = new List<Node_Model>();
            foreach (Node_Model child in children)
            {
                output.Add(child);
                if (child.children.Count > 0) { output.AddRange(child.includes()); }
            }
            return output;
        }
        private Node_Model getParent(int degree)
        {
            Node_Model output = this;
            for (int i = 0; i < degree; i++)
            {
                output = output.parent;
            }
            return output;
        }        
        public List<Node_Model> isEqualTo()                        
        {
            List<Node_Model> outputNode = new List<Node_Model> (depthtracker.getDepthList(this.depth));
            if (outputNode.Contains(depthtracker.getDepthList(1)[0])){ outputNode.Remove(depthtracker.getDepthList(1)[0]); }
            outputNode.Remove(this);
            return outputNode;
        }
        public List<Node_Model> hasNoRelationTo()
        {
            List<Node_Model> output = new List<Node_Model>();
            Node_Model varNode = this.getParent(depth - 1);
            List<Node_Model> parentsEquals = new List<Node_Model>(varNode.isEqualTo());
            output.AddRange(parentsEquals);
            for (int i = 0; i < parentsEquals.Count; i++)
            {
                varNode = parentsEquals[i];
                output.AddRange(varNode.includes());
                output.Add(varNode);
            }
            return output;            
        }
    }
}
