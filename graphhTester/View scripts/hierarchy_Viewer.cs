using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace graphhTester
{
    public class hierarchy_Viewer : Iview
    {
        private List <List<NodeRepresenter_Viewer>> visualTree = new List<List<NodeRepresenter_Viewer>>();
        private List <int> amountOfRows = new List<int>();
        private List<Point> pointForDepth = new List<Point>(); //holds (0/0) for every depth

        private int verticalDistance = 80;
        private int horizontalDistance = 150;

        public void insertNodeRepMaster(NodeRepresenter_Viewer master)
        {
            master.lastChildIndex = 0;
            master.depth = 0;
            visualTree[0].Add(master);
        }
        private int correctedIndex(NodeRepresenter_Viewer rep)
        {
            int index = 0;
            int index_ = visualTree[rep.depth].FindIndex(a => a == rep);
            for (int i = 0; i < index_; i++)
            {
                {
                    foreach (NodeRepresenter_Viewer child in visualTree[rep.depth][i].children)
                    {
                        if (visualTree[rep.depth + 1].Contains(child))
                        {
                            index++;
                        }
                    }
                }
            }
            return index;
        }

        private List<Node_Model> toNotCheck = new List<Node_Model>();
        private NodeRepresenter_Viewer new_Child; //10.5.

        public void insertRepAsParent(NodeRepresenter_Viewer rep, NodeRepresenter_Viewer newChild, bool notFirstTime = true)
        {
            rep.children.Add(newChild);
            new_Child = newChild;

            
            toNotCheck = newChild.node.includes();

            int repIndex = getRepIndex(newChild);
            for (int i = repIndex; i < visualTree[newChild.depth].Count; i++)
            {
                visualTree[newChild.depth][i].lastChildIndex -= newChild.children.Count;
            }
            for (int i = getRepIndex(rep.parent); i < visualTree[rep.parent.depth].Count; i++)
            {
                visualTree[rep.parent.depth][i].lastChildIndex --;
            }
            if (!notFirstTime) { insertRep(rep, true, repIndex); }
            
            removeFromDepth(newChild);

            newChild.parent.children.Remove(newChild);
            newChild.parent = rep;

            insertRep(newChild);

            foreach (Node_Model node in toNotCheck)
            {
                removeFromDepth(node.nodeRep);
                node.nodeRep.depth = 0;
                insertRep(node.nodeRep);
            }
        }
        private int getRepIndex(NodeRepresenter_Viewer noderep)
        {
            return visualTree[noderep.depth].FindIndex(a => a == noderep);
        }
        private void removeFromDepth(NodeRepresenter_Viewer noderep, NodeRepresenter_Viewer rep = null) //in visual tree only - parenthood/childhood is organized seperately
        {
                int index = visualTree[noderep.parent.depth].FindIndex(a => a == noderep.parent);
                visualTree[noderep.depth].Remove(noderep);
                for (int i = index; i < visualTree[noderep.parent.depth].Count; i++)
                {
                    if (!(toNotCheck.Contains(visualTree[noderep.parent.depth][i].node) || visualTree[noderep.parent.depth][i] == new_Child))
                    {
                        for (int j = 0; j < noderep.children.Count; j++)
                        {
                        if (visualTree[noderep.parent.depth][i].lastChildIndex > 0)
                        {
                            visualTree[noderep.parent.depth][i].lastChildIndex--;
                        }
                        }                    
                    }
                }
            replaceDepth(noderep.depth);
        }
        public void insertRep(NodeRepresenter_Viewer repC, bool specificIndex = false, int index = 0)
        {
            repC.depth = repC.parent.depth + 1;
            Debug.WriteLine(repC.parent.name + "oder was");
            if (repC.depth >= visualTree.Count) { createNewDepth(); }
            //if (amountOfRows[rep.depth]*8 < visualTree[rep.depth].Count + 1) { giveNewRowTo(rep.depth); }
            if (specificIndex) { placeInDepth(repC, specificIndex, index); }
            else { placeInDepth(repC); }
        }
        public void createNewDepth()
        {
            visualTree.Add(new List<NodeRepresenter_Viewer>());
            amountOfRows.Add(1);
            int pointY = 40;
            Debug.WriteLine(amountOfRows.Count);
            for (int i = 1; i < amountOfRows.Count; i++) { pointY = pointY + verticalDistance; }
            Debug.WriteLine(pointY + "is too big?");
            pointForDepth.Add(new Point(30, pointY));
        }
        private void placeInDepth(NodeRepresenter_Viewer rep, bool specificIndex = false, int index = 0)
        {
            int index_ = visualTree[rep.parent.depth].FindIndex(a => a == rep.parent);
            
            if (specificIndex) 
            {
                { visualTree[rep.depth].Insert(index, rep); }
            }
            else if (visualTree[rep.depth].Count == 0) 
            { 
                visualTree[rep.depth].Add(rep); 
            }
            else if (rep.parent.lastChildIndex > visualTree[rep.depth].Count) 
            { 
                visualTree[rep.depth].Add(rep);
            }
            else if (visualTree[rep.depth].Count  == rep.parent.lastChildIndex) 
            { 
                visualTree[rep.depth].Add(rep);
            }
            else 
            {
                visualTree[rep.depth].Insert(rep.parent.lastChildIndex, rep); //10.5.
            }


            for (int i = index_; i < visualTree[rep.parent.depth].Count; i++)
            {
                {   visualTree[rep.parent.depth][i].lastChildIndex++; }
            }            

            replaceDepth(rep.depth);

            rep.lastChildIndex = correctedIndex(rep);
        }
        private void replaceDepth(int depth)
        {
            for (int i = 0; i < visualTree[depth].Count; i++)
            {
                Point newLoc = new Point(i * horizontalDistance + pointForDepth[depth].X,
                                         pointForDepth[depth].Y);
                visualTree[depth][i].Location = newLoc;

                //set anchorpoints
                visualTree[depth][i].Bottom = new Point(newLoc.X + 50, newLoc.Y + 40);
                visualTree[depth][i].Top =    new Point(newLoc.X + 50, newLoc.Y);
            }
        }

        private List <Node_Model> markedNodes = new List<Node_Model>();
        private Color standartColor = Color.FromArgb(198, 196, 221);
        public void markList(List<Node_Model> nodes, Color color)
        {
            colornodesList(markedNodes, standartColor);
            markedNodes = nodes;
            colornodesList(nodes, color);
        }
        private void colornodesList(List<Node_Model> nodes, Color color)
        {
            foreach(Node_Model node in nodes)
            {
                node.nodeRep.BackColor = color;
                node.currentColor = color;
            }
        }
    }
}
