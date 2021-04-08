using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace graphhTester
{
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
    public class Node
    {
        public string name;

        public Node parent;
        public List<Node> children = new List<Node>();

        public List<Node> included = new List<Node>();

        int childrensDepth;
        public int depth = 0;
        public int amountOfIncluded;

        public Depthtracker depthtracker;
        public Form2 form1;

        public NodeRepresenter nodeRep;

        public Node(string nameEntry, Depthtracker depthtracker_)
        {
            name = nameEntry;
            depthtracker = depthtracker_;
            children = new List<Node>();
        }


        //int parentDegreeCounter;
        public List<Node> isPartOf(List<Node> outputNodes)
        {
            outputNodes.Add(parent);
            if (parent.parent != null)
            {
                return parent.isPartOf(outputNodes); 
            }
            else
            {
                //parentDegreeCounter = 0;
                return (outputNodes);
            }
        }

        //potentiell zu Array, wenn childrensChildren getrackt würde (z.B. durch int bei jedem node und eins hochzählen bei parentParents nach Aufnahme neues Nodes
       public List<Node> includes(List<Node> output)
        {
                foreach (Node child in children)
                {
                    output.Add(child);
                    if (child.children.Count > 0) { output.AddRange(child.includes(new List<Node>() )); }
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

        public List<Node> isEqualTo(List<Node> outputNode)                        // Gibt sich selbst mit wert 0 zurück: Gut für markieren.
        {
            outputNode = depthtracker.getDepthList(this.depth);
            if (outputNode.Contains(depthtracker.getDepthList(1)[0])) { outputNode.Remove(depthtracker.getDepthList(1)[0]); }
            outputNode.Remove(this);
            return outputNode;
        }

        public List<Node> hasNoRelationTo(List<Node> output)
        {            
            Node varNode = this.getParent(depth - 1);
            List<Node> parentsEquals = new List<Node>(varNode.isEqualTo(new List<Node>() ));
            parentsEquals.Remove(this);
            for (int i = 0; i < parentsEquals.Count; i++)
            {
                varNode = parentsEquals[i];
                output.AddRange(varNode.includes( new List<Node>() ));
                output.Add(varNode);
            }
            return output;            
        }
    }
}
