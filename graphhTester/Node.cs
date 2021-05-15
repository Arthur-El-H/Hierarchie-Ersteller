﻿using System.Collections.Generic;

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
    public class Node
    {
        public string name;
        public NodeRepresenter nodeRep;
        public Node parent;
        public List<Node> children = new List<Node>();
        public System.Drawing.Color currentColor = System.Drawing.Color.FromArgb(198, 196, 221);
        public int depth = 0;

        public Depthtracker depthtracker;
        public Form2 form1;

        public Node(string nameEntry, Depthtracker depthtracker_)
        {
            name = nameEntry;
            depthtracker = depthtracker_;
            children = new List<Node>();
        }
        public List<Node> isPartOf()
        {
            List<Node> output = new List<Node>();
            output.Add(parent);
            if (parent.parent != null)
            {
                output.AddRange(parent.isPartOf()); 
            }
            return output;
        }
       public List<Node> includes()
        {
            List<Node> output = new List<Node>();
            foreach (Node child in children)
            {
                output.Add(child);
                if (child.children.Count > 0) { output.AddRange(child.includes()); }
            }
            return output;
        }
        Node getParent(int degree)
        {
            Node output = this;
            for (int i = 0; i < degree; i++)
            {
                output = output.parent;
            }
            return output;
        }        
        public List<Node> isEqualTo()                        
        {
            List<Node> outputNode = new List<Node> (depthtracker.getDepthList(this.depth));
            if (outputNode.Contains(depthtracker.getDepthList(1)[0])){ outputNode.Remove(depthtracker.getDepthList(1)[0]); }
            outputNode.Remove(this);
            return outputNode;
        }
        public List<Node> hasNoRelationTo()
        {
            List<Node> output = new List<Node>();
            Node varNode = this.getParent(depth - 1);
            List<Node> parentsEquals = new List<Node>(varNode.isEqualTo());
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
